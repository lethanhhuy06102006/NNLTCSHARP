using System;

namespace Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.Write("Nhap so nguyen x: ");
            string sx = Console.ReadLine();
            if (!int.TryParse(sx, out x))
            {
                Console.WriteLine("Loi: '{0}' khong phai la so nguyen!", sx);
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            string sy = Console.ReadLine();
            if (!int.TryParse(sy, out y))
            {
                Console.WriteLine("Loi: '{0}' khong phai la so nguyen!", sy);
                return;
            }

            long ketQua = 1;
            for (int i = 0; i < y; i++)
                ketQua *= x;

            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }
    }
}