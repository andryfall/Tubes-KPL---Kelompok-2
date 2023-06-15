using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            String password2 = textBox3.Text;
            if (password != confirmPassword)
            {
                MessageBox.Show("Password tidak sesuai.");
                return;
            }

            if (!Enum.TryParse(comboBox1.SelectedItem.ToString(), out RegistrationType registrationType))
            {
                MessageBox.Show("Pilihan tipe registrasi tidak valid.");
                return;
            }

            if (ValidateRegistration(username, password, registrationType))
            {
                MessageBox.Show("Registrasi berhasil!");
            }
            else
            {
                MessageBox.Show("Registrasi gagal, coba lagi.");
            }
        }
    }
}
