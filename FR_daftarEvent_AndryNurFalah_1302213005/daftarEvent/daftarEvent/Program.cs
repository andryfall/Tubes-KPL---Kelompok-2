using daftarEvent;

class Program
{
    static void Main(string[] args)
    {
        DateTime waktu;
        eventList e = new eventList();
        Event a;
        e.addEvent(a = new Event("Acara 1", waktu = new DateTime(2023, 5, 1, 9, 0, 0), waktu = new DateTime(2023, 5, 1, 11, 0, 0), "Des Acara 1"));
        e.addEvent(a = new Event("Acara 2", waktu = new DateTime(2023, 7, 2, 8, 0, 0), waktu = new DateTime(2023, 7, 2, 12, 0, 0), "Des Acara 2"));
        e.addEvent(a = new Event("Acara 3", waktu = new DateTime(2023, 5, 4, 6, 0, 0), waktu = new DateTime(2023, 5, 4, 9, 0, 0), "Des Acara 3"));
        e.addEvent(a = new Event("Acara 4", waktu = new DateTime(2023, 5, 1, 11, 0, 0), waktu = new DateTime(2023, 5, 1, 14, 0, 0), "Des Acara 4"));

        Console.WriteLine(e.events.Count);
        daftarEventUI d = new daftarEventUI(e);

        d.runApp();
    }
}