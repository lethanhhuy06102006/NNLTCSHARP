using System;

namespace Bai10
{
    class XuLyChuoi
    {
        public bool LaDoiXung(string s)
        {
            string chuoiDao = "";
            for (int i = s.Length - 1; i >= 0; i--)
                chuoiDao += s[i];

            return s.Equals(chuoiDao, StringComparison.OrdinalIgnoreCase);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            XuLyChuoi xl = new XuLyChuoi();
            if (xl.LaDoiXung(s))
                Console.WriteLine("Chuoi \"{0}\" la doi xung", s);
            else
                Console.WriteLine("Chuoi \"{0}\" khong doi xung", s);
        }
    }
}