using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI3
{
    public partial class Form2 : Form
    {
        public string getAplikasi(string x)
        {
            string App = "Event Akan Terkirim Ke " + x;
            return App;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button instagram = (Button)sender;
            string hasil = getAplikasi(instagram.Text.ToString());
            MessageBox.Show(hasil);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button facebook = (Button)sender;
            string hasil = getAplikasi(facebook.Text.ToString());
            MessageBox.Show(hasil);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button whatsapp = (Button)sender;
            string hasil = getAplikasi(whatsapp.Text.ToString());
            MessageBox.Show(hasil);
        }
    }
}
