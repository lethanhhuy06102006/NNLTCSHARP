using System;

namespace Bai12
{
    class XuLyChuoi
    {
        public string ChuyenThuong(string s) => s.ToLower();

        public string ChuyenHoa(string s) => s.ToUpper();

        public int DemSoTu(string s)
        {
            string[] tuMang = s.Split(new char[] { ' ' },
                                       StringSplitOptions.RemoveEmptyEntries);
            return tuMang.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap chuoi gom nhieu tu: ");
            string s = Console.ReadLine();

            XuLyChuoi xl = new XuLyChuoi();
            Console.WriteLine("Chuoi chu thuong: " + xl.ChuyenThuong(s));
            Console.WriteLine("Chuoi chu hoa: " + xl.ChuyenHoa(s));
            Console.WriteLine("So tu trong chuoi: " + xl.DemSoTu(s));
        }
    }
}