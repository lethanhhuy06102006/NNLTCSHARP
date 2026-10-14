using System;
using System.Collections.Generic;
using ThucHanh02.Chuong1;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.4 (dãy phân số): lớp chứa n phân số, tính tổng
    public class DayPhanSo
    {
        private List<PhanSo> ds = new List<PhanSo>();

        public DayPhanSo() { }
        public DayPhanSo(DayPhanSo other)
        {
            foreach (PhanSo p in other.ds) ds.Add(new PhanSo(p));
        }

        public int Count { get { return ds.Count; } }
        public PhanSo this[int i] { get { return ds[i]; } set { ds[i] = value; } }

        public void Add(PhanSo p) { ds.Add(p); }

        public void Input()
        {
            int n = Nhap.SoNguyen("Số phân số n: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Phân số thứ {0}:", i + 1);
                PhanSo p = new PhanSo();
                p.Input();
                ds.Add(p);
            }
        }

        public void Output() { Console.WriteLine(string.Join("  ;  ", ds)); }

        // Nhờ đã overload toán tử + ở Bài 1.4 nên cộng phân số tự nhiên như cộng số
        public PhanSo Tong()
        {
            PhanSo s = new PhanSo();   // 0
            foreach (PhanSo p in ds) s = s + p;
            return s;
        }

        public static void Demo()
        {
            DayPhanSo d = new DayPhanSo();
            d.Input();
            Console.Write("Dãy: "); d.Output();
            Console.WriteLine("Tổng = " + d.Tong());
        }
    }
}
