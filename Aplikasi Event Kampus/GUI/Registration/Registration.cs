using daftarEventLibraries;
using GUI;
using Repository;
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
    public partial class Registration : Form
    {
        public enum RegistrationType
        {
            Default,
            Admin
        }
        string masuk;
        string nama;
        string pass;
        string confirm;
        
        public Registration()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ui = comboBox1.Text;
            nama = textBox1.Text;
            pass = textBox2.Text;
            confirm = textBox3.Text;
            RegisterUser(nama, pass, confirm, ui);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nama = textBox1.Text; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pass = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            confirm = textBox3.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(RegistrationType));
        }
        public static void RegisterUser(string username, string password, string confirmpassword, string registrationTypeInput)
        {
            RegisteredUser repoUser = RegisteredUser.getInstance();

            Contract.Assert(username != "");
            Contract.Assert(password != "");
            Contract.Assert(confirmpassword != "");
            Contract.Assert(password == confirmpassword);
            

            // Perform additional validation if needed

            if (ValidateRegistration(username, password))
            {
                MessageBox.Show("Registrasi berhasil!");
                User user = new User(username, password);
                repoUser.addUser(user);
                Registration.next();
                
            }
            else
            {
                MessageBox.Show("Registrasi gagal, coba lagi.");
            }
        }

        public static void next()
        {
            Registration r = new Registration();
            r.Hide();
            Login form = new Login();
            form.Show();
        }

        public static bool ValidateRegistration(string username, string password)
        {
            List<User> existingUsernames;
            RegisteredUser repoUser = RegisteredUser.getInstance();
            existingUsernames = repoUser.getUsers();
            foreach (User e in existingUsernames)
            {
                if (e.Username.Equals(username))
                {
                    MessageBox.Show("Username sudah ada.");
                    return false;
                }
            }

            return true;
        }
    }
}
