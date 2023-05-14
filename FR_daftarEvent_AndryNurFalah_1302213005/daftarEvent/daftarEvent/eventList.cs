using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    public class eventList
    {
        public List<Event> events = new List<Event>();

        public eventList()
        {
        }

        public void addEvent(Event e)
        {
            Debug.Assert(e != null, "Data event tidak boleh kosong");
            events.Add(e);
        }

    }
}
