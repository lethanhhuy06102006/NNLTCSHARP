using System;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong1
{
    // BÀI 1.4: Lớp Phân số
    // Implement IComparable<PhanSo> để dùng được với Array.Sort (xem Bài 3.1)
    public class PhanSo : IComparable<PhanSo>
    {
        private int tu, mau;

        // ----- Constructor -----
        public PhanSo() : this(0, 1) { }                 // mặc nhiên: 0/1
        public PhanSo(int soNguyen) : this(soNguyen, 1) { } // số nguyên n = n/1
        public PhanSo(int tu, int mau)
        {
            if (mau == 0) throw new DivideByZeroException("Mẫu số phải khác 0");
            this.tu = tu;
            this.mau = mau;
            RutGon();
        }
        public PhanSo(PhanSo p) : this(p.tu, p.mau) { }  // sao chép

        public int Tu  { get { return tu; } }
        public int Mau { get { return mau; } }

        // Ước chung lớn nhất (thuật toán Euclid)
        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            while (b != 0) { int r = a % b; a = b; b = r; }
            return a == 0 ? 1 : a;
        }

        // Rút gọn và luôn giữ mẫu dương: 2/-4 -> -1/2
        private void RutGon()
        {
            int u = UCLN(tu, mau);
            tu /= u; mau /= u;
            if (mau < 0) { tu = -tu; mau = -mau; }
        }

        public void Input()
        {
            tu = Nhap.SoNguyen("  Tử số: ");
            do { mau = Nhap.SoNguyen("  Mẫu số (khác 0): "); } while (mau == 0);
            RutGon();
        }

        public override string ToString()
        {
            return mau == 1 ? tu.ToString() : tu + "/" + mau;
        }

        // ----- Toán tử 1 ngôi -----
        public static PhanSo operator +(PhanSo a) { return new PhanSo(a); }
        public static PhanSo operator -(PhanSo a) { return new PhanSo(-a.tu, a.mau); }

        // ----- Toán tử 2 ngôi -----
        public static PhanSo operator +(PhanSo a, PhanSo b) { return new PhanSo(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau); }
        public static PhanSo operator -(PhanSo a, PhanSo b) { return a + (-b); }
        public static PhanSo operator *(PhanSo a, PhanSo b) { return new PhanSo(a.tu * b.tu, a.mau * b.mau); }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.tu == 0) throw new DivideByZeroException("Không thể chia cho phân số 0");
            return new PhanSo(a.tu * b.mau, a.mau * b.tu);
        }

        // ----- So sánh -----
        // Vì mẫu luôn dương nên: a/b ? c/d  <=>  a*d ? c*b
        public int CompareTo(PhanSo other)
        {
            if (ReferenceEquals(other, null)) return 1;
            long trai = (long)tu * other.mau, phai = (long)other.tu * mau;
            return trai.CompareTo(phai);
        }

        public static bool operator >(PhanSo a, PhanSo b)  { return a.CompareTo(b) > 0; }
        public static bool operator <(PhanSo a, PhanSo b)  { return a.CompareTo(b) < 0; }
        public static bool operator >=(PhanSo a, PhanSo b) { return a.CompareTo(b) >= 0; }
        public static bool operator <=(PhanSo a, PhanSo b) { return a.CompareTo(b) <= 0; }

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.tu == b.tu && a.mau == b.mau;   // đã rút gọn nên so sánh trực tiếp được
        }
        public static bool operator !=(PhanSo a, PhanSo b) { return !(a == b); }

        // C# yêu cầu: đã overload == thì nên override Equals và GetHashCode
        public override bool Equals(object obj) { return this == (obj as PhanSo); }
        public override int GetHashCode() { return tu * 31 + mau; }

        public static void Demo()
        {
            PhanSo a = new PhanSo(), b = new PhanSo();
            Console.WriteLine("Nhập phân số a:"); a.Input();
            Console.WriteLine("Nhập phân số b:"); b.Input();
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("+a = {0}, -a = {1}", +a, -a);
            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            if (b.Tu != 0) Console.WriteLine("a / b = {0}", a / b);
            else Console.WriteLine("a / b: không chia được vì b = 0");
            Console.WriteLine("a > b: {0} | a < b: {1} | a >= b: {2} | a <= b: {3} | a == b: {4} | a != b: {5}",
                a > b, a < b, a >= b, a <= b, a == b, a != b);
        }
    }
}
