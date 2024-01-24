using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Legacy;
using Emgu.CV.Structure;

namespace _5
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        private readonly System.Windows.Forms.Timer _timer;
        private BackgroundSubtractorMOG2 _subtract;
        static string CurrentMode = "EMPTY";
        private Mat prevGrayFrame;
        private PointF[] prevPoints = new PointF[0];
        private PointF[] nextPoints;
        private TrackerMOSSE tracker;

        public Form1()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100; // Set Timer interval.
            _subtract = new BackgroundSubtractorMOG2();
            _capture = new VideoCapture();
            _timer.Tick += ProcessFrame;
            _timer.Start();
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            CurrentMode = "Background";
        }

        private void calcOpticalFlowPyrLK_Click(object sender, EventArgs e)
        {
            CurrentMode = "calcOpticalFlow";
        }

        private void Track_Click(object sender, EventArgs e)
        {
            CurrentMode = "Track";
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (CurrentMode == "EMPTY")
                return;

            using (var frame = _capture.QueryFrame())
            {
                if (frame == null)
                    return;

                Image<Bgr, byte> img = frame.ToImage<Bgr, byte>();
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(img, grayFrame, ColorConversion.Bgr2Gray);

                switch (CurrentMode)
                {
                    case "Background":
                        {
                            Mat fgMask = new Mat();
                            double learningRate = 0.01;

                            _subtract.Apply(grayFrame, fgMask, learningRate);

                            pictureBox1.Image = fgMask.ToBitmap();

                            int whitePixelCount = CvInvoke.CountNonZero(fgMask);

                            if (whitePixelCount > 800)
                            {
                                richTextBox1.Text = "True";
                            }
                            else
                            {
                                richTextBox1.Text = "False";
                            }

                            break;
                        }

                    case "calcOpticalFlow":
                        {
                            if (prevGrayFrame == null)
                            {
                                prevGrayFrame = grayFrame;
                            }

                            if (prevPoints.Length == 0)
                            {
                                using (var detector = new GFTTDetector())
                                {
                                    var keyPoints = detector.Detect(prevGrayFrame);
                                    prevPoints = keyPoints.Select(kp => kp.Point).ToArray();
                                }
                            }

                            if (prevPoints.Length > 0)
                            {
                                byte[] status;
                                float[] trackError;

                                CvInvoke.CalcOpticalFlowPyrLK(
                                    prevGrayFrame,
                                    grayFrame,
                                    prevPoints,
                                    new Size(21, 21),
                                    3,
                                    new MCvTermCriteria(30, 0.01),
                                    out nextPoints,
                                    out status,
                                    out trackError
                                );

                                for (int i = 0; i < prevPoints.Length; i++)
                                {
                                    if (status[i] == 1)
                                    {
                                        Point startPoint = Point.Round(prevPoints[i]);
                                        Point endPoint = Point.Round(nextPoints[i]);

                                        CvInvoke.Line(img, startPoint, endPoint, new MCvScalar(0, 0, 255), 2);
                                        CvInvoke.Circle(img, endPoint, 3, new MCvScalar(0, 255, 0), -1);
                                    }
                                }

                                prevGrayFrame = grayFrame.Clone();
                                prevPoints = nextPoints;
                            }

                            pictureBox1.Image = img.ToBitmap();
                            break;
                        }

                    case "Track":
                        {
                            Rectangle trackerROI = new Rectangle(grayFrame.Width / 3, grayFrame.Height / 3, grayFrame.Width / 3, grayFrame.Height / 2);

                            if (tracker == null)
                            {
                                tracker = new TrackerMOSSE();
                                tracker.Init(grayFrame, trackerROI);
                            }

                            if (tracker != null)
                            {
                                bool trackingSuccess = tracker.Update(grayFrame, out trackerROI); // Обновляем трекер

                                if (trackingSuccess)
                                {
                                    // Display the tracking result
                                    CvInvoke.Rectangle(img, trackerROI, new MCvScalar(0, 255, 0), 2);
                                    pictureBox1.Image = img.ToBitmap();
                                }
                            }
                            else
                            {
                                // Если трекер не может быть инициализирован или обновлен, выведите сообщение об ошибке
                                MessageBox.Show("Трекер не может быть инициализирован или обновлен.", "Ошибка");
                            }
                        }

                        break;
                }
            }
        }

    }
}

