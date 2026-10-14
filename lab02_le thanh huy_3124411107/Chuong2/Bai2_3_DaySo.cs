using System;
using System.Collections.Generic;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.3: Lớp dãy số chứa mảng 1 chiều n số nguyên
    public class DaySo
    {
        private int[] a;

        // a. Các loại constructor
        public DaySo() { a = new int[0]; }                       // mặc định: dãy rỗng
        public DaySo(int n) { a = new int[n]; }                  // n phần tử = 0
        public DaySo(int[] arr) { a = (int[])arr.Clone(); }      // từ mảng có sẵn
        public DaySo(DaySo other) : this(other.a) { }            // sao chép

        public int Length { get { return a.Length; } }

        // b. Indexer
        public int this[int i]
        {
            get { KiemTra(i); return a[i]; }
            set { KiemTra(i); a[i] = value; }
        }

        private void KiemTra(int i)
        {
            if (i < 0 || i >= a.Length)
                throw new IndexOutOfRangeException("Chỉ số " + i + " nằm ngoài dãy");
        }

        // c. Nhập / Xuất
        public void Input()
        {
            int n = Nhap.SoNguyen("Số phần tử n: ", 0, 10000);
            a = new int[n];
            for (int i = 0; i < n; i++) a[i] = Nhap.SoNguyen("  a[" + i + "] = ");
        }

        public void Output() { Console.WriteLine(this); }

        public override string ToString()
        {
            return "[" + string.Join(", ", a) + "]";
        }

        // d. Tìm các số chẵn -> trả về một DaySo mới
        public DaySo TimSoChan()
        {
            List<int> chan = new List<int>();
            foreach (int x in a) if (x % 2 == 0) chan.Add(x);
            return new DaySo(chan.ToArray());
        }

        public static void Demo()
        {
            DaySo d = new DaySo();
            d.Input();
            Console.Write("Dãy vừa nhập: "); d.Output();
            Console.Write("Các số chẵn : "); d.TimSoChan().Output();
        }
    }
}
