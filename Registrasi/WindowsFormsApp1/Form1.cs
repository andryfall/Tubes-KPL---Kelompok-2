using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public enum RegistrationType
        {
            Default,
            Admin
        }
        String masuk;
        public static string[] existingUsernames = new string[0];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ui = comboBox1.Text;
            RegisterUser(textBox1.Text, textBox2.Text, textBox3.Text, ui);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            masuk = textBox1.Text; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            masuk = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            masuk = textBox3.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(RegistrationType));
        }
        public static void RegisterUser(string username, string password, string confirmpassword, string registrationTypeInput)
        {

            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(username), "Username cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(password), "Password cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(confirmpassword), "Confirmation password cannot be empty.");
            Contract.Requires<ArgumentException>(password == confirmpassword, "Password and confirmation password must match.");
            RegistrationType registrationType;
            Contract.Requires<ArgumentException>(Enum.TryParse(registrationTypeInput, out registrationType), "Invalid registration type.");

            // Perform additional validation if needed

            if (ValidateRegistration(username, password, registrationType))
            {
                MessageBox.Show("Registrasi berhasil!");
            }
            else
            {
                MessageBox.Show("Registrasi gagal, coba lagi.");
            }
        }

        public static bool ValidateRegistration(string username, string password, RegistrationType registrationType)
        {
            // Perform any additional validation or checks here
            if (Array.Exists(existingUsernames, u => u.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Username sudah ada.");
                return false;
            }

            return true;
        }
    }
}
