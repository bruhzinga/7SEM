using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.Util;

namespace ObjectDetection
{
    public partial class Form1 : Form
    {

        private Image<Bgr, byte> image;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(openFileDialog.FileName);
                pictureBox.Image = image.ToBitmap();
            }
        }

        private void DetectObjectsBtn_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Сначала загрузите изображение.");
                return;
            }

            // Преобразование изображения в градации серого
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Применение оператора Canny
            double cannyThreshold1 = 10;
            double cannyThreshold2 = 250;
            CvInvoke.Canny(grayImage, grayImage, cannyThreshold1, cannyThreshold2);
            

            // Применение операции морфологического закрытия
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
            CvInvoke.MorphologyEx(grayImage, grayImage, MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

            // Нахождение контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(grayImage, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                // Отрисовка контуров и нахождение контуров с наибольшей длиной и площадью
                double maxContourLength = 0;
                double maxContourArea = 0;
                int maxContourIndex = -1;

                for (int i = 0; i < contours.Size; i++)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    CvInvoke.Rectangle(image, rect, new MCvScalar(0, 0, 255), 2);

                    double length = CvInvoke.ArcLength(contours[i], true);
                    double area = CvInvoke.ContourArea(contours[i]);

                    if (length > maxContourLength)
                    {
                        maxContourLength = length;
                        maxContourIndex = i;
                    }

                    if (area > maxContourArea)
                    {
                        maxContourArea = area;
                    }
                }

                // Отображение результатов
                pictureBox.Image = image.ToBitmap();
                MessageBox.Show($"Количество контуров: {contours.Size}\n" +
                                $"Контур с наибольшей длиной: {maxContourLength}\n" +
                                $"Контур с наибольшей площадью: {maxContourArea}");
            }
        }

        private void CountRectanglesBtn_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Сначала загрузите изображение.");
                return;
            }

            // Преобразование изображения в градации серого
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Применение оператора Canny
            double cannyThreshold1 = 10;
            double cannyThreshold2 = 250;
            CvInvoke.Canny(grayImage, grayImage, cannyThreshold1, cannyThreshold2);

            // Применение операции морфологического закрытия
       

            // Нахождение контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(grayImage, contours, null, RetrType.External,
                    ChainApproxMethod.ChainApproxSimple);

                int rectangleCount = 0;

                for (int i = 0; i < contours.Size; i++)
                {

                    VectorOfPoint approxCurve = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contours[i], approxCurve, CvInvoke.ArcLength(contours[i], true) * 0.01,
                        true);


                    // Проверяем, является ли контур прямоугольником (четыре угла)
                    if (approxCurve.Size == 4)
                    {
                        rectangleCount++;
                        Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                        CvInvoke.Rectangle(image, rect, new MCvScalar(0, 0, 255), 2);
                    }
                }

                pictureBox.Image = image.ToBitmap();
                // Отображение результатов
                MessageBox.Show($"Количество прямоугольников: {rectangleCount}");
            }
        }

        private void FindLinesBtn_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Сначала загрузите изображение.");
                return;
            }

            // Преобразование изображения в градации серого
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Применение оператора Canny
            double cannyThreshold1 = 50;
            double cannyThreshold2 = 150;
            CvInvoke.Canny(grayImage, grayImage, cannyThreshold1, cannyThreshold2);
            //Draw the HoughLines on the image 
            LineSegment2D[] lines = CvInvoke.HoughLinesP(
                grayImage, // Исходное изображение
                1, // Разрешение
                Math.PI / 180, // Перевод в радианы
                100, // Минимальное количество пересечений для обнаружения линии
                20, // Минимальная длина линии
                10); // Максимальный зазор между двумя точками, чтобы рассматривать их как части одной линии

            foreach (LineSegment2D line in lines)
            {
                CvInvoke.Line(image, line.P1, line.P2, new MCvScalar(0, 255, 0), 2);
            }

            // Отображение результатов





            pictureBox.Image = image.ToBitmap();
        }

        private void FindCirclesBtn_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Сначала загрузите изображение.");
                return;
            }

            // Преобразование изображения в градации серого
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();
            double cannyThreshold1 = 50;
            double cannyThreshold2 = 150;
            CvInvoke.Canny(grayImage, grayImage, cannyThreshold1, cannyThreshold2);

            // Поиск окружностей методом Хафа
            CircleF[] circles = CvInvoke.HoughCircles(
                grayImage,
                HoughModes.Gradient, // Тип метода Хафа
                1, // Разрешение
                40, // Минимальное расстояние между центрами окружностей
                140, // Порог для обнаружения окружности
                40, // Минимальный радиус
                0,  
                0); // Максимальный радиус

            // Отображение найденных окружностей
            foreach (CircleF circle in circles)
            {
                CvInvoke.Circle(image, Point.Round(circle.Center), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
            }

            // Отображение результатов
            pictureBox.Image = image.ToBitmap();

            // Вывод количества найденных окружностей
            MessageBox.Show($"Количество окружностей: {circles.Length}");
        }



        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            LoadImageBtn = new Button();
            DetectObjectsBtn = new Button();
            pictureBox = new PictureBox();
            CountRectanglesBtn = new Button();
            FindLinesBtn = new Button();
            FindCirclesBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // LoadImageBtn
            // 
            LoadImageBtn.Location = new Point(16, 18);
            LoadImageBtn.Margin = new Padding(4, 5, 4, 5);
            LoadImageBtn.Name = "LoadImageBtn";
            LoadImageBtn.Size = new Size(168, 54);
            LoadImageBtn.TabIndex = 0;
            LoadImageBtn.Text = "Загрузить изображение";
            LoadImageBtn.UseVisualStyleBackColor = true;
            LoadImageBtn.Click += LoadImageBtn_Click;
            // 
            // DetectObjectsBtn
            // 
            DetectObjectsBtn.Location = new Point(16, 82);
            DetectObjectsBtn.Margin = new Padding(4, 5, 4, 5);
            DetectObjectsBtn.Name = "DetectObjectsBtn";
            DetectObjectsBtn.Size = new Size(168, 54);
            DetectObjectsBtn.TabIndex = 1;
            DetectObjectsBtn.Text = "Обнаружить объекты";
            DetectObjectsBtn.UseVisualStyleBackColor = true;
            DetectObjectsBtn.Click += DetectObjectsBtn_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(208, 18);
            pictureBox.Margin = new Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(853, 738);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // CountRectanglesBtn
            // 
            CountRectanglesBtn.Location = new Point(16, 146);
            CountRectanglesBtn.Margin = new Padding(4, 5, 4, 5);
            CountRectanglesBtn.Name = "CountRectanglesBtn";
            CountRectanglesBtn.Size = new Size(168, 35);
            CountRectanglesBtn.TabIndex = 0;
            CountRectanglesBtn.Text = "Подсчитать прямоугольники";
            CountRectanglesBtn.Click += CountRectanglesBtn_Click;
            // 
            // FindLinesBtn
            // 
            FindLinesBtn.Location = new Point(13, 191);
            FindLinesBtn.Margin = new Padding(4, 5, 4, 5);
            FindLinesBtn.Name = "FindLinesBtn";
            FindLinesBtn.Size = new Size(171, 35);
            FindLinesBtn.TabIndex = 1;
            FindLinesBtn.Text = "Найти линии";
            FindLinesBtn.Click += FindLinesBtn_Click;
            // 
            // FindCirclesBtn
            // 
            FindCirclesBtn.Location = new Point(13, 230);
            FindCirclesBtn.Margin = new Padding(4, 5, 4, 5);
            FindCirclesBtn.Name = "FindCirclesBtn";
            FindCirclesBtn.Size = new Size(171, 35);
            FindCirclesBtn.TabIndex = 2;
            FindCirclesBtn.Text = "Найти окружности";
            FindCirclesBtn.Click += FindCirclesBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 775);
            Controls.Add(CountRectanglesBtn);
            Controls.Add(FindLinesBtn);
            Controls.Add(FindCirclesBtn);
            Controls.Add(pictureBox);
            Controls.Add(DetectObjectsBtn);
            Controls.Add(LoadImageBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Обнаружение объектов";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button LoadImageBtn;
        private Button DetectObjectsBtn;
        private PictureBox pictureBox;
        private Button CountRectanglesBtn;
        private Button FindLinesBtn; // Добавленная кнопка для поиска линий
        private Button FindCirclesBtn;
    }
}
