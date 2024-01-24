using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using static Emgu.CV.CvEnum.ThresholdType;
using static Emgu.CV.CvEnum.DepthType;
using static Emgu.CV.CvEnum.NormType;
using static Emgu.CV.CvEnum.LineType;
using static Emgu.CV.CvEnum.ColorConversion;
using Emgu.CV.Util;
using System.Drawing;
using Emgu.CV.CvEnum;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2
            Mat imageNormal = new Mat("image.jpg");
            Mat imageGrey = new Mat();
            Mat imageBinary = new Mat();
            Mat imageAdaptiveBinary = new Mat(); 

            CvInvoke.CvtColor(imageNormal,imageGrey,Bgr2Gray);
            CvInvoke.Threshold(imageGrey, imageBinary, 150, 255,Binary);
            CvInvoke.AdaptiveThreshold(imageGrey, imageAdaptiveBinary, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 11, 2);
            
            

            CvInvoke.Imshow("Normal picture", imageNormal);
            CvInvoke.Imshow("Grey picture", imageGrey);
            CvInvoke.Imshow("Binary picture", imageBinary);
            CvInvoke.Imshow("Adaptive binary picture", imageAdaptiveBinary);
            
            CvInvoke.WaitKey(0);

            CvInvoke.DestroyAllWindows();

            //3
            CvInvoke.Imwrite("grey.jpg",imageGrey);
            CvInvoke.Imwrite("binary.jpg", imageBinary);
            CvInvoke.Imwrite("adaptiveBinary.jpg", imageAdaptiveBinary);

            //4
            Mat imageDark = new Mat("shadow.jpg");
            Mat imageGrayDark = new Mat();
            Mat imageGrayNormalised = new Mat();
            
            CvInvoke.CvtColor(imageDark, imageGrayDark, Bgr2Gray);

            CvInvoke.EqualizeHist(imageGrayDark, imageGrayNormalised);

        
            CvInvoke.Imshow("Source dark image", imageGrayDark);
            CvInvoke.Imshow("Histogram dark image", ShowHistogram(imageGrayDark));

            CvInvoke.Imshow("Source equelized dark image", imageGrayNormalised);
            CvInvoke.Imshow("Histogram equelized dark image", ShowHistogram(imageGrayNormalised));


            CvInvoke.WaitKey(0);

        }

        static Mat ShowHistogram(Mat image)
        {
            VectorOfMat bgrPlanes = new VectorOfMat();
            CvInvoke.Split(image, bgrPlanes);

            int histSize = 256;
            float[] range = { 0, 256 }; 

            bool accumulate = true;

            Mat bHist = new Mat();

            CvInvoke.CalcHist(bgrPlanes, new int[] { 0 }, new Mat(), bHist, new int[] {histSize}, range, accumulate);


            int histW = 512, histH = 400;
            int binW = (int)Math.Round((double)histW / histSize);
            Mat histImage = new Mat(histH, histW, Cv64F, 3);

            CvInvoke.Normalize(bHist, bHist, 0, histImage.Rows, MinMax);

            
            for (int i = 1; i < histSize; i++)
            {
                CvInvoke.Line(histImage, 
                    new Point(binW * (i - 1), (int)(histH - Math.Round((float)bHist.GetData().GetValue(i - 1, 0)))),
                    new Point(binW * (i), (int)(histH - Math.Round((float)bHist.GetData().GetValue(i,0)))),
                    new MCvScalar(255, 0, 0));
            }
            return histImage;
            
        }
    }
}
