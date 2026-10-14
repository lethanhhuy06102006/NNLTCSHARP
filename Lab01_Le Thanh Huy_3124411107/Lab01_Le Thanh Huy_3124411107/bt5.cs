using System;

namespace Bai5
{
    class Program
    {
        // Tham trị (pass by value) - x, y chỉ dùng để đọc
        static double TinhLuyThua(double x, double y)
        {
            return Math.Pow(x, y);
        }

        // Tham chiếu ref - biến truyền vào phải được khởi tạo trước,
        // phương thức có thể đọc và ghi lại giá trị mới
        static void HoanVi(ref double a, ref double b)
        {
            double tam = a;
            a = b;
            b = tam;
        }

        // Tham chiếu out - biến truyền vào không cần khởi tạo trước,
        // bắt buộc phương thức phải gán giá trị cho nó trước khi return
        static void CanBacHai(double x, double y, out double canX, out double canY)
        {
            canX = x >= 0 ? Math.Sqrt(x) : double.NaN;
            canY = y >= 0 ? Math.Sqrt(y) : double.NaN;
        }

        static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool daNhap = false;
            int luaChon;

            do
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                int.TryParse(Console.ReadLine(), out luaChon);

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhap x: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Nhap y: ");
                        y = double.Parse(Console.ReadLine());
                        daNhap = true;
                        break;

                    case 2:
                        if (!daNhap) { Console.WriteLine("Ban chua nhap x, y!"); break; }
                        Console.WriteLine("{0}^{1} = {2}", x, y, TinhLuyThua(x, y));
                        break;

                    case 3:
                        if (!daNhap) { Console.WriteLine("Ban chua nhap x, y!"); break; }
                        double canX, canY;
                        CanBacHai(x, y, out canX, out canY);
                        Console.WriteLine("Can bac 2 cua x = {0}", canX);
                        Console.WriteLine("Can bac 2 cua y = {0}", canY);
                        break;

                    case 4:
                        Console.WriteLine("Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (luaChon != 4);
        }
    }
}