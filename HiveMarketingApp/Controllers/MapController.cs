using DataObjects;
using DataProvider;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private IDBProvider _dbProvider;

        public MapController(IDBProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        // GET api/map
        /// <summary>
        /// Returns POIs for annotation of a map
        /// </summary>
        [HttpGet]
        public List<PointOfInterest> GetPointsOfInterest()
        {
            return _dbProvider.RetrievePointsOfInterest();
        }
    }
}