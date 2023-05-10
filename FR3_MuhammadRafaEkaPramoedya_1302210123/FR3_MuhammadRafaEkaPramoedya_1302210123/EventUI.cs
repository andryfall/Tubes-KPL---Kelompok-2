using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR3_MuhammadRafaEkaPramoedya_1302210123
{
    public class EventUI<T> where T : Event
    {
        private EventRepos<T> repository;
        private Func<T, string> titleFunc;
        private Func<T, DateTime> startDateFunc;
        private Func<T, string> descriptionFunc;

        public EventUI(EventRepos<T> repository, Func<T, string> titleFunc, Func<T, DateTime> startDateFunc, Func<T, string> descriptionFunc)
        {
            this.repository = repository;
            this.titleFunc = titleFunc;
            this.startDateFunc = startDateFunc;
            this.descriptionFunc = descriptionFunc;
        }

        // Menampilkan List Event
        public void DisplayEvents(List<T> events)
        {
            foreach (T e in events)
            {
                Console.WriteLine("{0} - {1} - {2}", titleFunc(e), startDateFunc(e).ToShortDateString(), descriptionFunc(e));
            }
        }

        // Meminta Input User
        public string PromptForQuery()
        {
            Console.Write("Masukkan Nama Event: ");
            return Console.ReadLine();
        }

        // Run 
        public void Run()
        {
            while (true)
            {
                string query = PromptForQuery();
                List<T> events = repository.Search(e => titleFunc(e).Contains(query) || descriptionFunc(e).Contains(query));
                DisplayEvents(events);
            }
        }
    }
}
