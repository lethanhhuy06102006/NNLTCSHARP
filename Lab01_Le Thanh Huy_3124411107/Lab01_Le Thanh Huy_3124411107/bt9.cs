using System;

namespace Bai9
{
    class XuLySo
    {
        public void TimMaxMin(double a, double b, double c, out double max, out double min)
        {
            max = a; min = a;
            if (b > max) max = b;
            if (b < min) min = b;
            if (c > max) max = c;
            if (c < min) min = c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Nhap c: ");
            double c = double.Parse(Console.ReadLine());

            XuLySo xl = new XuLySo();
            double max, min;
            xl.TimMaxMin(a, b, c, out max, out min);

            Console.WriteLine("Gia tri lon nhat: {0}", max);
            Console.WriteLine("Gia tri nho nhat: {0}", min);
        }
    }
}