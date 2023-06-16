using daftarEvent;
using daftarEventLibraries;
using Function;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class myEvents : Form
    {
        private eventList repository;
        private EventUI<Event> ui;
        private repoMyEvents repoMyEvent;
        private daftarEventUI sort = new daftarEventUI();
        public myEvents()
        {
            InitializeComponent();
            repository = new eventList();
            repoMyEvent = repoMyEvents.getInstance();

            Func<Event, string> getTitle = e => e.Title;
            Func<Event, DateTime> getStartDate = e => e.StartDate;
            Func<Event, DateTime> getEndDate = e => e.EndDate;
            Func<Event, string> getDescription = e => e.Description;

            ui = new EventUI<Event>(repository, getTitle, getStartDate, getEndDate, getDescription);
        }

        private void myEvents_load(object sender, EventArgs e)
        {
            List<Event> allEvents = repoMyEvent.GetEvents();
            ui.DisplayEvents(allEvents);

            listBox1.DataSource = allEvents;
            listBox1.DisplayMember = "DisplayText";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event p = (Event)listBox1.SelectedItem;

            if (p == null)
            {
                label2.Text = "" + string.Empty;
                label3.Text = "" + string.Empty;
                label4.Text = "" + string.Empty;
                label1.Text = "" + string.Empty;
            }
            else
            {
                label2.Text = "" + p.Description;
                label3.Text = "" + p.StartDate;
                label4.Text = "" + p.EndDate;
                label1.Text = "Status : " + statusEvent.cekStatus(p.StartDate, p.EndDate);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage form = new Homepage();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Event> allEvents = repoMyEvent.GetUpcomingEvents();
            ui.DisplayEvents(allEvents);

            listBox1.DataSource = allEvents;
            listBox1.DisplayMember = "DisplayText";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Event> allEvents = repoMyEvent.GetUOngoingEvents();
            ui.DisplayEvents(allEvents);

            listBox1.DataSource = allEvents;
            listBox1.DisplayMember = "DisplayText";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Event> allEvents = repoMyEvent.GetFinishedEvents();
            ui.DisplayEvents(allEvents);

            listBox1.DataSource = allEvents;
            listBox1.DisplayMember = "DisplayText";
        }
    }
}
