using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.4: Lớp mảng 2 chiều n x m
    public class MaTran
    {
        private int[,] a;

        // a. Constructor
        public MaTran() { a = new int[0, 0]; }
        public MaTran(int n, int m) { a = new int[n, m]; }
        public MaTran(int[,] arr) { a = (int[,])arr.Clone(); }
        public MaTran(MaTran other) : this(other.a) { }

        public int SoDong { get { return a.GetLength(0); } }
        public int SoCot  { get { return a.GetLength(1); } }

        // b. Indexer 2 tham số: mt[i, j]
        public int this[int i, int j]
        {
            get { return a[i, j]; }
            set { a[i, j] = value; }
        }

        // c. Nhập / Xuất
        public void Input()
        {
            int n = Nhap.SoNguyen("Số dòng n: ", 1, 100);
            int m = Nhap.SoNguyen("Số cột m: ", 1, 100);
            a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = Nhap.SoNguyen(string.Format("  a[{0},{1}] = ", i, j));
        }

        public void Output()
        {
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++) Console.Write("{0,6}", a[i, j]);
                Console.WriteLine();
            }
        }

        // Kiểm tra nguyên tố: chỉ cần thử ước tới căn bậc 2 của n
        public static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int k = 2; (long)k * k <= n; k++)
                if (n % k == 0) return false;
            return true;
        }

        // d. Tìm các số nguyên tố trong mảng
        public List<int> TimSoNguyenTo()
        {
            List<int> kq = new List<int>();
            foreach (int x in a) if (LaSoNguyenTo(x)) kq.Add(x);
            return kq;
        }

        public static void Demo()
        {
            MaTran mt = new MaTran();
            mt.Input();
            Console.WriteLine("Ma trận:");
            mt.Output();
            List<int> nt = mt.TimSoNguyenTo();
            Console.WriteLine("Các số nguyên tố: " + (nt.Count == 0 ? "không có" : string.Join(", ", nt)));
        }
    }
}
