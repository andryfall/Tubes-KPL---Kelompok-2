using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Event
    {
        //Penambahan design by Contract

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string DisplayText => $"{Title} - {Description}";

        public Event() { }
        public Event(string title, DateTime startDate, DateTime endDate, string description)
        {
            Debug.Assert(title != null, "Title tidak boleh kosong");
            Debug.Assert(description != null, "Deskripsi tidak boleh kosong");
            Debug.Assert(startDate < endDate, "Waktu mulai tidak boleh melebihi waktu berkakhir");
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        public string getTitle()
        {
            return Title;
        }

        public DateTime getStartDate()
        {
            return StartDate;
        }

        public DateTime getEndDate()
        {
            return EndDate;
        }

        public string getDescription()
        {
            return Description;
        }

    }
}
