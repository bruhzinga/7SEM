using Client2.ServiceReference1;
using System;
using WCF;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client service1Client = new Service1Client();

            var sumResult = service1Client.Sum(
                new A { s = "q", k = 1, f = 1.1f },
                new A { s = "w", k = 2, f = 1.4f }
                );

            Console.WriteLine($"Sum\nf = {sumResult.f}\nk = {sumResult.k}\ns = {sumResult.s}");
            Console.WriteLine($"\n\nConcat\nresult = " + service1Client.Concat(sumResult.s, sumResult.f));
            Console.WriteLine($"\n\nAdd\nresult = " + service1Client.Add(sumResult.k, 8));

            service1Client.Close();
            
            Console.ReadKey();
        }
    }
}
