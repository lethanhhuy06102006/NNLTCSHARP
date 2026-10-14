using System;
using System.Text;
using ThucHanh02.Chuong1;
using ThucHanh02.Chuong2;
using ThucHanh02.Chuong3;

namespace ThucHanh02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   // hiển thị được tiếng Việt
            Console.InputEncoding = Encoding.UTF8;

            // Danh sách bài tập: tên + hàm Demo tương ứng (Action là một delegate có sẵn)
            string[] ten =
            {
                "Bài 1.1 - Tính tuổi sinh viên",
                "Bài 1.2 - Lớp Point (khoảng cách, trung điểm)",
                "Bài 1.3 - Lớp Person",
                "Bài 1.4 - Lớp Phân số",
                "Bài 1.5 - Lớp Đơn thức",
                "Bài 2.1 - ArrayPoint (Indexer)",
                "Bài 2.2 - PersonList",
                "Bài 2.3 - Dãy số (mảng 1 chiều)",
                "Bài 2.4 - Mảng 2 chiều, tìm số nguyên tố",
                "Bài 2.3' - Đa thức",
                "Bài 2.4' - Dãy phân số",
                "Bài 2.5 - Tổng lương phòng ban",
                "Bài 3.1 - Array.Sort với IComparable / IComparer",
                "Bài 3.2 - Sắp xếp tổng quát bằng interface",
                "Bài 3.3 - Sắp xếp tổng quát bằng delegate",
                "Bài 3.4 - ConsoleMenu + phương trình bậc 2",
                "Bài 3.5 - Lương nhân viên (kế thừa, đa hình)",
                "Bài 3.6 - Tính điểm thí sinh",
            };
            Action[] demo =
            {
                SinhVien.Demo, Point.Demo, Person.Demo, PhanSo.Demo, DonThuc.Demo,
                ArrayPoint.Demo, PersonList.Demo, DaySo.Demo, MaTran.Demo, DaThuc.Demo,
                DayPhanSo.Demo, PhongBan.Demo,
                Bai3_1.Demo, Bai3_2.Demo, Bai3_3.Demo, Bai3_4.Demo, CongTy.Demo, CuocThi.Demo,
            };

            // Chính menu chính cũng dùng lại lớp ConsoleMenu của Bài 3.4 (mở rộng bằng sự kiện)
            ConsoleMenu menu = new ConsoleMenu("THỰC HÀNH 02 - LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG C#", ten);
            menu.Choose += (sender, e) =>
            {
                Console.WriteLine("\n----- " + ten[e.LuaChon - 1] + " -----");
                demo[e.LuaChon - 1]();
            };
            menu.Run();
        }
    }
}
