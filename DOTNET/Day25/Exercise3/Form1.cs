namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnAddCountryAndState_Click(object sender, EventArgs e)
        {
            string country = textBox1.Text;
            string state = textBox2.Text;
            checkedListBox1.Items.Add(country);
            stateDropDown.Items.Add(state);
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private void btnRemoveCountry_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.CheckedItems.Count - 1; i >= 0; i--)
            {
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[i]);
            }
        }

        private void btnRemoveState_Click(object sender, EventArgs e)
        {
            string a = stateDropDown.Text;
            stateDropDown.Items.Remove(a);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            string res = String.Empty;
            res += "hello ";
            if (radioButtonMale.Checked)
            {
                res += " "+radioButtonMale.Text;
            }
            if (radioButtonFemale.Checked)
            {
                res += " " + radioButtonFemale.Text;
            }
            if (postalMailCheckBox.Checked)
            {
                res += " " + postalMailCheckBox.Text;
            }
            if (emailCheckbox.Checked)
            {
                res += " " + emailCheckbox.Text;
            }
            MessageBox.Show(res,"Information",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }
    }
}       
