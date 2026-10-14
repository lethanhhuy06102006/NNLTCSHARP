using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.5: Tính lương nhân viên của phòng ban
    public class NhanVien
    {
        public const double TIEN_PHAT_MOT_NGAY = 100000;   // hằng số: dễ sửa, không "số ma thuật"

        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        public NhanVien() : this("", 0, 0) { }
        public NhanVien(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen; this.mucLuong = mucLuong; this.soNgayVang = soNgayVang;
        }

        public string HoTen { get { return hoTen; } }

        // Lương thực nhận = mức lương - số ngày vắng * 100.000 (không âm)
        public double Luong
        {
            get { return Math.Max(0, mucLuong - soNgayVang * TIEN_PHAT_MOT_NGAY); }
        }

        public void Input()
        {
            hoTen = Nhap.Chuoi("  Họ tên: ");
            mucLuong = Nhap.SoThuc("  Mức lương: ", 0, double.MaxValue);
            soNgayVang = Nhap.SoNguyen("  Số ngày vắng: ", 0, 31);
        }

        public override string ToString()
        {
            return string.Format("{0,-20} lương {1,12:N0} - vắng {2} ngày => thực nhận {3,12:N0}",
                hoTen, mucLuong, soNgayVang, Luong);
        }
    }

    public class PhongBan
    {
        private List<NhanVien> ds = new List<NhanVien>();

        public void Input()
        {
            int n = Nhap.SoNguyen("Số nhân viên: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhân viên {0}:", i + 1);
                NhanVien nv = new NhanVien();
                nv.Input();
                ds.Add(nv);
            }
        }

        public void Output() { foreach (NhanVien nv in ds) Console.WriteLine("  " + nv); }

        public double TongLuong()
        {
            double s = 0;
            foreach (NhanVien nv in ds) s += nv.Luong;
            return s;
        }

        public static void Demo()
        {
            PhongBan pb = new PhongBan();
            pb.Input();
            pb.Output();
            Console.WriteLine("TỔNG LƯƠNG PHÒNG BAN: {0:N0} VNĐ", pb.TongLuong());
        }
    }
}
