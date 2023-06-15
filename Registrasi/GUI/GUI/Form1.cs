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
    public partial class Form1 : Form
    {
        String input;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            input = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = " Username :";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "Password  :";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "Password  :";
        }
    }
}
