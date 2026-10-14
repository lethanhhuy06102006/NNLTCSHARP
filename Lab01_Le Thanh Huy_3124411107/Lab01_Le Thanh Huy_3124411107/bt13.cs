using System;

namespace Bai13
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamThu { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Nhap sinh vien nam thu: ");
            NamThu = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("\n----- THONG TIN SINH VIEN -----");
            Console.WriteLine("Ma sinh vien : " + MaSV);
            Console.WriteLine("Ho ten       : " + HoTen);
            Console.WriteLine("Dia chi      : " + DiaChi);
            Console.WriteLine("Sinh vien nam thu: " + NamThu);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinhVien sv = new SinhVien();
            sv.Nhap();
            sv.Xuat();
        }
    }
}