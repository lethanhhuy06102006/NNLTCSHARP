using System;

namespace Bai8
{
    class XuLySo
    {
        public void HoanVi(ref double a, ref double b)
        {
            double tam = a;
            a = b;
            b = tam;
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

            XuLySo xl = new XuLySo();
            Console.WriteLine("Truoc khi hoan vi: a = {0}, b = {1}", a, b);
            xl.HoanVi(ref a, ref b);
            Console.WriteLine("Sau khi hoan vi: a = {0}, b = {1}", a, b);
        }
    }
}