
using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    public class daftarEventUI
    {
        private repoMyEvents repoMyEvent;
        public daftarEventUI() {
            repoMyEvent = repoMyEvents.getInstance();
        }

        public List<Event> sortByStartDate(List<Event> l)
        {
            List<Event> t = l;
            t.Sort((x, y) => x.StartDate.CompareTo(y.StartDate));
            repoMyEvent.setEvents(t);
            return t;
        }

    }

    
}
