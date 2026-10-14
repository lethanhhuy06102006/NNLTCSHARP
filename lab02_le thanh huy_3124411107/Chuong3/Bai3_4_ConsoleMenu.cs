using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.4*: Lớp ConsoleMenu tổng quát, mở rộng được bằng 2 cách:
    //   (1) KẾ THỪA : class PTBac2Console : ConsoleMenu  và override OnChoose
    //   (2) SỰ KIỆN : app.Choose += (sender, e) => { ... }

    // Dữ liệu gửi kèm sự kiện: chức năng người dùng đã chọn
    public class MenuEventArgs : EventArgs
    {
        public int LuaChon { get; private set; }
        public MenuEventArgs(int luaChon) { LuaChon = luaChon; }
    }

    public class ConsoleMenu
    {
        protected List<string> items = new List<string>();
        public string TieuDe { get; set; }

        // SỰ KIỆN: bên ngoài "đăng ký" hàm xử lý bằng +=
        public event EventHandler<MenuEventArgs> Choose;

        public ConsoleMenu(string tieuDe, params string[] cacChucNang)
        {
            TieuDe = tieuDe;
            items.AddRange(cacChucNang);
        }

        public void AddItem(string ten) { items.Add(ten); }

        protected virtual void HienMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== " + TieuDe + " =====");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine("{0}. {1}", i + 1, items[i]);
            Console.WriteLine("0. Thoát chương trình");
        }

        // Phương thức ảo: lớp con override để xử lý; mặc định sẽ phát sự kiện Choose
        protected virtual void OnChoose(int x)
        {
            EventHandler<MenuEventArgs> handler = Choose;
            if (handler != null) handler(this, new MenuEventArgs(x));
            else Console.WriteLine("Bạn thực hiện chức năng " + x);
        }

        // Vòng lặp chính của menu
        public void Run()
        {
            while (true)
            {
                HienMenu();
                int x = Nhap.SoNguyen("Thực hiện: ", 0, items.Count);
                if (x == 0) break;
                try
                {
                    OnChoose(x);
                }
                catch (Exception ex)   // lỗi trong 1 chức năng không làm sập cả chương trình
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
    }

    // ----- Áp dụng: giải phương trình bậc 2 bằng KẾ THỪA -----
    public class PTBac2Console : ConsoleMenu
    {
        private double a, b, c;
        private bool daNhap = false;

        public PTBac2Console() : base("GIẢI PHƯƠNG TRÌNH ax^2 + bx + c = 0",
                                      "Nhập hệ số a, b, c",
                                      "Giải phương trình") { }

        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }

        protected override void OnChoose(int x)
        {
            switch (x)
            {
                case 1: NhapHeSo(); break;
                case 2: Giai(); break;
                default: base.OnChoose(x); break;   // chức năng mở rộng -> chuyển cho sự kiện
            }
        }

        private void NhapHeSo()
        {
            a = Nhap.SoThuc("a = ");
            b = Nhap.SoThuc("b = ");
            c = Nhap.SoThuc("c = ");
            daNhap = true;
        }

        public static string GiaiPT(double a, double b, double c)
        {
            if (a == 0)   // suy biến thành bx + c = 0
            {
                if (b == 0) return c == 0 ? "Phương trình vô số nghiệm" : "Phương trình vô nghiệm";
                return "Phương trình bậc nhất, nghiệm x = " + (-c / b);
            }
            double delta = b * b - 4 * a * c;
            if (delta < 0) return "Phương trình vô nghiệm (Δ = " + delta + " < 0)";
            if (delta == 0) return "Phương trình có nghiệm kép x = " + (-b / (2 * a));
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return string.Format("Phương trình có 2 nghiệm: x1 = {0:0.####}, x2 = {1:0.####}", x1, x2);
        }

        private void Giai()
        {
            if (!daNhap) { Console.WriteLine("Hãy nhập hệ số trước (chức năng 1)!"); return; }
            Console.WriteLine(GiaiPT(a, b, c));
        }
    }

    public static class Bai3_4
    {
        public static void Demo()
        {
            PTBac2Console app = new PTBac2Console();

            // Mở rộng bằng SỰ KIỆN: thêm chức năng 3 mà không sửa lớp PTBac2Console
            app.AddItem("Xem hệ số đã nhập");
            app.Choose += (sender, e) =>
            {
                if (e.LuaChon == 3)
                    Console.WriteLine("a = {0}, b = {1}, c = {2}", app.A, app.B, app.C);
            };

            app.Run();
        }
    }
}
