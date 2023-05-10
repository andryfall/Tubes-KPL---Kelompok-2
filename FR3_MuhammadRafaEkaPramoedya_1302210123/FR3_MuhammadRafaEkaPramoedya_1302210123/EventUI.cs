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

        // Display a list of events to the user
        public void DisplayEvents(List<T> events)
        {
            foreach (T e in events)
            {
                Console.WriteLine("{0} - {1} - {2}", titleFunc(e), startDateFunc(e).ToShortDateString(), descriptionFunc(e));
            }
        }

        // Prompt the user to enter a search query
        public string PromptForQuery()
        {
            Console.Write("Enter search query: ");
            return Console.ReadLine();
        }

        // Run the UI loop
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
