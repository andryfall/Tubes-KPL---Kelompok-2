using System;
using daftarEvent;
using daftarEventLibrary;

namespace UnitTestDaftarEvent
{
    [TestClass]
    public class TesDaftarProgram
    {
        DateTime waktu = new DateTime();
        DateTime now = DateTime.Now;
        eventList e = new eventList();

        [TestMethod]
        public void TestingAddEventPadaLEventList()
        {
            Event a = new Event("Acara 1", waktu = now.AddHours(-6), waktu = now.AddHours(-4), "Des Acara 1");

            e.addEvent(a);

            List<Event> list = e.events;

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(list[0], a);

        }
        [TestMethod]
        public void addEventFromMyEvents()
        {
            Event a = new Event("Acara 1", waktu = now.AddHours(-6), waktu = now.AddHours(-4), "Des Acara 1");

            e.addEvent(a);


            daftarEventUI d = new daftarEventUI(e);


            d.addToMyEvents(1);

            Assert.AreEqual(d.myEvents[0], a);

        }
        [TestMethod]
        public void deleteEventFromMyEvents()
        {
            Event a = new Event("Acara 1", waktu = now.AddHours(-6), waktu = now.AddHours(-4), "Des Acara 1");
            Event b = new Event("Acara 5", waktu = now.AddHours(-2), waktu = now.AddHours(2), "Des Acara 5");

            e.addEvent(a);
            e.addEvent(b);

            List<Event> list = e.events;

            daftarEventUI d = new daftarEventUI(e);


            d.addToMyEvents(1);
            d.addToMyEvents(2);

            d.deleteFromMyEvents(1);

            CollectionAssert.DoesNotContain(d.myEvents, a);
            Assert.AreEqual(d.myEvents[0], list[1]) ;

        }
        [TestMethod]
        public void methodLibrary()
        {
            //Waktu yang sudah lewat
            DateTime LewatStart = now.AddHours(-6);
            DateTime LewatEnd = now.AddHours(-4);
            //Waktu yang sedang berlangsung
            DateTime SedangStart = now.AddHours(-1);
            DateTime SedangEnd = now.AddHours(3);
            //Waktu yang belum dimulai
            DateTime BelumStart = now.AddDays(3).AddHours(-3);
            DateTime BelumEnd = now.AddDays(3).AddHours(1);

            String lewat = status.statusEvent(LewatStart, LewatEnd);

            String sedang = status.statusEvent(SedangStart, SedangEnd);

            String belum = status.statusEvent(BelumStart, BelumEnd);

            Assert.AreEqual(lewat, "Berakhir");
            Assert.AreEqual(sedang, "Sedang Berlangsung");
            Assert.AreEqual(belum, "Terjadwal");
        }

    }
}