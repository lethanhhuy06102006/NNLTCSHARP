using System;
using System.Collections.Generic;
using ThucHanh02.Chuong1;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong2
{
    // BÀI 2.2: PersonList quản lý nhiều Person
    public class PersonList
    {
        private List<Person> ds;

        public PersonList() { ds = new List<Person>(); }               // default
        public PersonList(PersonList other)                            // copy (sao chép sâu)
        {
            ds = new List<Person>();
            foreach (Person p in other.ds) ds.Add(new Person(p));
        }

        public int Count { get { return ds.Count; } }
        public Person this[int i] { get { return ds[i]; } }

        public void Add(Person x) { ds.Add(x); }

        public void Input()
        {
            int n = Nhap.SoNguyen("Số người: ", 0, 1000);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Người thứ {0}:", i + 1);
                Person p = new Person();
                p.Input();
                Add(p);
            }
        }

        public void Output()
        {
            if (ds.Count == 0) { Console.WriteLine("  (danh sách rỗng)"); return; }
            foreach (Person p in ds) Console.WriteLine("  " + p);
        }

        // Trả về một PersonList MỚI chỉ gồm những người còn sống
        public PersonList LivingPeople()
        {
            PersonList kq = new PersonList();
            foreach (Person p in ds)
                if (p.IsLiving()) kq.Add(p);
            return kq;
        }

        public static void Demo()
        {
            PersonList list = new PersonList();
            list.Input();
            Console.WriteLine("Toàn bộ danh sách:");
            list.Output();
            Console.WriteLine("Những người còn sống:");
            list.LivingPeople().Output();
        }
    }
}
