using DataObjects;
using System.Collections.Generic;

namespace DataProvider
{
    public interface IDBProvider
    {
        List<PointOfInterest> RetrievePointsOfInterest();
    }
}
