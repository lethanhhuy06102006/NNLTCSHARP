using System;
using System.Text;

namespace Bai11
{
    class XuLyChuoi
    {
        public string DaoChuoi(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            XuLyChuoi xl = new XuLyChuoi();
            Console.WriteLine("Chuoi dao nguoc: " + xl.DaoChuoi(s));
        }
    }
}