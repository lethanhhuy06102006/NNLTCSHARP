
using System;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong1
{
    // BÀI 1.1: Tính tuổi sinh viên
    public class SinhVien
    {
        // ----- Field: dữ liệu được che giấu (private) -----
        private string hoTen;
        private int namSinh;

        // ----- Constructor -----
        public SinhVien() : this("Chưa đặt tên", 2000) { }           // mặc định
        public SinhVien(string hoTen, int namSinh)                   // có tham số
        {
            HoTen = hoTen;
            NamSinh = namSinh;
        }
        public SinhVien(SinhVien other) : this(other.hoTen, other.namSinh) { } // sao chép

        // ----- Property: cổng truy cập có kiểm tra dữ liệu -----
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = string.IsNullOrWhiteSpace(value) ? "Chưa đặt tên" : value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new ArgumentException("Năm sinh không hợp lệ");
                namSinh = value;
            }
        }

        // Property chỉ đọc, được TÍNH ra chứ không lưu
        public int Tuoi
        {
            get { return DateTime.Now.Year - namSinh; }
        }

        // ----- Method -----
        public void Input()
        {
            HoTen = Nhap.Chuoi("Họ tên: ");
            NamSinh = Nhap.SoNguyen("Năm sinh: ", 1900, DateTime.Now.Year);
        }

        public void Output()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return string.Format("Sinh viên: {0}, năm sinh {1}, tuổi {2}", hoTen, namSinh, Tuoi);
        }

        public static void Demo()
        {
            SinhVien sv = new SinhVien();
            sv.Input();
            sv.Output();
        }
    }
}
