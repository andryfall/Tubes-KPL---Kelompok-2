using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections;

namespace FR3_MuhammadRafaEkaPramoedya_1302210123
{
    public class EventUI<T> where T : Event
    {
        AppConfig App = new AppConfig();
        private EventRepos<T> repository;
        private Func<T, string> titleFunc;
        private Func<T, DateTime> startDateFunc;
        private Func<T, string> descriptionFunc;

        public EventUI(EventRepos<T> repository, Func<T, string> titleFunc, Func<T, DateTime> startDateFunc, Func<T, string> descriptionFunc)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository), "Repository tidak boleh kosong");
            }
            if (titleFunc == null)
            {
                throw new ArgumentNullException(nameof(titleFunc), "Judul tidak boleh kosong");
            }
            if (startDateFunc == null)
            {
                throw new ArgumentNullException(nameof(startDateFunc), "Start date tidak boleh kosong");
            }
            if (descriptionFunc == null)
            {
                throw new ArgumentNullException(nameof(descriptionFunc), "Deskripsi tidak boleh kosong");
            }

            this.repository = repository;
            this.titleFunc = titleFunc;
            this.startDateFunc = startDateFunc;
            this.descriptionFunc = descriptionFunc;
            AppConfig App = new AppConfig();
        }

        public void DisplayEvents(List<T> events)
        {
            foreach (T e in events)
            {
                Console.WriteLine("{0} - {1} - {2}", titleFunc(e), startDateFunc(e).ToShortDateString(), descriptionFunc(e));
            }
        }

        public string Input()
        {
            Console.Write("Masukkan nama event: ");
            string query = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query tidak boleh kosong", nameof(query));
            }

            return query;
        }

        public void Run()
{
    List<T> events = repository.Search(e => true);
    DisplayEvents(events);

    while (true)
    {
        Console.WriteLine("1. Cari Judul");
        Console.WriteLine("2. Cari Deskripsi");
        Console.WriteLine("3. Cari judul / desk");
        Console.WriteLine("4. Keluar");
        Console.Write("Pilih 1-3: ");
        string choice = Console.ReadLine();

        if (choice == "4")
            break;

        string query = Input();

        bool searchByTitle = choice == "1" || choice == "3";
        bool searchByDescription = choice == "2" || choice == "3";

        if (searchByTitle != App.config.SearchByTitle || searchByDescription != App.config.SearchByDescription)
        {
            App.config.SearchByTitle = searchByTitle;
            App.config.SearchByDescription = searchByDescription;
            App.WriteNewConfigFile();
            Console.WriteLine("Configuration updated.");
        }

        events = repository.Search(e =>
            (searchByTitle && titleFunc(e).Contains(query)) ||
            (searchByDescription && descriptionFunc(e).Contains(query)));

        DisplayEvents(events);
    }
}

    }
}
