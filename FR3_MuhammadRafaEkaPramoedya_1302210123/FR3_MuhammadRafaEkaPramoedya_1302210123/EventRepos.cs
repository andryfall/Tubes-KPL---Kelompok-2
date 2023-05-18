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

        // Menambah Event
        public void Add(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), "Event tidak boleh null");
            }
            events.Add(e);
        }

        // Search Event berdasarkan predicate
        public List<T> Search(Func<T, bool> predicate)
        {
            return events.Where(predicate).ToList();
        }
    }
}
