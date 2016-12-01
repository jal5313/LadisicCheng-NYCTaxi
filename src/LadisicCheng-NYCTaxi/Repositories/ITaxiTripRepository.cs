using LadisicCheng_NYCTaxi.Models;
using System.Collections.Generic;

namespace LadisicCheng_NYCTaxi.Models
{
    public interface ITaxiTripRepository
    {
        void Add(TaxiTrip item);
        IEnumerable<TaxiTrip> GetAll();
        TaxiTrip Find(string key);
        TaxiTrip Remove(string key);
        void Update(TaxiTrip item);
    }
}