using System;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong1
{
    // BÀI 1.5: Đơn thức P(x) = a.x^n  (a thực, n nguyên >= 0)
    public class DonThuc
    {
        private double a;
        private int n;

        public DonThuc() : this(0, 0) { }
        public DonThuc(double a, int n)
        {
            if (n < 0) throw new ArgumentException("Số mũ n phải >= 0");
            this.a = a; this.n = n;
        }
        public DonThuc(DonThuc d) : this(d.a, d.n) { }

        public double HeSo { get { return a; } set { a = value; } }
        public int SoMu
        {
            get { return n; }
            set { if (value < 0) throw new ArgumentException("Số mũ n phải >= 0"); n = value; }
        }

        public void Input()
        {
            a = Nhap.SoThuc("  Hệ số a: ");
            n = Nhap.SoNguyen("  Số mũ n (>= 0): ", 0, int.MaxValue);
        }

        // (a) Giá trị P(x) = a.x^n
        public double GiaTri(double x) { return a * Math.Pow(x, n); }

        // (b) Đạo hàm: (a.x^n)' = a.n.x^(n-1); riêng hằng số (n = 0) có đạo hàm = 0
        public DonThuc DaoHam()
        {
            if (n == 0) return new DonThuc(0, 0);
            return new DonThuc(a * n, n - 1);
        }

        public override string ToString()
        {
            if (a == 0 || n == 0) return a.ToString();
            if (n == 1) return a + "x";
            return a + "x^" + n;
        }

        public static void Demo()
        {
            DonThuc p = new DonThuc();
            Console.WriteLine("Nhập đơn thức P(x) = a.x^n:");
            p.Input();
            double x = Nhap.SoThuc("Nhập x: ");
            Console.WriteLine("P(x)  = {0}", p);
            Console.WriteLine("P({0}) = {1}", x, p.GiaTri(x));
            Console.WriteLine("P'(x) = {0}", p.DaoHam());
        }
    }
}
