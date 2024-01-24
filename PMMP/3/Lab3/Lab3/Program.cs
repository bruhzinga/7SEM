using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace CameraVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoCapture camera = new VideoCapture();  // создаем объект для захвата видео из камеры
            camera.Start();  // запускаем камеру

            while (true)  // в бесконечном цикле
            {
                Mat frame = camera.QueryFrame();

                if (frame == null) break;  // если не удалось захватить кадр, выходим из цикла

                // применяем оператор Лапласа к кадру и выводим его в первом окне
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(frame, grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);


                CvInvoke.Imshow("Camera", grayFrame);


                // переводим кадр в оттенки серого
                Mat frameLaplace = new Mat();
                CvInvoke.Laplacian(grayFrame, frameLaplace, Emgu.CV.CvEnum.DepthType.Default, 5, 1); // применяем оператор Лапласа
                CvInvoke.Imshow("Laplace Video", frameLaplace);  // выводим кадр с оператором Лапласа на экран

                // применяем оператор Собеля к кадру и выводим его во втором окне
                Mat sobelXFrame = new Mat();
                CvInvoke.Sobel(grayFrame, sobelXFrame, Emgu.CV.CvEnum.DepthType.Default, 1, 0);  // применяем оператор Собеля по X
                Mat sobelYFrame = new Mat();
                CvInvoke.Sobel(grayFrame, sobelYFrame, Emgu.CV.CvEnum.DepthType.Default, 0, 1);  // применяем оператор Собеля по Y
                Mat frameSobel = new Mat();
                CvInvoke.AddWeighted(sobelXFrame, 0.5, sobelYFrame, 0.5, 0, frameSobel);  // объединяем результаты применения операторов Собеля по X и по Y
                CvInvoke.Imshow("Sobel Video", frameSobel);  // выводим кадр с оператором Собеля на экран

                // применяем детектор границ Кэнни к кадру и выводим его в третьем окне
                Mat frameCanny = new Mat();
                CvInvoke.Canny(grayFrame, frameCanny, 100, 200);  // применяем детектор границ Кэнни
                CvInvoke.Imshow("Canny Video", frameCanny);  // выводим кадр с детектором границ Кэнни на экран

                if (CvInvoke.WaitKey(1) > 0) break;  // если пользователь нажимает Esc, выходим из цикла
            }

            camera.Stop();  // останавливаем камеру
        }
    }
}
