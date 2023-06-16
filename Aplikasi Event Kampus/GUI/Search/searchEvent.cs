using daftarEvent;
using Function;
using GUI3;
using Repository;

namespace GUI
{
    public partial class searchEvent : Form
    {
        private eventList repository;
        private EventUI<Event> ui;
        private AppConfig appConfig;
        private repoMyEvents repoMyEvent;
        public searchEvent()
        {
            InitializeComponent();
            AppConfig App = new AppConfig();
            repository = new eventList();
            repoMyEvent = repoMyEvents.getInstance();

            Func<Event, string> getTitle = e => e.Title;
            Func<Event, DateTime> getStartDate = e => e.StartDate;
            Func<Event, DateTime> getEndDate = e => e.EndDate;
            Func<Event, string> getDescription = e => e.Description;

            ui = new EventUI<Event>(repository, getTitle, getStartDate, getEndDate, getDescription);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Event> allEvents = repository.Search(ev => true);
            ui.DisplayEvents(allEvents);

            listBox1.DataSource = allEvents;
            listBox1.DisplayMember = "DisplayText";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppConfig App = new AppConfig();
            listBox1.DataSource = null;

            bool searchByName = App.config.SearchByTitle && checkBox1.Checked;
            bool searchByDescription = App.config.SearchByDescription && checkBox2.Checked;
            bool searchByBoth = searchByName && searchByDescription;

            string query = textBox1.Text.ToLower();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Input tidak boleh kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Event> events;
            if (searchByName && searchByDescription)
            {
                events = repository.Search(ev =>
                    ev.Title.ToLower().Contains(query) ||
                    ev.Description.ToLower().Contains(query));
            }
            else if (searchByName)
            {
                events = repository.Search(ev => ev.Title.ToLower().Contains(query));
            }
            else if (searchByDescription)
            {
                events = repository.Search(ev => ev.Description.ToLower().Contains(query));
            }
            else
            {
                events = new List<Event>();
            }

            ui.DisplayEvents(events);

            listBox1.DataSource = events;
            listBox1.DisplayMember = "DisplayText";
            if (events.Count == 0)
            {
                MessageBox.Show($"Tidak ada event dengan nama atau deskripsi '{textBox1.Text}'", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppConfig App = new AppConfig();
            App.config.SearchByTitle = checkBox1.Checked;
            App.config.SearchByDescription = checkBox2.Checked;
            App.WriteNewConfigFile();
            MessageBox.Show("Configuration updated.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event p = (Event)listBox1.SelectedItem;

            if (p == null)
            {
                label2.Text = "" + string.Empty;
                label3.Text = "" + string.Empty;
                label4.Text = "" + string.Empty;
            }
            else
            {
                label2.Text = "" + p.Description;
                label3.Text = "" + p.StartDate;
                label4.Text = "" + p.EndDate;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage form = new Homepage();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Event p = (Event)listBox1.SelectedItem;
            repoMyEvent.Add(p);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Share form = new Share();
            form.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Share form = new Share();
            form.ShowDialog();
        }
    }
}