using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            long ketQua = 1;
            for (int i = 0; i < y; i++)
                ketQua *= x;

            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }
    }
}

