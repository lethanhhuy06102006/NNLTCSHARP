using System;
using ThucHanh02.Chuong1;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.3: Sắp xếp mảng tổng quát bằng DELEGATE
    //
    // Delegate = "kiểu dữ liệu của một hàm". Thay vì bắt T implement interface,
    // ta truyền thẳng HÀM SO SÁNH vào làm tham số -> linh hoạt hơn.
    // Quy ước: trả về < 0 nếu a đứng trước b, > 0 nếu a đứng sau b, 0 nếu bằng.
    public delegate int HamSoSanh<T>(T a, T b);

    public static class SapXepDelegate
    {
        public static void Sort<T>(T[] a, HamSoSanh<T> soSanh)
        {
            // Sắp xếp nổi bọt (bubble sort)
            for (int i = 0; i < a.Length - 1; i++)
                for (int j = 0; j < a.Length - 1 - i; j++)
                    if (soSanh(a[j], a[j + 1]) > 0)
                    {
                        T tmp = a[j]; a[j] = a[j + 1]; a[j + 1] = tmp;
                    }
        }
    }

    public static class Bai3_3
    {
        // Một hàm bình thường có chữ ký khớp với delegate HamSoSanh<int>
        static int Tang(int a, int b) { return a.CompareTo(b); }

        public static void Demo()
        {
            int[] so = { 4, 1, 7, -3, 2 };

            SapXepDelegate.Sort(so, Tang);                            // truyền tên hàm
            Console.WriteLine("Tăng dần  : " + string.Join(", ", so));

            SapXepDelegate.Sort(so, (a, b) => b.CompareTo(a));        // truyền lambda
            Console.WriteLine("Giảm dần  : " + string.Join(", ", so));

            SapXepDelegate.Sort(so, (a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
            Console.WriteLine("Theo |x|  : " + string.Join(", ", so));

            Person[] people =
            {
                new Person("1", "Hùng", 1995), new Person("2", "An", 1980), new Person("3", "Lan", 2003)
            };
            SapXepDelegate.Sort(people, (p, q) => string.Compare(p.Name, q.Name));
            Console.WriteLine("Person theo tên:");
            foreach (Person p in people) Console.WriteLine("  " + p);
        }
    }
}
