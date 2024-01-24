using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    public class FaceDetection
    {
        private readonly string faceCascadePath = "haarcascades/haarcascade_frontalface_default.xml";
        private readonly string eyeCascadePath = "haarcascades/haarcascade_eye.xml";
        private readonly string mouthCascadePath = "haarcascades/haarcascade_mcs_mouth.xml";
        private readonly string smileCascadePath = "haarcascades/haarcascade_smile.xml";



        private CascadeClassifier faceCascade;
        private CascadeClassifier eyeCascade;
        private CascadeClassifier mouthCascade;
        private CascadeClassifier smileCascade;

        public void InitCascadeClassifier()
        {
            faceCascade = new CascadeClassifier(faceCascadePath);
            eyeCascade = new CascadeClassifier(eyeCascadePath);
            mouthCascade = new CascadeClassifier(mouthCascadePath);
            smileCascade = new CascadeClassifier(smileCascadePath);
        }

        public Image<Bgr, byte> DetectFacesEyesAndMouth(Image<Bgr, byte> imageFrame)
        {
            // Преобразование изображения в оттенки серого, так как классификатору Хаара требуется изображение в градациях серого.
            var grayframe = imageFrame.Convert<Gray, byte>();
            var faces = faceCascade.DetectMultiScale(grayframe, 1.1, 10, new Size(20, 20), Size.Empty);

            foreach (var face in faces)
            {
                // Рисуем квадрат вокруг лица.
                imageFrame.Draw(face, new Bgr(Color.Red), 2);

                // Обнаружение глаз в пределах области лица.
                Rectangle eyeRegion = face;
                var eyes = eyeCascade.DetectMultiScale(grayframe, 1.1, 10, new Size(20, 20), Size.Empty);
                foreach (var eye in eyes)
                {
                    var e = eye;

                    // Рисуем квадрат вокруг глаза.
                    imageFrame.Draw(e, new Bgr(Color.Blue), 2);
                }

                // Обнаружение рта в пределах области лица.
                Rectangle mouthRegion = face;
                var mouth = mouthCascade.DetectMultiScale(grayframe, 1.1, 10, new Size(20, 20), Size.Empty);
                foreach (var m in mouth)
                {
                    var e = m;

                    // Рисуем квадрат вокруг рта.
                    imageFrame.Draw(e, new Bgr(Color.Green), 2);
                }
            }
            return imageFrame;

        }

        public bool DetectSmile(Image<Bgr, byte> imageFrame)
        {
            var grayframe = imageFrame.Convert<Gray, byte>();
            var smiles  = smileCascade.DetectMultiScale(
             grayframe,
             1.1, // Scale factor: How much the image size is reduced at each image scale.
             35,  // Min Neighbors: how many neighbors each candidate rectangle should have to retain it, higher numbers give lower false positives.
             new Size(25, 25), // Min size: Minimum possible object size. Objects smaller than that are ignored.
             Size.Empty); // Max size: Maximum possible object size. Objects larger than that are ignored. If maxSize == Size.Empty, no maximum size is applied.

            if (smiles.Length > 0)
                return true;
            return false;
        }


    }
   
}


