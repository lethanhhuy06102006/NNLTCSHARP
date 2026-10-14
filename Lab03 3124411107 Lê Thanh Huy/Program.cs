using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiThucHanhLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Bai21();
            Bai22();
            Bai31();
            Bai32();
            Bai41();
            Bai51();
            Bai52();
            Bai61();
            Bai62();

            Console.WriteLine();
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // ============================================================
        // BÀI 2.1: TRUY VẤN MẢNG SỐ NGUYÊN
        // ============================================================
        static void Bai21()
        {
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            InTieuDeBai("BÀI 2.1: TRUY VẤN MẢNG SỐ NGUYÊN");
            InDanhSach("Mảng ban đầu", mangSo);

            Bai21_CauA(mangSo);
            Bai21_CauB(mangSo);
            Bai21_CauC(mangSo);
        }

        // a. Liệt kê các phần tử chia hết cho 4 và 3 (chia hết cho cả hai)
        static void Bai21_CauA(int[] mangSo)
        {
            InTieuDeCau("Câu a: Các phần tử chia hết cho cả 4 và 3");

            var qs = from so in mangSo
                     where so % 4 == 0 && so % 3 == 0
                     select so;

            var ms = mangSo.Where(so => so % 4 == 0 && so % 3 == 0);

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
        static void Bai21_CauB(int[] mangSo)
        {
            InTieuDeCau("Câu b: Các phần tử nhỏ hơn hoặc bằng 3");

            var qs = from so in mangSo
                     where so <= 3
                     select so;

            var ms = mangSo.Where(so => so <= 3);

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // c. Dãy mới: số chẵn chia đôi, số lẻ giữ nguyên
        static void Bai21_CauC(int[] mangSo)
        {
            InTieuDeCau("Câu c: Dãy mới (số chẵn chia đôi, số lẻ giữ nguyên)");

            var qs = from so in mangSo
                     select so % 2 == 0 ? so / 2 : so;

            var ms = mangSo.Select(so => so % 2 == 0 ? so / 2 : so);

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // ============================================================
        // BÀI 2.2: TRUY VẤN MẢNG CHUỖI
        // ============================================================
        static void Bai22()
        {
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
                                   "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            Console.WriteLine();
            InTieuDeBai("BÀI 2.2: TRUY VẤN MẢNG CHUỖI");
            InDanhSach("Mảng ban đầu", mangChuoi);

            Bai22_CauA(mangChuoi);
            Bai22_CauB(mangChuoi);
            Bai22_CauC(mangChuoi);
            Bai22_CauD(mangChuoi);
        }

        // a. Phần tử có 4 ký tự, sắp xếp tăng dần theo ký tự đầu tiên
        // Lưu ý: sắp theo char (so sánh mã Unicode) nên chữ HOA đứng trước chữ thường.
        static void Bai22_CauA(string[] mangChuoi)
        {
            InTieuDeCau("Câu a: Phần tử có 4 ký tự, sắp xếp tăng dần theo ký tự đầu");

            var qs = from s in mangChuoi
                     where s.Length == 4
                     orderby s[0]
                     select s;

            var ms = mangChuoi
                .Where(s => s.Length == 4)
                .OrderBy(s => s[0]);

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // b. Biến đổi mỗi phần tử thành: <chữ thường> - <CHỮ HOA>
        static void Bai22_CauB(string[] mangChuoi)
        {
            InTieuDeCau("Câu b: Dạng <chữ thường> - <CHỮ HOA>");

            var qs = from s in mangChuoi
                     select $"{s.ToLower()} - {s.ToUpper()}";

            var ms = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // c. Phần tử có chứa ký tự 'u' (không tính 'ú', 'ù', 'ủ'...)
        static void Bai22_CauC(string[] mangChuoi)
        {
            InTieuDeCau("Câu c: Phần tử có chứa ký tự 'u'");

            var qs = from s in mangChuoi
                     where s.Contains('u')
                     select s;

            var ms = mangChuoi.Where(s => s.Contains('u'));

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);
        }

        // d. Chọn các phần tử bắt đầu bằng chữ in hoa để ghép thành "Thúy Kiều Thúy Vân"
        static void Bai22_CauD(string[] mangChuoi)
        {
            InTieuDeCau("Câu d: Phần tử bắt đầu bằng chữ in hoa");

            var qs = from s in mangChuoi
                     where char.IsUpper(s[0])
                     select s;

            var ms = mangChuoi.Where(s => char.IsUpper(s[0]));

            InDanhSach("Query Syntax ", qs);
            InDanhSach("Method Syntax", ms);

            // Ghép thành một câu hoàn chỉnh
            Console.WriteLine($"Câu ghép (Query Syntax) : {string.Join(" ", qs)}");
            Console.WriteLine($"Câu ghép (Method Syntax): {string.Join(" ", ms)}");
        }

        // ============================================================
        // CÁC PHƯƠNG THỨC HỖ TRỢ IN KẾT QUẢ
        // ============================================================
        static void InTieuDeBai(string tieuDe)
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(tieuDe);
            Console.WriteLine(new string('=', 60));
        }

        static void InTieuDeCau(string tieuDe)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {tieuDe} ---");
        }

        // In nhãn trước, sau đó mới in dữ liệu; xử lý cả trường hợp rỗng
        static void InDanhSach<T>(string nhan, IEnumerable<T> duLieu)
        {
            var ketQua = duLieu.ToList();
            string noiDung = ketQua.Any()
                ? string.Join(", ", ketQua)
                : "(không có phần tử nào)";
            Console.WriteLine($"{nhan}: {noiDung}");
        }
        // ============================================================
        // BÀI 3.1: THỐNG KÊ MẢNG SỐ
        // ============================================================
        static void Bai31()
        {
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Console.WriteLine();
            InTieuDeBai("BÀI 3.1: THỐNG KÊ MẢNG SỐ");
            InDanhSach("Mảng ban đầu", mangSo);

            Bai31_CauA(mangSo);
            Bai31_CauB(mangSo);
            Bai31_CauC(mangSo);
            Bai31_CauD(mangSo);
        }

        // a. Tổng số phần tử, số phần tử chẵn, số phần tử lẻ
        static void Bai31_CauA(int[] mangSo)
        {
            InTieuDeCau("Câu a: Tổng số phần tử, số phần tử chẵn, số phần tử lẻ");

            // Query Syntax (Count phải gọi qua dấu ngoặc)
            int tongQs = (from so in mangSo select so).Count();
            int chanQs = (from so in mangSo where so % 2 == 0 select so).Count();
            int leQs = (from so in mangSo where so % 2 != 0 select so).Count();

            // Method Syntax
            int tongMs = mangSo.Count();
            int chanMs = mangSo.Count(so => so % 2 == 0);
            int leMs = mangSo.Count(so => so % 2 != 0);

            Console.WriteLine($"Query Syntax : Tổng = {tongQs}, Chẵn = {chanQs}, Lẻ = {leQs}");
            Console.WriteLine($"Method Syntax: Tổng = {tongMs}, Chẵn = {chanMs}, Lẻ = {leMs}");
        }

        // b. Tổng các giá trị, giá trị lớn nhất, giá trị nhỏ nhất
        static void Bai31_CauB(int[] mangSo)
        {
            InTieuDeCau("Câu b: Tổng, giá trị lớn nhất, giá trị nhỏ nhất");

            // Query Syntax
            int tongQs = (from so in mangSo select so).Sum();
            int maxQs = (from so in mangSo select so).Max();
            int minQs = (from so in mangSo select so).Min();

            // Method Syntax
            int tongMs = mangSo.Sum();
            int maxMs = mangSo.Max();
            int minMs = mangSo.Min();

            Console.WriteLine($"Query Syntax : Tổng = {tongQs}, Max = {maxQs}, Min = {minQs}");
            Console.WriteLine($"Method Syntax: Tổng = {tongMs}, Max = {maxMs}, Min = {minMs}");
        }

        // c. Số giá trị khác nhau trong mảng
        static void Bai31_CauC(int[] mangSo)
        {
            InTieuDeCau("Câu c: Số giá trị khác nhau trong mảng");

            // Query Syntax
            var khacNhauQs = (from so in mangSo select so).Distinct();

            // Method Syntax
            var khacNhauMs = mangSo.Distinct();

            InDanhSach("Query Syntax  - các giá trị khác nhau", khacNhauQs);
            Console.WriteLine($"Query Syntax  - số giá trị khác nhau: {khacNhauQs.Count()}");
            InDanhSach("Method Syntax - các giá trị khác nhau", khacNhauMs);
            Console.WriteLine($"Method Syntax - số giá trị khác nhau: {khacNhauMs.Count()}");
        }

        // d. Phân nhóm theo số dư khi chia cho 5
        static void Bai31_CauD(int[] mangSo)
        {
            InTieuDeCau("Câu d: Phân nhóm theo số dư khi chia cho 5");

            // Query Syntax
            var nhomQs = from so in mangSo
                         group so by so % 5 into g
                         orderby g.Key
                         select g;

            // Method Syntax
            var nhomMs = mangSo
                .GroupBy(so => so % 5)
                .OrderBy(g => g.Key);

            Console.WriteLine("Query Syntax:");
            InCacNhom(nhomQs);
            Console.WriteLine("Method Syntax:");
            InCacNhom(nhomMs);
        }

        // In cấu trúc nhóm: khóa, số lượng, các phần tử (foreach chỉ dùng để xuất)
        static void InCacNhom(IEnumerable<IGrouping<int, int>> cacNhom)
        {
            foreach (var nhom in cacNhom)
            {
                Console.WriteLine($"  Số dư {nhom.Key} ({nhom.Count()} phần tử): {string.Join(", ", nhom)}");
            }
        }
        // ============================================================
        // BÀI 3.2: THỐNG KÊ MẢNG CHUỖI
        // ============================================================
        static void Bai32()
        {
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                       "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                       "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            Console.WriteLine();
            InTieuDeBai("BÀI 3.2: THỐNG KÊ MẢNG CHUỖI");
            InDanhSach("Mảng ban đầu", monAn);

            Bai32_CauA(monAn);
            Bai32_CauB(monAn);
            Bai32_CauC(monAn);
        }

        // a. Các phần tử có chiều dài ngắn nhất và dài nhất
        static void Bai32_CauA(string[] monAn)
        {
            InTieuDeCau("Câu a: Phần tử có chiều dài ngắn nhất và dài nhất");

            // Query Syntax
            int minQs = (from s in monAn select s.Length).Min();
            int maxQs = (from s in monAn select s.Length).Max();
            var ngan_Qs = from s in monAn where s.Length == minQs select s;
            var dai_Qs = from s in monAn where s.Length == maxQs select s;

            // Method Syntax
            int minMs = monAn.Min(s => s.Length);
            int maxMs = monAn.Max(s => s.Length);
            var ngan_Ms = monAn.Where(s => s.Length == minMs);
            var dai_Ms = monAn.Where(s => s.Length == maxMs);

            Console.WriteLine($"Query Syntax : độ dài ngắn nhất = {minQs}, dài nhất = {maxQs}");
            InDanhSach("  Các phần tử ngắn nhất", ngan_Qs);
            InDanhSach("  Các phần tử dài nhất ", dai_Qs);

            Console.WriteLine($"Method Syntax: độ dài ngắn nhất = {minMs}, dài nhất = {maxMs}");
            InDanhSach("  Các phần tử ngắn nhất", ngan_Ms);
            InDanhSach("  Các phần tử dài nhất ", dai_Ms);
        }

        // b. Phân nhóm theo từ đầu tiên của tên món
        static void Bai32_CauB(string[] monAn)
        {
            InTieuDeCau("Câu b: Phân nhóm theo từ đầu tiên của tên món");

            // Query Syntax
            var nhomQs = from s in monAn
                         group s by s.Split(' ')[0] into g
                         select g;

            // Method Syntax
            var nhomMs = monAn.GroupBy(s => s.Split(' ')[0]);

            Console.WriteLine("Query Syntax:");
            InCacNhom(nhomQs);
            Console.WriteLine("Method Syntax:");
            InCacNhom(nhomMs);
        }

        // c. Đếm số phần tử có từ đầu tiên là "Bánh"
        static void Bai32_CauC(string[] monAn)
        {
            InTieuDeCau("Câu c: Số phần tử có từ đầu tiên là \"Bánh\"");

            // Query Syntax
            var dsQs = from s in monAn
                       where s.Split(' ')[0] == "Bánh"
                       select s;

            // Method Syntax
            var dsMs = monAn.Where(s => s.Split(' ')[0] == "Bánh");

            Console.WriteLine($"Query Syntax : {dsQs.Count()} phần tử");
            InDanhSach("  Danh sách", dsQs);
            Console.WriteLine($"Method Syntax: {dsMs.Count()} phần tử");
            InDanhSach("  Danh sách", dsMs);
        }

        // Thay thế bản InCacNhom cũ (kiểu int, int) bằng bản generic này
        static void InCacNhom<TKey, TElement>(IEnumerable<IGrouping<TKey, TElement>> cacNhom)
        {
            foreach (var nhom in cacNhom)
            {
                Console.WriteLine($"  Nhóm \"{nhom.Key}\" ({nhom.Count()} phần tử): {string.Join(", ", nhom)}");
            }
        }
        // ============================================================
        // BÀI 4.1: LỚP MONHOC VÀ DỮ LIỆU MẪU
        // ============================================================
        static void Bai41()
        {
            List<MonHoc> dsMon = DuLieu.DS_Mon();

            Console.WriteLine();
            InTieuDeBai("BÀI 4.1: DANH SÁCH MÔN HỌC (DuLieu.DS_Mon())");
            Console.WriteLine($"Tổng số môn học: {dsMon.Count}");
            Console.WriteLine();
            InBangMonHoc(dsMon);
        }

        static void InBangMonHoc(IEnumerable<MonHoc> ds)
        {
            Console.WriteLine($"{"Mã môn",-8}{"Tên môn",-46}{"Hệ",-6}{"Số tiết",7}");
            Console.WriteLine(new string('-', 67));
            foreach (var m in ds)
            {
                Console.WriteLine($"{m.MaMon,-8}{m.TenMon,-46}{m.He,-6}{m.SoTiet,7}");
            }
        }
        // ============================================================
        // BÀI 5.1: TRUY VẤN CƠ BẢN TRÊN List<MonHoc>
        // ============================================================
        static void Bai51()
        {
            List<MonHoc> dsMon = DuLieu.DS_Mon();

            Console.WriteLine();
            InTieuDeBai("BÀI 5.1: TRUY VẤN CƠ BẢN List<MonHoc>");

            Bai51_CauA(dsMon);
            Bai51_CauB(dsMon);
            Bai51_CauC(dsMon);
            Bai51_CauD(dsMon);
        }

        // a. Tên các môn học bắt đầu bằng "Lập trình"
        static void Bai51_CauA(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu a: Tên các môn học bắt đầu bằng \"Lập trình\"");

            // Query Syntax
            var qs = from m in dsMon
                     where m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal)
                     select m.TenMon;

            // Method Syntax
            var ms = dsMon
                .Where(m => m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal))
                .Select(m => m.TenMon);

            Console.WriteLine($"Query Syntax ({qs.Count()} môn):");
            InTheoDong(qs, ten => $"  - {ten}");
            Console.WriteLine($"Method Syntax ({ms.Count()} môn):");
            InTheoDong(ms, ten => $"  - {ten}");
        }

        // b. Môn thuộc hệ "CD", số tiết giảm dần rồi mã môn tăng dần
        static void Bai51_CauB(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu b: Hệ \"CD\", sắp xếp số tiết giảm dần rồi mã môn tăng dần");

            // Query Syntax
            var qs = from m in dsMon
                     where m.He == "CD"
                     orderby m.SoTiet descending, m.MaMon
                     select m;

            // Method Syntax
            var ms = dsMon
                .Where(m => m.He == "CD")
                .OrderByDescending(m => m.SoTiet)
                .ThenBy(m => m.MaMon);

            Console.WriteLine($"Query Syntax ({qs.Count()} môn):");
            InBangMonHoc(qs);
            Console.WriteLine($"Method Syntax ({ms.Count()} môn):");
            InBangMonHoc(ms);
        }

        // c. Môn có tên chứa từ "web", chỉ lấy Tên môn và Hệ
        static void Bai51_CauC(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu c: Môn có tên chứa từ \"web\" (chỉ Tên môn và Hệ)");

            // Query Syntax (kiểu ẩn danh chỉ chứa 2 thuộc tính cần lấy)
            var qs = from m in dsMon
                     where m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase)
                     select new { m.TenMon, m.He };

            // Method Syntax
            var ms = dsMon
                .Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                .Select(m => new { m.TenMon, m.He });

            Console.WriteLine($"Query Syntax ({qs.Count()} môn):");
            InTheoDong(qs, x => $"  - Tên môn: {x.TenMon} | Hệ: {x.He}");
            Console.WriteLine($"Method Syntax ({ms.Count()} môn):");
            InTheoDong(ms, x => $"  - Tên môn: {x.TenMon} | Hệ: {x.He}");
        }

        // d. Môn thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
        static void Bai51_CauD(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu d: Hệ \"KTV\", sắp xếp tăng dần theo Mã môn");

            // Query Syntax
            var qs = from m in dsMon
                     where m.He == "KTV"
                     orderby m.MaMon
                     select m;

            // Method Syntax
            var ms = dsMon
                .Where(m => m.He == "KTV")
                .OrderBy(m => m.MaMon);

            Console.WriteLine($"Query Syntax ({qs.Count()} môn):");
            InBangMonHoc(qs);
            Console.WriteLine($"Method Syntax ({ms.Count()} môn):");
            InBangMonHoc(ms);
        }

        // Hàm hỗ trợ: in mỗi phần tử một dòng theo định dạng tùy chọn (dùng cho cả kiểu ẩn danh)
        static void InTheoDong<T>(IEnumerable<T> ds, Func<T, string> dinhDang)
        {
            var ketQua = ds.ToList();
            if (!ketQua.Any())
            {
                Console.WriteLine("  (không có phần tử nào)");
                return;
            }
            foreach (var item in ketQua)
            {
                Console.WriteLine(dinhDang(item));
            }
        }
        // ============================================================
        // BÀI 5.2: THỐNG KÊ TRÊN List<MonHoc>
        // ============================================================
        static void Bai52()
        {
            List<MonHoc> dsMon = DuLieu.DS_Mon();

            Console.WriteLine();
            InTieuDeBai("BÀI 5.2: THỐNG KÊ TRÊN List<MonHoc>");

            Bai52_CauA(dsMon);
            Bai52_CauB(dsMon);
            Bai52_CauC(dsMon);
            Bai52_CauD(dsMon);
            Bai52_CauE(dsMon);
            Bai52_CauF(dsMon);
            Bai52_CauG(dsMon);
            Bai52_CauH(dsMon);
            Bai52_CauI(dsMon);
            Bai52_CauJ(dsMon);
            Bai52_CauK(dsMon);
        }

        // a. Tổng số môn hiện có
        static void Bai52_CauA(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu a: Tổng số môn hiện có");

            int qs = (from m in dsMon select m).Count();
            int ms = dsMon.Count();

            Console.WriteLine($"Query Syntax : {qs} môn");
            Console.WriteLine($"Method Syntax: {ms} môn");
        }

        // b. Số môn có tên bắt đầu bằng "Lập trình"
        static void Bai52_CauB(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu b: Số môn có tên bắt đầu bằng \"Lập trình\"");

            int qs = (from m in dsMon
                      where m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal)
                      select m).Count();
            int ms = dsMon.Count(m => m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal));

            Console.WriteLine($"Query Syntax : {qs} môn");
            Console.WriteLine($"Method Syntax: {ms} môn");
        }

        // c. Tổng số tiết của hệ KTV
        static void Bai52_CauC(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu c: Tổng số tiết của hệ Kỹ thuật viên (KTV)");

            // SoTiet là byte nên phải ép sang int khi Sum
            int qs = (from m in dsMon
                      where m.He == "KTV"
                      select (int)m.SoTiet).Sum();
            int ms = dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet);

            Console.WriteLine($"Query Syntax : {qs} tiết");
            Console.WriteLine($"Method Syntax: {ms} tiết");
        }

        // d. Tổng số môn của mỗi hệ
        static void Bai52_CauD(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu d: Tổng số môn của mỗi hệ");

            var qs = from m in dsMon
                     group m by m.He into g
                     select new { He = g.Key, TongMon = g.Count() };

            var ms = dsMon
                .GroupBy(m => m.He)
                .Select(g => new { He = g.Key, TongMon = g.Count() });

            Console.WriteLine("Query Syntax:");
            InTheoDong(qs, x => $"  Hệ: {TenHe(x.He),-8} | Tổng số môn: {x.TongMon}");
            Console.WriteLine("Method Syntax:");
            InTheoDong(ms, x => $"  Hệ: {TenHe(x.He),-8} | Tổng số môn: {x.TongMon}");
        }

        // e. Nhóm theo Số tiết, sắp xếp giảm dần theo Số tiết
        static void Bai52_CauE(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu e: Nhóm theo Số tiết (giảm dần): Số tiết, Tổng số môn");

            var qs = from m in dsMon
                     group m by m.SoTiet into g
                     orderby g.Key descending
                     select new { SoTiet = g.Key, TongMon = g.Count() };

            var ms = dsMon
                .GroupBy(m => m.SoTiet)
                .OrderByDescending(g => g.Key)
                .Select(g => new { SoTiet = g.Key, TongMon = g.Count() });

            Console.WriteLine("Query Syntax:");
            InTheoDong(qs, x => $"  Số tiết: {x.SoTiet,3} | Tổng số môn: {x.TongMon}");
            Console.WriteLine("Method Syntax:");
            InTheoDong(ms, x => $"  Số tiết: {x.SoTiet,3} | Tổng số môn: {x.TongMon}");
        }

        // f. Thông tin môn học có số tiết cao nhất
        static void Bai52_CauF(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu f: Môn học có số tiết cao nhất");

            // Lọc theo giá trị lớn nhất (đề phòng có nhiều môn cùng số tiết cao nhất)
            byte maxQs = (from m in dsMon select m.SoTiet).Max();
            var qs = from m in dsMon
                     where m.SoTiet == maxQs
                     select m;

            byte maxMs = dsMon.Max(m => m.SoTiet);
            var ms = dsMon.Where(m => m.SoTiet == maxMs);

            Console.WriteLine($"Query Syntax (số tiết cao nhất = {maxQs}):");
            InBangMonHoc(qs);
            Console.WriteLine($"Method Syntax (số tiết cao nhất = {maxMs}):");
            InBangMonHoc(ms);
        }

        // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, thấp nhất
        static void Bai52_CauG(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu g: Thống kê theo Hệ");

            var qs = from m in dsMon
                     group m by m.He into g
                     select new
                     {
                         He = g.Key,
                         TongMon = g.Count(),
                         TongTiet = g.Sum(m => (int)m.SoTiet),
                         Max = g.Max(m => m.SoTiet),
                         Min = g.Min(m => m.SoTiet)
                     };

            var ms = dsMon
                .GroupBy(m => m.He)
                .Select(g => new
                {
                    He = g.Key,
                    TongMon = g.Count(),
                    TongTiet = g.Sum(m => (int)m.SoTiet),
                    Max = g.Max(m => m.SoTiet),
                    Min = g.Min(m => m.SoTiet)
                });

            Console.WriteLine("Query Syntax:");
            InTheoDong(qs, x => $"  Hệ: {TenHe(x.He),-8} | Tổng môn: {x.TongMon,2} | Tổng tiết: {x.TongTiet,3} | Max: {x.Max,3} | Min: {x.Min,3}");
            Console.WriteLine("Method Syntax:");
            InTheoDong(ms, x => $"  Hệ: {TenHe(x.He),-8} | Tổng môn: {x.TongMon,2} | Tổng tiết: {x.TongTiet,3} | Max: {x.Max,3} | Min: {x.Min,3}");
        }

        // h. Liệt kê các môn học được phân nhóm theo Hệ
        static void Bai52_CauH(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu h: Các môn học phân nhóm theo Hệ");

            var qs = from m in dsMon
                     group m by m.He into g
                     select g;

            var ms = dsMon.GroupBy(m => m.He);

            Console.WriteLine("Query Syntax:");
            InNhomMonHoc(qs, he => $"Hệ {TenHe(he)}");
            Console.WriteLine("Method Syntax:");
            InNhomMonHoc(ms, he => $"Hệ {TenHe(he)}");
        }

        // i. Phân nhóm theo Số tiết, tăng dần theo Số tiết
        static void Bai52_CauI(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu i: Các môn học phân nhóm theo Số tiết (tăng dần)");

            var qs = from m in dsMon
                     group m by m.SoTiet into g
                     orderby g.Key
                     select g;

            var ms = dsMon
                .GroupBy(m => m.SoTiet)
                .OrderBy(g => g.Key);

            Console.WriteLine("Query Syntax:");
            InNhomMonHoc(qs, st => $"Số tiết {st}");
            Console.WriteLine("Method Syntax:");
            InNhomMonHoc(ms, st => $"Số tiết {st}");
        }

        // j. Hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
        static void Bai52_CauJ(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu j: Hệ KTV, phân nhóm theo học phần (HP2, HP3, HP4, HP5)");

            // Sắp xếp theo Mã môn trước khi nhóm để các môn trong mỗi nhóm đúng thứ tự Mã môn
            var qs = from m in dsMon
                     where m.He == "KTV"
                     orderby m.MaMon
                     group m by m.MaMon.Split('_')[0] into g
                     orderby g.Key
                     select g;

            var ms = dsMon
                .Where(m => m.He == "KTV")
                .OrderBy(m => m.MaMon)
                .GroupBy(m => m.MaMon.Split('_')[0])
                .OrderBy(g => g.Key);

            Console.WriteLine("Query Syntax:");
            InNhomMonHoc(qs, hp => $"Học phần {hp}");
            Console.WriteLine("Method Syntax:");
            InNhomMonHoc(ms, hp => $"Học phần {hp}");
        }

        // k. Phân nhóm theo Hệ, chỉ lấy môn có Số tiết > 40; trong nhóm sắp xếp theo Mã môn
        static void Bai52_CauK(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu k: Nhóm theo Hệ, chỉ lấy môn có Số tiết > 40 (sắp theo Mã môn)");

            var qs = from m in dsMon
                     where m.SoTiet > 40
                     orderby m.MaMon
                     group m by m.He into g
                     select g;

            var ms = dsMon
                .Where(m => m.SoTiet > 40)
                .OrderBy(m => m.MaMon)
                .GroupBy(m => m.He);

            Console.WriteLine("Query Syntax:");
            InNhomMonHoc(qs, he => $"Hệ {TenHe(he)}");
            Console.WriteLine("Method Syntax:");
            InNhomMonHoc(ms, he => $"Hệ {TenHe(he)}");
        }

        // ----- Hàm hỗ trợ cho bài 5.2 -----

        // Hệ rỗng (môn XYZ) được hiển thị rõ ràng
        static string TenHe(string he) => string.IsNullOrEmpty(he) ? "(trống)" : he;

        // In đầy đủ cấu trúc nhóm: khóa nhóm, số môn, danh sách môn trong nhóm
        static void InNhomMonHoc<TKey>(IEnumerable<IGrouping<TKey, MonHoc>> cacNhom, Func<TKey, string> hienThiKhoa)
        {
            foreach (var nhom in cacNhom)
            {
                Console.WriteLine($"  Nhóm [{hienThiKhoa(nhom.Key)}] ({nhom.Count()} môn):");
                foreach (var m in nhom)
                {
                    Console.WriteLine($"      - {m.MaMon,-7} {m.TenMon,-44} Hệ: {TenHe(m.He),-7} {m.SoTiet,3} tiết");
                }
            }
        }
        // ============================================================
        // BÀI 6.1: LỚP He VÀ DỮ LIỆU MẪU
        // ============================================================
        static void Bai61()
        {
            List<He> dsHe = DuLieu2.DS_He();

            Console.WriteLine();
            InTieuDeBai("BÀI 6.1: DANH SÁCH HỆ (DuLieu.DS_He())");
            Console.WriteLine($"Tổng số hệ: {dsHe.Count}");
            Console.WriteLine();
            InBangHe(dsHe);
        }

        static void InBangHe(IEnumerable<He> ds)
        {
            Console.WriteLine($"{"Mã hệ",-8}{"Tên hệ",-25}");
            Console.WriteLine(new string('-', 33));
            foreach (var h in ds)
            {
                Console.WriteLine($"{h.MaHe,-8}{h.TenHe,-25}");
            }
        }
        // ============================================================
        // BÀI 6.2: JOIN VÀ CÁC TOÁN TỬ TẬP HỢP
        // ============================================================
        const string CHUA_CO_MON = "(chưa có môn)";
        const string CHUA_KHAI_BAO_HE = "(chưa khai báo hệ)";

        static void Bai62()
        {
            List<MonHoc> dsMon = DuLieu.DS_Mon();
            List<He> dsHe = DuLieu.DS_He();

            Console.WriteLine();
            InTieuDeBai("BÀI 6.2: JOIN VÀ CÁC TOÁN TỬ TẬP HỢP");

            Bai62_CauA(dsHe, dsMon);
            Bai62_CauB(dsHe, dsMon);
            Bai62_CauC(dsHe, dsMon);
            Bai62_CauD(dsHe, dsMon);
            Bai62_CauE(dsHe, dsMon);
            Bai62_CauF(dsHe, dsMon);
            Bai62_CauG(dsMon);
            Bai62_CauH(dsMon);
            Bai62_CauI(dsMon);
        }

        // a. Inner join: Tên hệ, Mã môn, Tên môn
        static void Bai62_CauA(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu a: Join - Tên hệ, Mã môn, Tên môn");

            var qs = from h in dsHe
                     join m in dsMon on h.MaHe equals m.He
                     select new { h.TenHe, m.MaMon, m.TenMon };

            var ms = dsHe.Join(dsMon,
                               h => h.MaHe,
                               m => m.He,
                               (h, m) => new { h.TenHe, m.MaMon, m.TenMon });

            Console.WriteLine($"Query Syntax ({qs.Count()} dòng):");
            InTheoDong(qs, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-6} | Tên môn: {x.TenMon}");
            Console.WriteLine($"Method Syntax ({ms.Count()} dòng):");
            InTheoDong(ms, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-6} | Tên môn: {x.TenMon}");
        }

        // b. Left outer join: liệt kê cả hệ chưa có môn học
        static void Bai62_CauB(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu b: Left outer join - cả những hệ chưa có môn học");

            var qs = from h in dsHe
                     join m in dsMon on h.MaHe equals m.He into nhomMon
                     from m in nhomMon.DefaultIfEmpty()
                     select new
                     {
                         h.TenHe,
                         MaMon = m?.MaMon ?? CHUA_CO_MON,
                         TenMon = m?.TenMon ?? CHUA_CO_MON
                     };

            var ms = dsHe
                .GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, nhomMon) => new { h, nhomMon })
                .SelectMany(x => x.nhomMon.DefaultIfEmpty(),
                            (x, m) => new
                            {
                                x.h.TenHe,
                                MaMon = m?.MaMon ?? CHUA_CO_MON,
                                TenMon = m?.TenMon ?? CHUA_CO_MON
                            });

            Console.WriteLine($"Query Syntax ({qs.Count()} dòng):");
            InTheoDong(qs, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-13} | Tên môn: {x.TenMon}");
            Console.WriteLine($"Method Syntax ({ms.Count()} dòng):");
            InTheoDong(ms, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-13} | Tên môn: {x.TenMon}");
        }

        // c. Cả hệ chưa có môn học và môn học chưa khai báo hệ (full outer join = Union của hai left join)
        static void Bai62_CauC(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu c: Cả hệ chưa có môn học và môn học chưa khai báo hệ");

            // Query Syntax
            var traiQs = from h in dsHe
                         join m in dsMon on h.MaHe equals m.He into nhomMon
                         from m in nhomMon.DefaultIfEmpty()
                         select new
                         {
                             h.TenHe,
                             MaMon = m?.MaMon ?? CHUA_CO_MON,
                             TenMon = m?.TenMon ?? CHUA_CO_MON
                         };

            var phaiQs = from m in dsMon
                         join h in dsHe on m.He equals h.MaHe into nhomHe
                         from h in nhomHe.DefaultIfEmpty()
                         where h == null
                         select new { TenHe = CHUA_KHAI_BAO_HE, m.MaMon, m.TenMon };

            var qs = traiQs.Union(phaiQs);

            // Method Syntax
            var traiMs = dsHe
                .GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, nhomMon) => new { h, nhomMon })
                .SelectMany(x => x.nhomMon.DefaultIfEmpty(),
                            (x, m) => new
                            {
                                x.h.TenHe,
                                MaMon = m?.MaMon ?? CHUA_CO_MON,
                                TenMon = m?.TenMon ?? CHUA_CO_MON
                            });

            var phaiMs = dsMon
                .GroupJoin(dsHe, m => m.He, h => h.MaHe, (m, nhomHe) => new { m, nhomHe })
                .Where(x => !x.nhomHe.Any())
                .Select(x => new { TenHe = CHUA_KHAI_BAO_HE, x.m.MaMon, x.m.TenMon });

            var ms = traiMs.Union(phaiMs);

            Console.WriteLine($"Query Syntax ({qs.Count()} dòng):");
            InTheoDong(qs, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-13} | Tên môn: {x.TenMon}");
            Console.WriteLine($"Method Syntax ({ms.Count()} dòng):");
            InTheoDong(ms, x => $"  Hệ: {x.TenHe,-18} | Mã môn: {x.MaMon,-13} | Tên môn: {x.TenMon}");
        }

        // d. Chỉ liệt kê hệ chưa có môn học và môn học chưa khai báo hệ
        static void Bai62_CauD(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu d: Chỉ hệ chưa có môn học và môn học chưa khai báo hệ");

            // Query Syntax
            var heQs = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into nhomMon
                       where !nhomMon.Any()
                       select new { Loai = "Hệ chưa có môn học", Ma = h.MaHe, Ten = h.TenHe };

            var monQs = from m in dsMon
                        join h in dsHe on m.He equals h.MaHe into nhomHe
                        where !nhomHe.Any()
                        select new { Loai = "Môn học chưa khai báo hệ", Ma = m.MaMon, Ten = m.TenMon };

            var qs = heQs.Union(monQs);

            // Method Syntax
            var heMs = dsHe
                .GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, nhomMon) => new { h, nhomMon })
                .Where(x => !x.nhomMon.Any())
                .Select(x => new { Loai = "Hệ chưa có môn học", Ma = x.h.MaHe, Ten = x.h.TenHe });

            var monMs = dsMon
                .GroupJoin(dsHe, m => m.He, h => h.MaHe, (m, nhomHe) => new { m, nhomHe })
                .Where(x => !x.nhomHe.Any())
                .Select(x => new { Loai = "Môn học chưa khai báo hệ", Ma = x.m.MaMon, Ten = x.m.TenMon });

            var ms = heMs.Union(monMs);

            Console.WriteLine($"Query Syntax ({qs.Count()} dòng):");
            InTheoDong(qs, x => $"  [{x.Loai}] {x.Ma} - {x.Ten}");
            Console.WriteLine($"Method Syntax ({ms.Count()} dòng):");
            InTheoDong(ms, x => $"  [{x.Loai}] {x.Ma} - {x.Ten}");
        }

        // e. 5 môn học đầu tiên có số tiết giảm dần: Tên hệ, Mã môn, Tên môn, Số tiết
        static void Bai62_CauE(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu e: 5 môn học có số tiết giảm dần (Tên hệ, Mã môn, Tên môn, Số tiết)");

            var qs = (from m in dsMon
                      join h in dsHe on m.He equals h.MaHe
                      orderby m.SoTiet descending
                      select new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet }).Take(5);

            var ms = dsMon
                .Join(dsHe, m => m.He, h => h.MaHe,
                      (m, h) => new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet })
                .OrderByDescending(x => x.SoTiet)
                .Take(5);

            Console.WriteLine("Query Syntax:");
            InTheoDong(qs, x => $"  {x.TenHe,-18} | {x.MaMon,-6} | {x.TenMon,-38} | {x.SoTiet,3} tiết");
            Console.WriteLine("Method Syntax:");
            InTheoDong(ms, x => $"  {x.TenHe,-18} | {x.MaMon,-6} | {x.TenMon,-38} | {x.SoTiet,3} tiết");
        }

        // f. Tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn (kể cả hệ có 0 môn)
        static void Bai62_CauF(List<He> dsHe, List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu f: Tổng số môn học của mỗi hệ");

            var qs = from h in dsHe
                     join m in dsMon on h.MaHe equals m.He into nhomMon
                     select new { h.MaHe, h.TenHe, TongMon = nhomMon.Count() };

            var ms = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He,
                                    (h, nhomMon) => new { h.MaHe, h.TenHe, TongMon = nhomMon.Count() });

            Console.WriteLine("Query Syntax:");
            InTheoDong(qs, x => $"  Mã hệ: {x.MaHe,-4} | Tên hệ: {x.TenHe,-18} | Tổng số môn: {x.TongMon}");
            Console.WriteLine("Method Syntax:");
            InTheoDong(ms, x => $"  Mã hệ: {x.MaHe,-4} | Tên hệ: {x.TenHe,-18} | Tổng số môn: {x.TongMon}");
        }

        // g. Số loại Số tiết khác nhau
        static void Bai62_CauG(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu g: Số loại Số tiết khác nhau trong danh sách môn học");

            var qs = (from m in dsMon select m.SoTiet).Distinct();
            var ms = dsMon.Select(m => m.SoTiet).Distinct();

            InDanhSach("Query Syntax  - các loại số tiết", qs);
            Console.WriteLine($"Query Syntax  - số loại số tiết: {qs.Count()}");
            InDanhSach("Method Syntax - các loại số tiết", ms);
            Console.WriteLine($"Method Syntax - số loại số tiết: {ms.Count()}");
        }

        // h. Môn học đầu tiên có tên bắt đầu bằng "Lập trình"
        static void Bai62_CauH(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu h: Môn học đầu tiên có tên bắt đầu bằng \"Lập trình\"");

            var qs = (from m in dsMon
                      where m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal)
                      select m).FirstOrDefault();

            var ms = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình", StringComparison.Ordinal));

            InMotMon("Query Syntax ", qs);
            InMotMon("Method Syntax", ms);
        }

        // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
        static void Bai62_CauI(List<MonHoc> dsMon)
        {
            InTieuDeCau("Câu i: Các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm");

            // Query Syntax không có toán tử đánh số, nên dùng Select có chỉ số (index) bên trong
            var qs = from m in dsMon
                     group m by m.He into g
                     select (He: g.Key,
                             CacMon: g.Select((mon, i) => (STT: i + 1, Mon: mon)).ToList());

            // Method Syntax
            var ms = dsMon
                .GroupBy(m => m.He)
                .Select(g => (He: g.Key,
                              CacMon: g.Select((mon, i) => (STT: i + 1, Mon: mon)).ToList()));

            Console.WriteLine("Query Syntax:");
            InNhomCoSTT(qs);
            Console.WriteLine("Method Syntax:");
            InNhomCoSTT(ms);
        }

        // ----- Hàm hỗ trợ cho bài 6.2 -----

        static void InMotMon(string nhan, MonHoc? mon)
        {
            if (mon == null)
            {
                Console.WriteLine($"{nhan}: (không tìm thấy môn nào)");
                return;
            }
            Console.WriteLine($"{nhan}: {mon.MaMon} | {mon.TenMon} | Hệ: {TenHe(mon.He)} | {mon.SoTiet} tiết");
        }

        static void InNhomCoSTT(IEnumerable<(string He, List<(int STT, MonHoc Mon)> CacMon)> cacNhom)
        {
            foreach (var nhom in cacNhom)
            {
                Console.WriteLine($"  Nhóm [Hệ {TenHe(nhom.He)}] ({nhom.CacMon.Count} môn):");
                foreach (var (stt, mon) in nhom.CacMon)
                {
                    Console.WriteLine($"      {stt,2}. {mon.MaMon,-7} {mon.TenMon,-44} {mon.SoTiet,3} tiết");
                }
            }
        }
    }
}