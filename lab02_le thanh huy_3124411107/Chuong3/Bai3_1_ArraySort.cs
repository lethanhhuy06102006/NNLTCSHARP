using System;
using System.Collections.Generic;
using ThucHanh02.Chuong1;

namespace ThucHanh02.Chuong3
{
    // BÀI 3.1: Dùng Array.Sort(...) để sắp xếp đối tượng của lớp tự định nghĩa
    //
    // Array.Sort cần biết "đối tượng nào lớn hơn". Có 2 cách cho nó biết:
    //   Cách 1: lớp tự implement IComparable<T>  (thứ tự "tự nhiên")   -> Array.Sort(arr)
    //   Cách 2: viết lớp riêng implement IComparer<T> (thứ tự tuỳ chọn) -> Array.Sort(arr, comparer)

    // Cách 2: so sánh Person theo năm sinh
    public class SoSanhTheoNamSinh : IComparer<Person>
    {
        public int Compare(Person a, Person b) { return a.Yob.CompareTo(b.Yob); }
    }

    // Cách 2: so sánh Person theo tên
    public class SoSanhTheoTen : IComparer<Person>
    {
        public int Compare(Person a, Person b) { return string.Compare(a.Name, b.Name, StringComparison.CurrentCulture); }
    }

    public static class Bai3_1
    {
        public static void Demo()
        {
            // Cách 1: PhanSo đã implement IComparable<PhanSo> (xem Bai1_4_PhanSo.cs)
            PhanSo[] ps = { new PhanSo(3, 4), new PhanSo(-1, 2), new PhanSo(5, 6), new PhanSo(1, 3), new PhanSo(2) };
            Console.WriteLine("Phân số trước khi sắp xếp: " + string.Join("  ", (object[])ps));
            Array.Sort(ps);
            Console.WriteLine("Sau Array.Sort(ps)       : " + string.Join("  ", (object[])ps));

            // Cách 2: IComparer
            Person[] people =
            {
                new Person("P1", "Trần Văn Bình", 1990),
                new Person("P2", "Lê Thị An", 1985),
                new Person("P3", "Nguyễn Chí Cường", 2001, 2020),
            };
            Array.Sort(people, new SoSanhTheoNamSinh());
            Console.WriteLine("\nPerson sắp theo năm sinh:");
            foreach (Person p in people) Console.WriteLine("  " + p);

            Array.Sort(people, new SoSanhTheoTen());
            Console.WriteLine("Person sắp theo tên:");
            foreach (Person p in people) Console.WriteLine("  " + p);
        }
    }
}
