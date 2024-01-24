using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using System.Windows.Forms;
using Emgu.CV.Util;

namespace _5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Image<Bgr, byte> image;
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


        private void DetectCornersBtn_Click(object sender, EventArgs e)
        {
            Image<Gray, float> grayImage = image.Convert<Gray, float>();
            Image<Gray, float> corners = new Image<Gray, float>(image.Size);

            CvInvoke.CornerHarris(grayImage, corners, 2, 3, 0.04, BorderType.Default);

            // Performing dilate to find local maxima
            Image<Gray, float> dilatedCorners = corners.Clone();
            CvInvoke.Dilate(corners, dilatedCorners, null, new Point(-1, -1), 1, BorderType.Default, default(MCvScalar));
            CvInvoke.Threshold(corners, corners, 0.05, 255, ThresholdType.Binary); // Adjust the threshold value
            CvInvoke.Compare(corners, dilatedCorners, dilatedCorners, CmpType.Equal);

            // Drawing corners


            for (int y = 0; y < corners.Rows; y++)
            {
                for (int x = 0; x < corners.Cols; x++)
                {
                    if (dilatedCorners.Data[y, x, 0] > 0)
                    {
                        image.Draw(new CircleF(new Point(x, y), 0.25f), new Bgr(Color.Red), 2);
                    }
                }
            }

            pictureBox.Image = image.ToBitmap();
        }

        private void DetectCornersWithTomasi(object sender, EventArgs e)
        {
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Set the maximum number of corners to detect
            int maxCorners = 20;

            // Initialize GFTTDetector with the desired parameters
            GFTTDetector detector = new GFTTDetector(maxCorners, 0.01, 10, 3, false, 0.04);

            // Detect corners
            MKeyPoint[] keyPoints = detector.Detect(grayImage);

            // Draw the detected corners
            MCvScalar color = new Bgr(Color.Red).MCvScalar;

            foreach (var keyPoint in keyPoints)
            {
                image.Draw(new CircleF(keyPoint.Point, 3), new Bgr(Color.Red), 2);
            }

            pictureBox.Image = image.ToBitmap();
        }

        private void RotateImageBtn_Click(object sender, EventArgs e)
        {
            // Preprocess the image (you can adjust parameters as needed)
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(5, 5), 0);
            CvInvoke.Canny(grayImage, grayImage, 100, 200);

            // Find contours in the processed image
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            // Find the largest contour (assuming it's the paper)
            double maxArea = 0;
            VectorOfPoint largestContour = null;
            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                    largestContour = contours[i];
                }
            }

            // Check if a contour was found
            if (largestContour != null)
            {
                // Create a new VectorOfPoint to store the approximate polygon
                VectorOfPoint approxPolygon = new VectorOfPoint();

                // Get the corners of the largest contour (approximate polygon)
                CvInvoke.ApproxPolyDP(largestContour, approxPolygon, CvInvoke.ArcLength(largestContour, true) * 0.02, true);

                // Convert the points to PointF arrays
                PointF[] srcPoints = approxPolygon.ToArray().Select(p => new PointF(p.X, p.Y)).ToArray();
                PointF[] destinationPoints = {
                    new PointF(0, 0),
                    new PointF(0, image.Height - 1),
                    new PointF(image.Width - 1, image.Height - 1),
                    new PointF(image.Width - 1, 0)
                };

                // Perform the perspective transformation
                Mat perspectiveTransform = CvInvoke.GetPerspectiveTransform(srcPoints, destinationPoints);
                Mat warpedImage = new Mat();
                CvInvoke.WarpPerspective(image, warpedImage, perspectiveTransform, image.Size);

                pictureBox.Image = warpedImage.ToBitmap();

            }
            else
            {
                Console.WriteLine("No paper contour found.");
            }
        }

     


    }
}




