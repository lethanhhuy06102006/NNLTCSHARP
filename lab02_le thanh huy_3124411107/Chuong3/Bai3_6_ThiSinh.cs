using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.6: Tính điểm thí sinh
    //
    //              ThiSinh (abstract)   : sbd, hoTen, bai1, bai2, bai3, TongDiem
    //             /                  \
    //    ThiSinhChuyen             ThiSinhSieuCup
    //    + tiengAnh                + csdl
    //
    //  CuocThi  --chứa-->  List<ThiSinh>

    public abstract class ThiSinh
    {
        protected string sbd, hoTen;
        protected double bai1, bai2, bai3;

        protected ThiSinh() { sbd = ""; hoTen = ""; }
        protected ThiSinh(string sbd, string hoTen, double b1, double b2, double b3)
        {
            this.sbd = sbd; this.hoTen = hoTen; bai1 = b1; bai2 = b2; bai3 = b3;
        }

        protected double TongLapTrinh { get { return bai1 + bai2 + bai3; } }

        // tongdiem: property TÍNH TOÁN, mỗi loại thí sinh tính khác nhau
        public abstract double TongDiem { get; }
        public abstract string DoiTuong { get; }

        protected static double NhapDiem(string ten) { return Nhap.SoThuc("  " + ten + " (0-10): ", 0, 10); }

        public virtual void Input()
        {
            sbd = Nhap.Chuoi("  Số báo danh: ");
            hoTen = Nhap.Chuoi("  Họ tên: ");
            bai1 = NhapDiem("Bài 1");
            bai2 = NhapDiem("Bài 2");
            bai3 = NhapDiem("Bài 3");
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2,-9} {3}", sbd, hoTen, DoiTuong, ChiTiet());
        }

        protected abstract string ChiTiet();
    }

    public class ThiSinhChuyen : ThiSinh
    {
        private double tiengAnh;

        public ThiSinhChuyen() { }
        public ThiSinhChuyen(string sbd, string ten, double b1, double b2, double b3, double tiengAnh)
            : base(sbd, ten, b1, b2, b3) { this.tiengAnh = tiengAnh; }

        public override string DoiTuong { get { return "Chuyên"; } }

        // 7 <= TA <= 8: +1 ; 9 <= TA <= 10: +2 ; còn lại: +0
        // (Lưu ý: đề không nói 8 < TA < 9, ở đây xử lý TA >= 9 mới +2, 7 <= TA < 9 được +1)
        public double DiemThuong
        {
            get
            {
                if (tiengAnh >= 9) return 2;
                if (tiengAnh >= 7) return 1;
                return 0;
            }
        }

        public override double TongDiem { get { return TongLapTrinh + DiemThuong; } }

        public override void Input()
        {
            base.Input();
            tiengAnh = NhapDiem("Tiếng Anh");
        }

        protected override string ChiTiet()
        {
            return string.Format("LT: {0}+{1}+{2}, TA: {3} (thưởng {4}) => Tổng: {5}",
                bai1, bai2, bai3, tiengAnh, DiemThuong, TongDiem);
        }
    }

    public class ThiSinhSieuCup : ThiSinh
    {
        private double csdl;

        public ThiSinhSieuCup() { }
        public ThiSinhSieuCup(string sbd, string ten, double b1, double b2, double b3, double csdl)
            : base(sbd, ten, b1, b2, b3) { this.csdl = csdl; }

        public override string DoiTuong { get { return "Siêu cúp"; } }

        public override double TongDiem { get { return TongLapTrinh + csdl; } }

        public override void Input()
        {
            base.Input();
            csdl = NhapDiem("CSDL");
        }

        protected override string ChiTiet()
        {
            return string.Format("LT: {0}+{1}+{2}, CSDL: {3} => Tổng: {4}", bai1, bai2, bai3, csdl, TongDiem);
        }
    }

    public class CuocThi
    {
        private List<ThiSinh> ds = new List<ThiSinh>();

        public void Add(ThiSinh ts) { ds.Add(ts); }

        public void Input()
        {
            int n = Nhap.SoNguyen("Số thí sinh: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Thí sinh {0}:", i + 1);
                int loai = Nhap.SoNguyen("  Đối tượng (1 = Chuyên, 2 = Siêu cúp): ", 1, 2);
                ThiSinh ts = (loai == 1) ? (ThiSinh)new ThiSinhChuyen() : new ThiSinhSieuCup();
                ts.Input();
                ds.Add(ts);
            }
        }

        public void Output()
        {
            Console.WriteLine("KẾT QUẢ CUỘC THI:");
            foreach (ThiSinh ts in ds) Console.WriteLine("  " + ts);
        }

        public static void Demo()
        {
            CuocThi ct = new CuocThi();
            ct.Input();
            ct.Output();
        }
    }
}
