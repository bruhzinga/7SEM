namespace _5
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(380, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1551, 1131);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 30);
            button1.Name = "button1";
            button1.Size = new Size(237, 48);
            button1.TabIndex = 1;
            button1.Text = "ВКЛ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnStart_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 84);
            button2.Name = "button2";
            button2.Size = new Size(237, 48);
            button2.TabIndex = 2;
            button2.Text = "ВЫКЛ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnStop_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 275);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(263, 120);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
    }
}