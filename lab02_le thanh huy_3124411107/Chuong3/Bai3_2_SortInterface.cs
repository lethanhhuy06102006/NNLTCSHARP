using System;
using System.Collections.Generic;
using ThucHanh02.Chuong1;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.2: Tự viết hàm sắp xếp TỔNG QUÁT bằng interface (mô phỏng Array.Sort)
    //
    // Ý tưởng: thuật toán sắp xếp không cần biết T là gì, chỉ cần T "so sánh được".
    // Ràng buộc "where T : IComparable<T>" đảm bảo điều đó ngay lúc biên dịch.
    public static class SapXep
    {
        // Mô phỏng Array.Sort(arr)
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            // Sắp xếp chọn (selection sort) cho dễ hiểu
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                    if (a[j].CompareTo(a[min]) < 0) min = j;
                Swap(a, i, min);
            }
        }

        // Mô phỏng Array.Sort(arr, comparer)
        public static void Sort<T>(T[] a, IComparer<T> cmp)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                    if (cmp.Compare(a[j], a[min]) < 0) min = j;
                Swap(a, i, min);
            }
        }

        private static void Swap<T>(T[] a, int i, int j)
        {
            T tmp = a[i]; a[i] = a[j]; a[j] = tmp;
        }
    }

    public static class Bai3_2
    {
        public static void Demo()
        {
            int[] so = { 5, -2, 9, 0, 3 };                // int có sẵn IComparable<int>
            SapXep.Sort(so);
            Console.WriteLine("Số nguyên : " + string.Join(", ", so));

            string[] ten = { "Minh", "An", "Hoa", "Bảo" };
            SapXep.Sort(ten);
            Console.WriteLine("Chuỗi     : " + string.Join(", ", ten));

            PhanSo[] ps = { new PhanSo(1, 2), new PhanSo(-3, 4), new PhanSo(2, 3) };
            SapXep.Sort(ps);                               // PhanSo của ta cũng dùng được!
            Console.WriteLine("Phân số   : " + string.Join(", ", (object[])ps));

            Person[] people = { new Person("1", "B", 2000), new Person("2", "A", 1970) };
            SapXep.Sort(people, new SoSanhTheoNamSinh());  // dùng IComparer từ Bài 3.1
            Console.WriteLine("Person theo năm sinh:");
            foreach (Person p in people) Console.WriteLine("  " + p);
        }
    }
}
