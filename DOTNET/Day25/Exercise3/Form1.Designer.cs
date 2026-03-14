namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelCountry = new Label();
            labelState = new Label();
            postalMailCheckBox = new CheckBox();
            emailCheckbox = new CheckBox();
            radioButtonMale = new RadioButton();
            radioButtonFemale = new RadioButton();
            stateDropDown = new ComboBox();
            btnAddCountryAndState = new Button();
            btnRemoveCountry = new Button();
            btnRemoveState = new Button();
            btnShowDetails = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new Point(78, 53);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(75, 25);
            labelCountry.TabIndex = 0;
            labelCountry.Text = "Country";
            // 
            // labelState
            // 
            labelState.AutoSize = true;
            labelState.Location = new Point(78, 97);
            labelState.Name = "labelState";
            labelState.Size = new Size(51, 25);
            labelState.TabIndex = 1;
            labelState.Text = "State";
            // 
            // postalMailCheckBox
            // 
            postalMailCheckBox.AutoSize = true;
            postalMailCheckBox.Location = new Point(80, 157);
            postalMailCheckBox.Name = "postalMailCheckBox";
            postalMailCheckBox.Size = new Size(123, 29);
            postalMailCheckBox.TabIndex = 2;
            postalMailCheckBox.Text = "Postal Mail";
            postalMailCheckBox.UseVisualStyleBackColor = true;
            // 
            // emailCheckbox
            // 
            emailCheckbox.AutoSize = true;
            emailCheckbox.Location = new Point(80, 205);
            emailCheckbox.Name = "emailCheckbox";
            emailCheckbox.Size = new Size(87, 29);
            emailCheckbox.TabIndex = 3;
            emailCheckbox.Text = "E-Mail";
            emailCheckbox.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            radioButtonMale.AutoSize = true;
            radioButtonMale.Location = new Point(264, 157);
            radioButtonMale.Name = "radioButtonMale";
            radioButtonMale.Size = new Size(75, 29);
            radioButtonMale.TabIndex = 4;
            radioButtonMale.TabStop = true;
            radioButtonMale.Text = "Male";
            radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            radioButtonFemale.AutoSize = true;
            radioButtonFemale.Location = new Point(264, 205);
            radioButtonFemale.Name = "radioButtonFemale";
            radioButtonFemale.Size = new Size(93, 29);
            radioButtonFemale.TabIndex = 5;
            radioButtonFemale.TabStop = true;
            radioButtonFemale.Text = "Female";
            radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // stateDropDown
            // 
            stateDropDown.FormattingEnabled = true;
            stateDropDown.Location = new Point(459, 226);
            stateDropDown.Name = "stateDropDown";
            stateDropDown.Size = new Size(276, 33);
            stateDropDown.TabIndex = 7;
            // 
            // btnAddCountryAndState
            // 
            btnAddCountryAndState.Location = new Point(78, 283);
            btnAddCountryAndState.Name = "btnAddCountryAndState";
            btnAddCountryAndState.Size = new Size(81, 34);
            btnAddCountryAndState.TabIndex = 8;
            btnAddCountryAndState.Text = "Add";
            btnAddCountryAndState.UseVisualStyleBackColor = true;
            btnAddCountryAndState.Click += btnAddCountryAndState_Click;
            // 
            // btnRemoveCountry
            // 
            btnRemoveCountry.Location = new Point(211, 283);
            btnRemoveCountry.Name = "btnRemoveCountry";
            btnRemoveCountry.Size = new Size(163, 34);
            btnRemoveCountry.TabIndex = 9;
            btnRemoveCountry.Text = "Remove Country";
            btnRemoveCountry.UseVisualStyleBackColor = true;
            btnRemoveCountry.Click += btnRemoveCountry_Click;
            // 
            // btnRemoveState
            // 
            btnRemoveState.Location = new Point(417, 283);
            btnRemoveState.Name = "btnRemoveState";
            btnRemoveState.Size = new Size(163, 34);
            btnRemoveState.TabIndex = 10;
            btnRemoveState.Text = "Remove State";
            btnRemoveState.UseVisualStyleBackColor = true;
            btnRemoveState.Click += btnRemoveState_Click;
            // 
            // btnShowDetails
            // 
            btnShowDetails.Location = new Point(605, 283);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(149, 34);
            btnShowDetails.TabIndex = 11;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = true;
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(185, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 31);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(185, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(189, 31);
            textBox2.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(459, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(276, 163);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 39);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(276, 116);
            checkedListBox1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 16);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 7;
            label1.Text = "Country";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnShowDetails);
            Controls.Add(btnRemoveState);
            Controls.Add(btnRemoveCountry);
            Controls.Add(btnAddCountryAndState);
            Controls.Add(stateDropDown);
            Controls.Add(radioButtonFemale);
            Controls.Add(radioButtonMale);
            Controls.Add(emailCheckbox);
            Controls.Add(postalMailCheckBox);
            Controls.Add(labelState);
            Controls.Add(labelCountry);
            Name = "Form1";
            Text = "Country Info";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCountry;
        private Label labelState;
        private CheckBox postalMailCheckBox;
        private CheckBox emailCheckbox;
        private RadioButton radioButtonMale;
        private RadioButton radioButtonFemale;
        private ComboBox stateDropDown;
        private Button btnAddCountryAndState;
        private Button btnRemoveCountry;
        private Button btnRemoveState;
        private Button btnShowDetails;
        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private Label label1;
        private CheckedListBox checkedListBox1;
    }
}
