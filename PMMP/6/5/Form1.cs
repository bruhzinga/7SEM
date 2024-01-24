using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _5
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        FaceDetection faceDetection;
        private readonly System.Windows.Forms.Timer _timer;

        public Form1()
        {
            InitializeComponent();
            faceDetection = new FaceDetection();
            faceDetection.InitCascadeClassifier();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100; // Set Timer interval.
            _timer.Tick += ProcessFrame;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture();
            _timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            if (_capture != null)
                _capture.Dispose();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            using (var frame = _capture.QueryFrame())
            {
                if (frame == null)
                    return;

                Image<Bgr, byte> img = frame.ToImage<Bgr, byte>();

                var proccesedImage = faceDetection.DetectFacesEyesAndMouth(img);
                var IsSmiling = faceDetection.DetectSmile(img);
                richTextBox1.Text = IsSmiling.ToString();
                    

                pictureBox1.Image = proccesedImage.ToBitmap();
            }
        }










    }
}