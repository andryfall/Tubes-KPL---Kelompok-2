using daftarEvent;

class Program
{
    public static void Main(string[] args)
    {
        DateTime waktu = new DateTime();
        DateTime now = DateTime.Now;
        eventList e = new eventList();
        Event a;
        //Event yang sudah lewat
        e.addEvent(a = new Event("Acara 1", waktu = now.AddHours(-6), waktu = now.AddHours(-4), "Des Acara 1"));
        e.addEvent(a = new Event("Acara 2", waktu = now.AddDays(-1), waktu = now.AddDays(-1).AddHours(3), "Des Acara 2"));
        e.addEvent(a = new Event("Acara 3", waktu = now.AddHours(-8), waktu = now.AddHours(-5), "Des Acara 3"));
        //Event yang sedang berlangsung
        e.addEvent(a = new Event("Acara 4", waktu = now.AddHours(-1), waktu = now.AddHours(3), "Des Acara 4"));
        e.addEvent(a = new Event("Acara 5", waktu = now.AddHours(-2), waktu = now.AddHours(2), "Des Acara 5"));
        e.addEvent(a = new Event("Acara 6", waktu = now, waktu = now.AddHours(3), "Des Acara 6"));
        //Event yang belum dimulai
        e.addEvent(a = new Event("Acara 7", waktu = now.AddDays(4), waktu = now.AddDays(4).AddHours(2), "Des Acara 7"));
        e.addEvent(a = new Event("Acara 8", waktu = now.AddHours(5), waktu = now.AddHours(6), "Des Acara 8"));
        e.addEvent(a = new Event("Acara 9", waktu = now.AddDays(3).AddHours(-3), waktu = now.AddDays(3).AddHours(1), "Des Acara 9"));

        daftarEventUI d = new daftarEventUI(e);

        d.runApp();
    }
}