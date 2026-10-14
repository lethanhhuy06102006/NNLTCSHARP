using System;

namespace Bai7
{
    class XuLySo
    {
        public bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());

            XuLySo xl = new XuLySo();
            if (xl.LaSoNguyenTo(n))
                Console.WriteLine("{0} la so nguyen to", n);
            else
                Console.WriteLine("{0} khong phai la so nguyen to", n);
        }
    }
}
