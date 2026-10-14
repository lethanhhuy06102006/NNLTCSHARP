using System;
using System.Globalization;

namespace ThucHanh02.Common
{
    // Lớp tiện ích nhập liệu an toàn: nhập sai thì bắt nhập lại, không làm chương trình bị crash.
    public static class Nhap
    {
        public static string Chuoi(string loiNhac)
        {
            Console.Write(loiNhac);
            string s = Console.ReadLine();
            if (s == null) Environment.Exit(0);   // hết dữ liệu vào (Ctrl+Z / EOF) -> thoát
            return s.Trim();
        }

        public static int SoNguyen(string loiNhac)
        {
            while (true)
            {
                int kq;
                if (int.TryParse(Chuoi(loiNhac), out kq)) return kq;
                Console.WriteLine("  -> Giá trị không hợp lệ, hãy nhập một số nguyên!");
            }
        }

        public static int SoNguyen(string loiNhac, int min, int max)
        {
            while (true)
            {
                int kq = SoNguyen(loiNhac);
                if (kq >= min && kq <= max) return kq;
                Console.WriteLine("  -> Hãy nhập số trong khoảng [{0}, {1}]!", min, max);
            }
        }

        public static double SoThuc(string loiNhac)
        {
            while (true)
            {
                // Chấp nhận cả dấu phẩy và dấu chấm làm dấu thập phân
                string s = Chuoi(loiNhac).Replace(',', '.');
                double kq;
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out kq)) return kq;
                Console.WriteLine("  -> Giá trị không hợp lệ, hãy nhập một số thực!");
            }
        }

        public static double SoThuc(string loiNhac, double min, double max)
        {
            while (true)
            {
                double kq = SoThuc(loiNhac);
                if (kq >= min && kq <= max) return kq;
                Console.WriteLine("  -> Hãy nhập số trong khoảng [{0}, {1}]!", min, max);
            }
        }
    }
}
