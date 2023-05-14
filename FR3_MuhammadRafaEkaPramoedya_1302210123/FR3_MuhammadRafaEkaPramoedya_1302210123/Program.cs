using FR3_MuhammadRafaEkaPramoedya_1302210123;

class Program
{
    static void Main(string[] args)
    {
        EventRepos<Event> repository = new EventRepos<Event>();
        repository.Add(new Event { Title = "Webinar Kampus", StartDate = new DateTime(2023, 5, 14), Description = "Ayo ikuti webinar ini dapat TAK loh!" });
        repository.Add(new Event { Title = "Pendaftaran UKM", StartDate = new DateTime(2023, 6, 1), Description = "Pendaftaran UKM kembali dibuka ayo buruan daftar!" });
        Func<Event, DateTime> getStartDate = e => e.StartDate;
        // Testing defensive programming
        try
        {
            EventUI<Event> ui = new EventUI<Event>(repository, e => e.Title, getStartDate, e => e.Description);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("ArgumentNullException: {0}", ex.Message);
        }

        // Testing defensive programming
        EventUI<Event> ui2 = new EventUI<Event>(repository, e => e.Title, e => e.StartDate, e => e.Description);
        try
        {
            string query = ui2.PromptForQuery();
            Console.WriteLine("User query: {0}", query);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("ArgumentException: {0}", ex.Message);
        }

        ui2.Run();
    }
}