using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.5: Tính lương nhân viên – KẾ THỪA và ĐA HÌNH
    //
    //            NhanVien (abstract)
    //           /                  \
    //  NVKinhDoanh               NVSanXuat
    //
    // Lớp cha chứa phần CHUNG (mã, họ tên). Mỗi lớp con tự định nghĩa cách tính lương.

    public abstract class NhanVien
    {
        protected string maNV;
        protected string hoTen;

        protected NhanVien() { maNV = ""; hoTen = ""; }
        protected NhanVien(string maNV, string hoTen) { this.maNV = maNV; this.hoTen = hoTen; }

        // abstract: lớp cha KHÔNG biết tính lương thế nào -> bắt buộc lớp con cài đặt
        public abstract double TinhLuong();

        public abstract string LoaiNV { get; }

        // virtual: lớp cha có sẵn phần nhập chung, lớp con override để nhập thêm
        public virtual void Input()
        {
            maNV = Nhap.Chuoi("  Mã NV: ");
            hoTen = Nhap.Chuoi("  Họ tên: ");
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2,-12} Lương: {3,14:N0}", maNV, hoTen, LoaiNV, TinhLuong());
        }
    }

    public class NVKinhDoanh : NhanVien
    {
        public const double THUONG_MOI_HOP_DONG = 500000;
        private double luongCoBan;
        private int soHopDong;

        public NVKinhDoanh() { }
        public NVKinhDoanh(string ma, string ten, double luongCoBan, int soHopDong) : base(ma, ten)
        {
            this.luongCoBan = luongCoBan; this.soHopDong = soHopDong;
        }

        public override string LoaiNV { get { return "Kinh doanh"; } }

        public override void Input()
        {
            base.Input();                                   // nhập phần chung của lớp cha
            luongCoBan = Nhap.SoThuc("  Lương cơ bản: ", 0, double.MaxValue);
            soHopDong = Nhap.SoNguyen("  Số hợp đồng: ", 0, int.MaxValue);
        }

        public override double TinhLuong()
        {
            return luongCoBan + soHopDong * THUONG_MOI_HOP_DONG;
        }
    }

    public class NVSanXuat : NhanVien
    {
        public const double DON_GIA = 1000;
        public const int NGUONG_THUONG = 3000;
        private int soSanPham;

        public NVSanXuat() { }
        public NVSanXuat(string ma, string ten, int soSanPham) : base(ma, ten) { this.soSanPham = soSanPham; }

        public override string LoaiNV { get { return "Sản xuất"; } }

        public override void Input()
        {
            base.Input();
            soSanPham = Nhap.SoNguyen("  Số sản phẩm: ", 0, int.MaxValue);
        }

        public override double TinhLuong()
        {
            double luong = soSanPham * DON_GIA;
            if (soSanPham > NGUONG_THUONG) luong *= 1.05;   // thưởng thêm 5%
            return luong;
        }
    }

    public class CongTy
    {
        // Một List kiểu LỚP CHA chứa được mọi loại nhân viên con -> ĐA HÌNH
        private List<NhanVien> ds = new List<NhanVien>();

        public void Input()
        {
            int n = Nhap.SoNguyen("Số nhân viên: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhân viên {0}:", i + 1);
                int loai = Nhap.SoNguyen("  Loại (1 = Kinh doanh, 2 = Sản xuất): ", 1, 2);
                NhanVien nv = (loai == 1) ? (NhanVien)new NVKinhDoanh() : new NVSanXuat();
                nv.Input();          // tự gọi đúng Input() của lớp con
                ds.Add(nv);
            }
        }

        public void Output()
        {
            double tong = 0;
            foreach (NhanVien nv in ds)
            {
                Console.WriteLine(nv);   // TinhLuong() được gọi đúng phiên bản của từng lớp con
                tong += nv.TinhLuong();
            }
            Console.WriteLine("Tổng quỹ lương: {0:N0} VNĐ", tong);
        }

        public static void Demo()
        {
            CongTy ct = new CongTy();
            ct.Input();
            ct.Output();
        }
    }
}
