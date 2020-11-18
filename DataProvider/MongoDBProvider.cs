using DataObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataProvider
{
    public class MongoDBProvider : IDBProvider
    {
        MongoClient _client;
        IMongoDatabase _db;

        // This should go into config
        private const string connectionString = "mongodb+srv://dbAdmin:g3ueaQZFOIvSz4EY@trialcluster.refqk.mongodb.net/POI?retryWrites=true&w=majority";
        private const string importFilePath = ".\\LocationData.csv";

        public MongoDBProvider()
        {
            _client = new MongoClient(connectionString);
            _db = _client.GetDatabase("test");
            BsonClassMap.RegisterClassMap<PointOfInterest>();
            Initialise();
        }

        private void Initialise()
        {
            var collection = _db.GetCollection<PointOfInterest>("PointOfInterest");

            if (collection.CountDocuments(new BsonDocument()) > 0)
            {
                return;
            }

            string fullPath = Directory.GetCurrentDirectory() + importFilePath;
            List<PointOfInterest> pointsOfInterest = File.ReadAllLines(fullPath)
                                                         .Skip(1)
                                                         .Select(v => CreatePOIFromCsv(v))
                                                         .ToList();

            collection.InsertMany(pointsOfInterest);
        }

        public List<PointOfInterest> RetrievePointsOfInterest()
        {
            var collection = _db.GetCollection<PointOfInterest>("PointOfInterest");

            return collection.Find(new BsonDocument()).ToList();
        }

        private PointOfInterest CreatePOIFromCsv(string csvLine)
        {
            PointOfInterest poi = new PointOfInterest();

            string[] values = csvLine.Split(",");
            int.TryParse(values[0], out poi.Id);
            float.TryParse(values[1], out poi.Latitude);
            float.TryParse(values[2], out poi.Longitude);
            poi.Postcode = values[3];

            if (values.Length == 5)
            {
                poi.Description = values[4];
            }

            return poi;
        }
    }
}
