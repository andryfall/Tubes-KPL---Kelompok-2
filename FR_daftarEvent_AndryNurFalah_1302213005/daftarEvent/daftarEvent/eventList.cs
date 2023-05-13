using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    internal class eventList
    {
        public List<Event> events = new List<Event>();

        public eventList()
        {
        }

        public void addEvent(Event e)
        {
            events.Add(e);
        }

    }
}
