using FR3_MuhammadRafaEkaPramoedya_1302210123;
namespace GUI
{
    public partial class Form1 : Form
    {
        private EventRepos<Event> repository;
        private EventUI<Event> ui;
        private AppConfig appConfig;
        public Form1()
        {
            InitializeComponent();
            AppConfig App = new AppConfig();
            repository = new EventRepos<Event>();
            repository.Add(new Event { Title = "Webinar Kampus", StartDate = new DateTime(2023, 5, 14), Description = "Ayo ikuti webinar ini dapat TAK loh!" });
            repository.Add(new Event { Title = "Pendaftaran UKM", StartDate = new DateTime(2023, 6, 1), Description = "Pendaftaran UKM kembali dibuka ayo buruan daftar!" });
            repository.Add(new Event { Title = "Pendaftaran Lomba", StartDate = new DateTime(2023, 6, 1), Description = "Pendaftaran Lomba kembali dibuka ayo buruan daftar!" });
            repository.Add(new Event { Title = "Webinar UKM", StartDate = new DateTime(2023, 6, 1), Description = "Pendaftaran Webinar kembali dibuka ayo buruan daftar!" });
            repository.Add(new Event { Title = "Workshop UKM", StartDate = new DateTime(2023, 6, 1), Description = "Workshop UKM kembali dibuka ayo buruan daftar!" });
            repository.Add(new Event { Title = "Workshop Kampus", StartDate = new DateTime(2023, 6, 1), Description = "Pendaftaran Workshop kembali dibuka ayo buruan daftar!" });

            Func<Event, string> getTitle = e => e.Title;
            Func<Event, DateTime> getStartDate = e => e.StartDate;
            Func<Event, string> getDescription = e => e.Description;

            ui = new EventUI<Event>(repository, getTitle, getStartDate, getDescription);
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
    }
}