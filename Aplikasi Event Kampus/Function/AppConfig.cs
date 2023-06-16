using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Function
{
    public class AppConfig
    {
        public EventUIConfig config;

        private const string filelocation = "C:\\Users\\andry\\Documents\\GitHub\\Tubes-KPL---Kelompok-2\\Aplikasi Event Kampus\\Function";
        private const string filepath = filelocation + "EventConfig.json";

        public AppConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                setDefault();
                WriteNewConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            try
            {
                string result = File.ReadAllText(filepath);
                config = JsonSerializer.Deserialize<EventUIConfig>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading configuration file:");
                Console.WriteLine(ex.Message);
                setDefault();
                WriteNewConfigFile();
            }
        }

        public class JsonConfig
        {
            public EventUIConfig EventUIConfig { get; set; }
        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, jsonString);
        }

        private void setDefault()
        {
            config = new EventUIConfig(true, true);

        }

        public class EventUIConfig
        {
            public bool SearchByTitle { get; set; }
            public bool SearchByDescription { get; set; }

            public EventUIConfig(bool searchByTitle, bool searchByDescription)
            {
                SearchByTitle = searchByTitle;
                SearchByDescription = searchByDescription;
            }
        }
    }
}
