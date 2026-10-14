using System;

namespace Bai14
{
    class NhanVien
    {
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        private const double TIEN_TRU_MOI_NGAY = 100000;

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap muc luong: ");
            MucLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }

        public double TinhLuong()
        {
            double luong = MucLuong - SoNgayVang * TIEN_TRU_MOI_NGAY;
            return luong < 0 ? 0 : luong;
        }

        public void Xuat()
        {
            Console.WriteLine("\n----- LUONG NHAN VIEN -----");
            Console.WriteLine("Ho ten     : " + HoTen);
            Console.WriteLine("Muc luong  : " + MucLuong.ToString("N0") + " VND");
            Console.WriteLine("So ngay vang: " + SoNgayVang);
            Console.WriteLine("Luong thuc nhan: " + TinhLuong().ToString("N0") + " VND");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NhanVien nv = new NhanVien();
            nv.Nhap();
            nv.Xuat();
        }
    }
}