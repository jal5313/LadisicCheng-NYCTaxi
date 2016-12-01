using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace LadisicCheng_NYCTaxi.Models
{
    public class TaxiTripRepository : ITaxiTripRepository
    {
        private static ConcurrentDictionary<string, TaxiTrip> _todos =
              new ConcurrentDictionary<string, TaxiTrip>();

        public TaxiTripRepository()
        {
            Add(new TaxiTrip { Name = "Item1" });
        }

        public IEnumerable<TaxiTrip> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TaxiTrip item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public TaxiTrip Find(string key)
        {
            TaxiTrip item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TaxiTrip Remove(string key)
        {
            TaxiTrip item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TaxiTrip item)
        {
            _todos[item.Key] = item;
        }
    }
}