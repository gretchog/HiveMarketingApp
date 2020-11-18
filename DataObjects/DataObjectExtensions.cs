namespace DataObjects
{
    public static class DataObjectExtensions
    {
        public static PointOfInterest FromCsv(string csvLine)
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
