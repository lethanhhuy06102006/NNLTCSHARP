using System;
using System.Collections;
using ThucHanh02.Chuong1;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.1: Lớp ArrayPoint chứa ArrayList các Point, có Indexer
    public class ArrayPoint
    {
        private ArrayList ds = new ArrayList();

        public ArrayPoint() { }
        public ArrayPoint(ArrayPoint other)
        {
            foreach (Point p in other.ds) ds.Add(new Point(p));   // sao chép sâu
        }

        public int Count { get { return ds.Count; } }

        // INDEXER: cho phép viết arr[i] như với mảng thông thường
        public Point this[int i]
        {
            get
            {
                if (i < 0 || i >= ds.Count) throw new IndexOutOfRangeException("Chỉ số không hợp lệ");
                return (Point)ds[i];      // ArrayList lưu object -> phải ép kiểu
            }
            set
            {
                if (i < 0 || i >= ds.Count) throw new IndexOutOfRangeException("Chỉ số không hợp lệ");
                ds[i] = value;
            }
        }

        public void Add(Point p) { ds.Add(p); }

        public void Input()
        {
            int n = Nhap.SoNguyen("Số điểm: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Điểm thứ {0}:", i);
                Point p = new Point();
                p.Input();
                Add(p);
            }
        }

        public void Output()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine("  P[{0}] = {1}", i, this[i]);
        }

        public static void Demo()
        {
            ArrayPoint arr = new ArrayPoint();
            arr.Input();
            Console.WriteLine("Danh sách điểm:");
            arr.Output();
            if (arr.Count > 0)
            {
                int i = Nhap.SoNguyen("Nhập chỉ số i muốn xem: ", 0, arr.Count - 1);
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }
        }
    }
}
