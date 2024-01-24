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
            button1 = new Button();
            pictureBox = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 29);
            button1.Name = "button1";
            button1.Size = new Size(213, 52);
            button1.TabIndex = 0;
            button1.Text = "Выбрать изображение";
            button1.UseVisualStyleBackColor = true;
            button1.Click += LoadImageBtn_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(231, 29);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(879, 693);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(12, 103);
            button2.Name = "button2";
            button2.Size = new Size(213, 52);
            button2.TabIndex = 2;
            button2.Text = "Харрис";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DetectCornersBtn_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 263);
            button3.Name = "button3";
            button3.Size = new Size(213, 52);
            button3.TabIndex = 3;
            button3.Text = "поворот";
            button3.UseVisualStyleBackColor = true;
            button3.Click += RotateImageBtn_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 178);
            button4.Name = "button4";
            button4.Size = new Size(213, 52);
            button4.TabIndex = 4;
            button4.Text = "Томаси";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DetectCornersWithTomasi;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 746);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}