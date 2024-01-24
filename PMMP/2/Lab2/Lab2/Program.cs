using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV.Structure;

namespace Lab2
{
    internal class Program
    {
        public enum Effect
        {
            Tisnenie,
            Blur,
            GausianBlur,
            MedianBlur,
            Erode,
            Dilate
        }
        static void Main(string[] args)
        {
            Mat imageNormal = new Mat("image.jpg");
            Mat items = new Mat("items.jpg");
            Mat itemsBinary = new Mat();
            Mat itemsAdaptive = new Mat();
            CvInvoke.CvtColor(items, itemsBinary, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(itemsBinary, itemsBinary, 240, 255, ThresholdType.Binary);
            CvInvoke.AdaptiveThreshold(itemsBinary, itemsAdaptive,255,AdaptiveThresholdType.GaussianC,ThresholdType.Binary,3,0);

            //1
            CvInvoke.Imshow("Normal", imageNormal);
            CvInvoke.Imshow("Tisnenie", MakeEffect(imageNormal,Effect.Tisnenie));
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyAllWindows();

            //2
            CvInvoke.Imshow("Normal", imageNormal);
            CvInvoke.Imshow("GausianBlur", MakeEffect(imageNormal, Effect.GausianBlur));
            CvInvoke.Imshow("Blur", MakeEffect(imageNormal, Effect.Blur));
            CvInvoke.Imshow("MedianBlur", MakeEffect(imageNormal, Effect.MedianBlur));
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyAllWindows();

            //3
            CvInvoke.Imshow("Normal",items);

            Mat dilate = MakeEffect(itemsBinary, Effect.Dilate);
            Mat erode = MakeEffect(itemsBinary, Effect.Erode);

            CvInvoke.Imshow("Normal binary", itemsBinary);
            CvInvoke.Imshow("Erode binary", erode); ;
            CvInvoke.Imshow("Dilate binary", dilate);
            

            //4

            Mat erodeAdaptive = MakeEffect(itemsAdaptive, Effect.Erode);
            Mat dilateAdaptive = MakeEffect(itemsAdaptive, Effect.Dilate);

            CvInvoke.Imshow("Normal adaptive", itemsAdaptive);
            CvInvoke.Imshow("Erode adaptive", erodeAdaptive);
            CvInvoke.Imshow("Dilate adaptive", dilateAdaptive);
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyAllWindows();
            
        }

        static Mat MakeEffect(Mat image, Effect effect)
        {
            Mat result = new Mat(image.Size, DepthType.Cv64F,3);

            switch (effect)
            {
                case Effect.Tisnenie:
                    {                      
                        Matrix<float> kernel = new Matrix<float>( new float[,] { { 2, 0, 0 }, { 0, -1, 0 }, { 0, 0, -1 } }) ;

                        CvInvoke.Filter2D(image, result, kernel, new Point(-1,-1));

                        break;
                    }
                case Effect.GausianBlur:
                    {
                        CvInvoke.GaussianBlur(image, result, new Size(9, 9),1);
                        break;
                    }
                case Effect.MedianBlur:
                    {
                        CvInvoke.MedianBlur(image, result,9);
                        break;
                    }
                case Effect.Blur:
                    {
                        CvInvoke.Blur(image, result,new Size(9,9), new Point(-1, -1));
                        break;
                    }
                case Effect.Erode:
                    {
                        Matrix<float> kernel = new Matrix<float>(new float[,] 
                        { 
                            { 1,  1, 1    }, 
                            {  1,   5,  1    }, 
                            {  1,  1,  1    } 
                        });
                        CvInvoke.Erode(image, result, kernel, new Point(-1, -1), 5, BorderType.Default, new MCvScalar());
                        break;
                    }
                case Effect.Dilate:
                    {
                        Matrix<float> kernel = new Matrix<float>(new float[,]
                        {
                            { 1,  1, 1    },
                            {  1,   7,  1    },
                            {  1,  1,  1    }
                        });
                        CvInvoke.Dilate(image, result, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                        break;
                    }

            }

            return result;
        }
    }
}
