using System;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong1
{
    // BÀI 1.2: Lớp Point (điểm trong mặt phẳng)
    public class Point
    {
        // Field
        private double x, y;

        // Constructor
        public Point() { x = 0; y = 0; }                     // mặc định: gốc toạ độ (0, 0)
        public Point(double x, double y) { this.x = x; this.y = y; }
        public Point(Point p) : this(p.x, p.y) { }           // sao chép

        // Property
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        // Method nhập / xuất
        public void Input(string ten = "")
        {
            x = Nhap.SoThuc("  Nhập x" + ten + ": ");
            y = Nhap.SoThuc("  Nhập y" + ten + ": ");
        }

        public void Output() { Console.WriteLine(this); }

        // Override ToString(): Console.WriteLine(p) sẽ tự gọi hàm này
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        // ----- Đa năng hoá toán tử (operator overloading) -----
        public static Point operator +(Point a, Point b) { return new Point(a.x + b.x, a.y + b.y); }
        public static Point operator -(Point a, Point b) { return new Point(a.x - b.x, a.y - b.y); }
        public static Point operator -(Point a)          { return new Point(-a.x, -a.y); } // lấy âm (1 ngôi)

        // ----- (a) Khoảng cách -----
        // Cách 1: phương thức THÀNH VIÊN -> gọi qua đối tượng: A.KhoangCach(B)
        public double KhoangCach(Point other)
        {
            double dx = x - other.x, dy = y - other.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Cách 2: phương thức TĨNH -> gọi qua tên lớp: Point.KhoangCach(A, B)
        public static double KhoangCach(Point a, Point b)
        {
            return a.KhoangCach(b);
        }

        // ----- (b) Trung điểm -----
        public Point TrungDiem(Point other)
        {
            return new Point((x + other.x) / 2, (y + other.y) / 2);
        }

        public static Point TrungDiem(Point a, Point b)
        {
            return a.TrungDiem(b);
        }

        public static void Demo()
        {
            Point A = new Point(), B = new Point();
            Console.WriteLine("Nhập điểm A:"); A.Input("A");
            Console.WriteLine("Nhập điểm B:"); B.Input("B");

            Console.WriteLine("A = {0}, B = {1}", A, B);
            Console.WriteLine("A + B = {0}", A + B);
            Console.WriteLine("A - B = {0}", A - B);
            Console.WriteLine("-A    = {0}", -A);
            Console.WriteLine("|AB| (thành viên): {0:0.###}", A.KhoangCach(B));
            Console.WriteLine("|AB| (tĩnh)      : {0:0.###}", Point.KhoangCach(A, B));
            Console.WriteLine("Trung điểm I (thành viên): {0}", A.TrungDiem(B));
            Console.WriteLine("Trung điểm I (tĩnh)      : {0}", Point.TrungDiem(A, B));
        }
    }
}
