using System;
using ThucHanh02.Common;

namespace ThucHanh02.Chuong1
{
    // BÀI 1.3: Lớp Person
    public class Person
    {
        private string id;
        private string name;
        private int yob;   // năm sinh
        private int yod;   // năm mất (0 = còn sống)

        public Person() { id = ""; name = ""; yob = 0; yod = 0; }                 // default
        public Person(string id, string name, int yob, int yod = 0)
        {
            this.id = id; this.name = name; this.yob = yob; this.yod = yod;
        }
        public Person(Person p) : this(p.id, p.name, p.yob, p.yod) { }            // copy

        public string Id   { get { return id; }   set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Yob     { get { return yob; }  set { yob = value; } }
        public int Yod     { get { return yod; }  set { yod = value; } }

        public void Input()
        {
            id = Nhap.Chuoi("  Mã: ");
            name = Nhap.Chuoi("  Họ tên: ");
            yob = Nhap.SoNguyen("  Năm sinh: ", 1, DateTime.Now.Year);
            // năm mất phải bằng 0 (còn sống) hoặc >= năm sinh
            while (true)
            {
                yod = Nhap.SoNguyen("  Năm mất (0 nếu còn sống): ", 0, DateTime.Now.Year);
                if (yod == 0 || yod >= yob) break;
                Console.WriteLine("  -> Năm mất phải >= năm sinh!");
            }
        }

        public void Output() { Console.WriteLine(this); }

        // Còn sống khi chưa có năm mất
        public bool IsLiving() { return yod == 0; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}, sinh {2}, {3}", id, name, yob,
                IsLiving() ? "còn sống" : "mất năm " + yod);
        }

        public static void Demo()
        {
            Person p = new Person();
            Console.WriteLine("Nhập thông tin một người:");
            p.Input();
            Person q = new Person(p);   // copy constructor: q là bản sao ĐỘC LẬP của p
            q.Name = q.Name + " (bản sao)";
            p.Output();
            q.Output();
            Console.WriteLine("IsLiving() = {0}", p.IsLiving());
        }
    }
}
