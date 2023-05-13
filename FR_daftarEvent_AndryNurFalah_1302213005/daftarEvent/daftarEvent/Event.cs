using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    internal class Event
    {
        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Description { get; set; }

        public Event(String title, DateTime startDate, DateTime endDate, String description)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
        
    }
}
