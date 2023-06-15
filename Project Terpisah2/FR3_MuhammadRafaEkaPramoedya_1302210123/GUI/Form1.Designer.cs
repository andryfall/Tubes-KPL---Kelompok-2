namespace GUI
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
            textBox1 = new TextBox();
            button1 = new Button();
            listBox1 = new ListBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(15, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(591, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(612, 15);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(17, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(589, 284);
            listBox1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(611, 58);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(113, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Search Judul";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(611, 88);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(111, 24);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Search Desc";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(612, 122);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Update Config";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 376);
            Controls.Add(button2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private ListBox listBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button2;
    }
}