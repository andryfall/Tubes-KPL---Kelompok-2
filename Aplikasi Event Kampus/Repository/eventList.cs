using Repository;
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
        private List<Event> events = new List<Event>();

        public eventList()
        {
            DateTime waktu = new DateTime();
            DateTime now = DateTime.Now;
            Event a;
            //Event yang sudah lewat
            addEvent(a = new Event("Acara 1", waktu = now.AddHours(-6), waktu = now.AddHours(-4), "Des Acara 1"));
            addEvent(a = new Event("Acara 2", waktu = now.AddDays(-1), waktu = now.AddDays(-1).AddHours(3), "Des Acara 2"));
            addEvent(a = new Event("Acara 3", waktu = now.AddHours(-8), waktu = now.AddHours(-5), "Des Acara 3"));
            //Event yang sedang berlangsung
            addEvent(a = new Event("Acara 4", waktu = now.AddHours(-1), waktu = now.AddHours(3), "Des Acara 4"));
            addEvent(a = new Event("Acara 5", waktu = now.AddHours(-2), waktu = now.AddHours(2), "Des Acara 5"));
            addEvent(a = new Event("Acara 6", waktu = now, waktu = now.AddHours(3), "Des Acara 6"));
            //Event yang belum dimulai
            addEvent(a = new Event("Acara 7", waktu = now.AddDays(4), waktu = now.AddDays(4).AddHours(2), "Des Acara 7"));
            addEvent(a = new Event("Acara 8", waktu = now.AddHours(5), waktu = now.AddHours(6), "Des Acara 8"));
            addEvent(a = new Event("Acara 9", waktu = now.AddDays(3).AddHours(-3), waktu = now.AddDays(3).AddHours(1), "Des Acara 9"));
            
        }
        public void addEvent(Event e)
        {
            Debug.Assert(e != null, "Data event tidak boleh kosong");
            events.Add(e);
        }

        public List<Event> getEvents()
        {
            return events;
        }

        public List<Event> Search(Func<Event, bool> predicate)
        {
            return events.Where(predicate).ToList();
        }
    }
}
