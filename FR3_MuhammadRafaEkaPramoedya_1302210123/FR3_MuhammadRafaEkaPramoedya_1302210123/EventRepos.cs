using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR3_MuhammadRafaEkaPramoedya_1302210123
{
    public class EventRepos<T> where T : Event
    {
        private List<T> events = new List<T>();

        // Add an event to the repository
        public void Add(T e)
        {
            events.Add(e);
        }

        // Search for events by a given property and value
        public List<T> Search(Func<T, bool> predicate)
        {
            return events.Where(predicate).ToList();
        }
    }
}
