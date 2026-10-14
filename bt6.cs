using System;

namespace Bai6
{
    class XuLySo
    {
        public int TimMax(int a, int b, int c)
        {
            int max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Nhap c: ");
            int c = int.Parse(Console.ReadLine());

            XuLySo xl = new XuLySo();
            Console.WriteLine("Gia tri lon nhat la: " + xl.TimMax(a, b, c));
        }
    }
}