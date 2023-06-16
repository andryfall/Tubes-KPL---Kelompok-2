using daftarEventLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class repoMyEvents
    {
        private List<Event> myEventsList = new List<Event>();
        private List<Event> UpcomingEvents;
        private List<Event> OngoingEvents;
        private List<Event> FinishedEvents;

        private repoMyEvents() { }

        private static repoMyEvents _instance;
        public static repoMyEvents getInstance()
        {
            if(_instance == null)
            {
                _instance = new repoMyEvents();
            }
            return _instance;
        }

        public void Add(Event e) { myEventsList.Add(e); }
        public void Remove(Event e) { myEventsList.Remove(e); }
        public  List<Event> GetEvents() {  return myEventsList; }
        public List<Event> GetUpcomingEvents()
        {
            UpcomingEvents = new List<Event> { };
            foreach (Event e in myEventsList)
            {
                if (statusEvent.cekStatus(e.StartDate, e.EndDate) == "Terjadwal")
                {
                    UpcomingEvents.Add(e);
                }
            }
            return UpcomingEvents;
        }

        public List<Event> GetUOngoingEvents()
        {
            OngoingEvents = new List<Event>();
            foreach (Event e in myEventsList)
            {
                if (statusEvent.cekStatus(e.StartDate, e.EndDate) == "Sedang Berlangsung")
                {
                    OngoingEvents.Add(e);
                }
            }
            return OngoingEvents;
        }

        public List<Event> GetFinishedEvents()
        {
            FinishedEvents = new List<Event>();
            foreach (Event e in myEventsList)
            {
                if (statusEvent.cekStatus(e.StartDate, e.EndDate) == "Selesai")
                {
                    FinishedEvents.Add(e);
                }
            }
            return FinishedEvents;
        }
        public void setEvents(List<Event> events) {  myEventsList = events; }



    }
}
