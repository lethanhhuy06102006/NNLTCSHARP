using System;

namespace Bai16
{
    class XuLyMang
    {
        public string[] NhapMangHoTen(int n)
        {
            string[] ds = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap ho ten nguoi thu {0}: ", i + 1);
                ds[i] = Console.ReadLine();
            }
            return ds;
        }

        public void SapXepTangDan(string[] ds)
        {
            for (int i = 0; i < ds.Length - 1; i++)
            {
                for (int j = i + 1; j < ds.Length; j++)
                {
                    if (string.Compare(ds[i], ds[j], StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        string tam = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tam;
                    }
                }
            }
        }

        public void InMang(string[] ds)
        {
            foreach (string s in ds)
                Console.WriteLine(s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XuLyMang xl = new XuLyMang();

            Console.Write("Nhap so nguoi n: ");
            int n = int.Parse(Console.ReadLine());

            string[] ds = xl.NhapMangHoTen(n);
            xl.SapXepTangDan(ds);

            Console.WriteLine("\nDanh sach sau khi sap xep tang dan:");
            xl.InMang(ds);
        }
    }
}