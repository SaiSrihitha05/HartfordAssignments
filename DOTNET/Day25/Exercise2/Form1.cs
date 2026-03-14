namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Your Age is: ";
            DateTime today = DateTime.Today;
            label2.Text += (today-dateTimePicker1.Value).Days/365+" Years";
        }
    }
}
