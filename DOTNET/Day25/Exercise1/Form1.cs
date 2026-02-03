using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string res = String.Empty;
            res += "Person Name: " + textBox1.Text + "\n" + "Father's Name: " + textBox2.Text + "\n" + "DateOfBirth: " + dateTimePicker1.Text + "\nPreferences: " + comboBox1.Text;
            MessageBox.Show(res,"Form");
        }
    }
}
