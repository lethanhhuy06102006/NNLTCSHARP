using System;
using System.Collections.Generic;

namespace Bai15
{
    class XuLyMang
    {
        public int[] NhapMang(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap phan tu a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine());
            }
            return a;
        }

        public void InMang(int[] a)
        {
            foreach (int x in a)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        public void TimMaxMin(int[] a, out int max, out int min)
        {
            max = a[0]; min = a[0];
            foreach (int x in a)
            {
                if (x > max) max = x;
                if (x < min) min = x;
            }
        }

        private bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        public int[] MangSoNguyenTo(int[] a)
        {
            List<int> ds = new List<int>();
            foreach (int x in a)
                if (LaSoNguyenTo(x)) ds.Add(x);
            return ds.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XuLyMang xl = new XuLyMang();

            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            int[] a = xl.NhapMang(n);

            Console.Write("Mang vua nhap: ");
            xl.InMang(a);

            int max, min;
            xl.TimMaxMin(a, out max, out min);
            Console.WriteLine("Gia tri lon nhat: " + max);
            Console.WriteLine("Gia tri nho nhat: " + min);

            int[] mangNT = xl.MangSoNguyenTo(a);
            Console.Write("Cac so nguyen to trong mang: ");
            xl.InMang(mangNT);
        }
    }
}