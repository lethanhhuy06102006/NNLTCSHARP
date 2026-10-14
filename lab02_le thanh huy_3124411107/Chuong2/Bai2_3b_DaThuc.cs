using System;
using System.Collections.Generic;
using ThucHanh02.Chuong1;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.3 (đa thức): P(x) = a0 + a1.x + a2.x^2 + ... + an.x^n  gồm n+1 đơn thức
    // Tái sử dụng lớp DonThuc của Bài 1.5 -> đa thức là một mảng các đơn thức
    public class DaThuc
    {
        private DonThuc[] ds;   // ds[i] là đơn thức ai.x^i

        // a. Constructor
        public DaThuc() : this(0) { }                  // P(x) = 0
        public DaThuc(int bac)
        {
            ds = new DonThuc[bac + 1];
            for (int i = 0; i <= bac; i++) ds[i] = new DonThuc(0, i);
        }
        public DaThuc(params double[] heSo)            // new DaThuc(1, 2, 3) = 1 + 2x + 3x^2
        {
            ds = new DonThuc[heSo.Length];
            for (int i = 0; i < heSo.Length; i++) ds[i] = new DonThuc(heSo[i], i);
        }
        public DaThuc(DaThuc other)
        {
            ds = new DonThuc[other.ds.Length];
            for (int i = 0; i < ds.Length; i++) ds[i] = new DonThuc(other.ds[i]);
        }

        public int Bac { get { return ds.Length - 1; } }

        // b. Indexer: truy cập đơn thức thứ i
        public DonThuc this[int i]
        {
            get { return ds[i]; }
            set
            {
                if (value.SoMu != i) throw new ArgumentException("Đơn thức thứ i phải có số mũ = i");
                ds[i] = value;
            }
        }

        // c. Nhập / Xuất
        public void Input()
        {
            int n = Nhap.SoNguyen("Bậc n của đa thức: ", 0, 100);
            ds = new DonThuc[n + 1];
            for (int i = 0; i <= n; i++)
                ds[i] = new DonThuc(Nhap.SoThuc("  a" + i + " = "), i);
        }

        public override string ToString()
        {
            List<string> phan = new List<string>();
            for (int i = ds.Length - 1; i >= 0; i--)        // in từ bậc cao xuống thấp
                if (ds[i].HeSo != 0) phan.Add(ds[i].ToString());
            return phan.Count == 0 ? "0" : string.Join(" + ", phan).Replace("+ -", "- ");
        }

        public void Output() { Console.WriteLine("P(x) = " + this); }

        // d. Giá trị đa thức = tổng giá trị các đơn thức
        public double GiaTri(double x)
        {
            double s = 0;
            foreach (DonThuc d in ds) s += d.GiaTri(x);
            return s;
        }

        public static void Demo()
        {
            DaThuc p = new DaThuc();
            p.Input();
            p.Output();
            double x = Nhap.SoThuc("Nhập x: ");
            Console.WriteLine("P({0}) = {1}", x, p.GiaTri(x));
        }
    }
}
