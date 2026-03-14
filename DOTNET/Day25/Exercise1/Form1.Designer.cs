namespace WinFormsApp1
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 88);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 0;
            label1.Text = "Person Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(372, 88);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter your name";
            textBox1.Size = new Size(227, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 141);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 2;
            label2.Text = "Father's Name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(372, 141);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter father's name";
            textBox2.Size = new Size(227, 31);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 198);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 4;
            label3.Text = "DateOfBirth";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(372, 198);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(227, 31);
            dateTimePicker1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 257);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 6;
            label4.Text = "Preferences";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Stocks", "Mutual Funds", "Bonds", "Real Estate" });
            comboBox1.Location = new Point(372, 259);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(227, 33);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Font = new Font("Segoe UI Historic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(64, 0, 64);
            button1.Location = new Point(334, 336);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Person Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private ComboBox comboBox1;
        private Button button1;
    }
}
