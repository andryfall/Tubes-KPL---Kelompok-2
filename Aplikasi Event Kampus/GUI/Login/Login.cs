using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Repository;
using GUI;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUser(textBox1.Text, textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoginUser(String username, String pass)
        {
            List<User> existingUsernames;
            RegisteredUser repoUser = RegisteredUser.getInstance();
            existingUsernames = repoUser.getUsers();

            foreach (User user in existingUsernames)
            {
                if(user.Username == username)
                {
                    this.Hide();
                    Homepage form = new Homepage();
                    form.ShowDialog();
                    break;
                }
            }
            MessageBox.Show("Username atau password salah");
        }
    }
}
