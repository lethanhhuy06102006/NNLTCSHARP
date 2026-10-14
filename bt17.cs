using System;
using System.Collections.Generic;

namespace Bai17
{
    class XuLyMang2Chieu
    {
        private Random rd = new Random();

        public int[,] SinhMangNgauNhien(int n, int m)
        {
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rd.Next(10, 101); // [10, 100]
            return a;
        }

        public void InMang(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j].ToString().PadLeft(5));
                Console.WriteLine();
            }
        }

        public void TachChanLe(int[,] a, out int[] mangChan, out int[] mangLe)
        {
            List<int> chan = new List<int>();
            List<int> le = new List<int>();

            foreach (int x in a)
            {
                if (x % 2 == 0) chan.Add(x);
                else le.Add(x);
            }

            mangChan = chan.ToArray();
            mangLe = le.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XuLyMang2Chieu xl = new XuLyMang2Chieu();

            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] a = xl.SinhMangNgauNhien(n, m);

            Console.WriteLine("\nMang A[{0}x{1}]:", n, m);
            xl.InMang(a);

            int[] mangChan, mangLe;
            xl.TachChanLe(a, out mangChan, out mangLe);

            Console.Write("\nMang cac so chan: ");
            Console.WriteLine(string.Join(" ", mangChan));

            Console.Write("Mang cac so le: ");
            Console.WriteLine(string.Join(" ", mangLe));
        }
    }
}