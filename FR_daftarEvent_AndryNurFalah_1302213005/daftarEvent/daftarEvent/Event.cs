using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    public class Event
    {
        //Penambahan design by Contract
        
        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Description { get; set; }

        public Event() { }
        public Event(String title, DateTime startDate, DateTime endDate, String description)
        {
            Debug.Assert(title != null, "Title tidak boleh kosong");
            Debug.Assert(description != null, "Deskripsi tidak boleh kosong");
            Debug.Assert(startDate < endDate, "Waktu mulai tidak boleh melebihi waktu berkakhir");
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

    }
}
