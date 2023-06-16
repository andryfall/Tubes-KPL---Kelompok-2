using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections;
using daftarEvent;
using Repository;

namespace Function
{
    public class EventUI<T> where T : Event
    {
        AppConfig App = new AppConfig();
        private eventList repository;
        private Func<T, string> titleFunc;
        private Func<T, DateTime> startDateFunc;
        private Func<T, DateTime> endDateFunc;
        private Func<T, string> descriptionFunc;

        public EventUI(eventList repository, Func<T, string> titleFunc, Func<T, DateTime> startDateFunc, Func<T, DateTime> endDateFunc, Func<T, string> descriptionFunc)
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
            if (endDateFunc == null)
            {
                throw new ArgumentNullException(nameof(startDateFunc), "End date tidak boleh kosong");
            }
            if (descriptionFunc == null)
            {
                throw new ArgumentNullException(nameof(descriptionFunc), "Deskripsi tidak boleh kosong");
            }

            this.repository = repository;
            this.titleFunc = titleFunc;
            this.startDateFunc = startDateFunc;
            this.endDateFunc = endDateFunc;
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

    }
}
