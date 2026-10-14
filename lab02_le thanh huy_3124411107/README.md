# Thực hành 02 – Lập trình hướng đối tượng C#: Lời giải & Giải thích

## Cách chạy

**Visual Studio:** mở `ThucHanh02.csproj` → nhấn F5.
**Dòng lệnh (.NET 6/7/8):** trong thư mục dự án chạy `dotnet run`.
(Nếu máy cài .NET khác 8, sửa `<TargetFramework>net8.0</TargetFramework>` trong file `.csproj`.)

Chương trình hiện menu, chọn số bài để chạy thử. Mỗi bài nằm trong một file riêng:

```
Common/Nhap.cs        tiện ích nhập liệu (nhập sai thì nhập lại)
Chuong1/              Bài 1.1 → 1.5   (lớp cơ bản)
Chuong2/              Bài 2.1 → 2.5   (lớp chứa mảng, List, Indexer)
Chuong3/              Bài 3.1 → 3.6   (interface, delegate/event, kế thừa, đa hình)
Program.cs            menu chính
```

> Đề có hai bài cùng số 2.3 và 2.4. Trong code: **2.3** = dãy số, **2.4** = mảng 2 chiều,
> **2.3'** = đa thức (`Bai2_3b_DaThuc.cs`), **2.4'** = dãy phân số (`Bai2_4b_DayPhanSo.cs`).

---

## Kiến thức nền cần nắm

| Thành phần | Là gì | Ví dụ trong bài |
|---|---|---|
| **Field** | Biến lưu dữ liệu bên trong đối tượng, để `private` để bên ngoài không sửa bừa | `private double x, y;` |
| **Constructor** | Hàm chạy khi `new`, dùng khởi tạo dữ liệu. Có 3 loại: *mặc định* (không tham số), *có tham số*, *sao chép* (nhận vào một đối tượng cùng lớp) | `Point()`, `Point(x, y)`, `Point(Point p)` |
| **Property** | "Cổng" đọc/ghi field, có thể kiểm tra dữ liệu trong `set` hoặc tính toán trong `get` | `NamSinh`, `Tuoi` |
| **Method** | Hành vi của đối tượng | `Input()`, `KhoangCach()` |
| **Static** | Thuộc về *lớp*, không thuộc đối tượng. Gọi bằng `TenLop.Ham()` | `Point.KhoangCach(A, B)` |
| **Operator overloading** | Định nghĩa lại `+ - * / > ==`… cho lớp của mình | `a + b` với `a, b` là phân số |
| **Indexer** | Cho phép dùng cú pháp `obj[i]` như mảng | `arr[i]`, `mt[i, j]` |

**Mẹo dùng constructor:** `: this(...)` gọi sang constructor khác cùng lớp để khỏi viết lặp code:
```csharp
public Point(Point p) : this(p.x, p.y) { }
```

---

## CHƯƠNG 1 – Thiết kế lớp cơ bản

### Bài 1.1 – Tính tuổi sinh viên (`Bai1_1_SinhVien.cs`)
- Field `hoTen`, `namSinh` để `private` → **đóng gói (encapsulation)**.
- Property `NamSinh` có kiểm tra trong `set`: năm sinh ngoài [1900, năm hiện tại] thì báo lỗi.
- `Tuoi` là property **chỉ có `get`**, không lưu mà *tính* mỗi lần gọi:
  `DateTime.Now.Year - namSinh`. Lý do: tuổi thay đổi theo thời gian, lưu cứng sẽ bị sai.
- Override `ToString()` để `Console.WriteLine(sv)` in ra đẹp.

### Bài 1.2 – Lớp Point (`Bai1_2_Point.cs`)
- Constructor mặc định gán `x = y = 0` đúng yêu cầu đề.
- **Toán tử**: phải là `public static`. Toán tử `-` được overload 2 lần:
  - 2 tham số `a - b` → phép trừ.
  - 1 tham số `-a` → lấy âm.
- **(a) Khoảng cách** – công thức `√((xA−xB)² + (yA−yB)²)`, viết theo 2 cách:
  - *Thành viên*: `A.KhoangCach(B)` — hàm dùng dữ liệu của chính `A` (`this`) và `B`.
  - *Tĩnh*: `Point.KhoangCach(A, B)` — hàm không gắn với đối tượng nào, nhận cả 2 điểm làm tham số.
  - Hai hàm cùng tên nhưng khác tham số → **nạp chồng (overloading)**. Bản tĩnh gọi lại bản thành viên để không viết công thức 2 lần.
- **(b) Trung điểm**: `I = ((xA+xB)/2, (yA+yB)/2)`, cũng 2 cách như trên.

**Khi nào dùng static?** Khi hàm không "thuộc" riêng đối tượng nào mà là phép toán giữa nhiều đối tượng ngang hàng (như khoảng cách giữa 2 điểm), hoặc là hàm tiện ích (`Math.Sqrt`).

### Bài 1.3 – Lớp Person (`Bai1_3_Person.cs`)
- `IsLiving()` trả `true` khi `yod == 0` (chưa có năm mất).
- `Input()` kiểm tra năm mất phải `= 0` hoặc `>= năm sinh`.
- **Copy constructor** tạo ra một đối tượng *mới, độc lập*. Trong demo, sửa tên bản sao `q` không làm thay đổi `p`.
  Nếu viết `Person q = p;` thì `q` và `p` là **cùng một đối tượng** (vì class là kiểu tham chiếu) — đây là lỗi hay gặp.

### Bài 1.4 – Lớp Phân số (`Bai1_4_PhanSo.cs`)
- 4 constructor: mặc nhiên (`0/1`), từ số nguyên (`n/1`), từ tử & mẫu, sao chép. Mẫu = 0 thì ném ngoại lệ.
- **Luôn rút gọn và giữ mẫu dương** ngay trong constructor (dùng UCLN theo thuật toán Euclid). Nhờ vậy:
  - In ra luôn đẹp: `2/-4` → `-1/2`.
  - So sánh `==` chỉ cần so tử với tử, mẫu với mẫu.
- **Phép toán:**
  - `a/b + c/d = (ad + cb) / bd`
  - `a/b − c/d = a/b + (−c/d)` (tái sử dụng phép cộng và phép lấy âm)
  - `a/b × c/d = ac / bd`
  - `a/b ÷ c/d = ad / bc` (c ≠ 0)
- **So sánh:** vì mẫu luôn dương nên `a/b > c/d ⇔ a·d > c·b`. Viết một hàm `CompareTo` rồi các toán tử `> < >= <=` đều gọi nó.
- Quy tắc C#: toán tử so sánh phải overload theo **cặp** (`>` đi với `<`, `==` đi với `!=`); đã overload `==` thì nên override `Equals` và `GetHashCode`.
- Lớp này còn `implement IComparable<PhanSo>` để dùng ở Bài 3.1.

### Bài 1.5 – Đơn thức (`Bai1_5_DonThuc.cs`)
- `P(x) = a·xⁿ`, n nguyên ≥ 0 → kiểm tra `n >= 0` trong constructor/property.
- (a) `GiaTri(x) = a * Math.Pow(x, n)`.
- (b) `DaoHam()` trả về **một đơn thức mới** `(a·n)·xⁿ⁻¹`. Trường hợp đặc biệt `n = 0` (hằng số) đạo hàm bằng 0 — nếu không xử lý sẽ ra số mũ −1, vi phạm điều kiện n ≥ 0.

---

## CHƯƠNG 2 – Lớp nâng cao (mảng, List, Indexer)

### Indexer là gì?
```csharp
public Point this[int i]
{
    get { return (Point)ds[i]; }
    set { ds[i] = value; }
}
```
Giống property nhưng tên là `this` và có tham số trong `[]`. Nhờ nó ta viết `arr[2]` thay vì `arr.GetPoint(2)`.

### Bài 2.1 – ArrayPoint (`Bai2_1_ArrayPoint.cs`)
- Dùng `ArrayList` như đề yêu cầu. `ArrayList` lưu mọi thứ dưới dạng `object`, nên khi lấy ra phải **ép kiểu** `(Point)ds[i]`.
- Indexer có kiểm tra chỉ số hợp lệ.
- *Ghi chú:* trong thực tế nên dùng `List<Point>` (có kiểu, không cần ép kiểu, an toàn hơn) — các bài sau dùng `List<T>`.

### Bài 2.2 – PersonList (`Bai2_2_PersonList.cs`)
- Chứa `List<Person>` — **tái sử dụng** lớp `Person` của Bài 1.3 (quan hệ "có một" – *composition*).
- Copy constructor sao chép **sâu**: tạo `new Person(p)` cho từng người, để 2 danh sách không dùng chung đối tượng.
- `LivingPeople()` duyệt danh sách, người nào `IsLiving()` thì thêm vào một `PersonList` **mới** rồi trả về.

### Bài 2.3 – Dãy số (`Bai2_3_DaySo.cs`)
- Constructor: rỗng; `n` phần tử; từ mảng có sẵn (dùng `Clone()` để không dùng chung mảng); sao chép.
- Indexer kiểm tra chỉ số, sai thì ném `IndexOutOfRangeException`.
- `TimSoChan()`: số chẵn là `x % 2 == 0` (đúng cả với số âm). Trả về một `DaySo` mới.

### Bài 2.4 – Mảng 2 chiều (`Bai2_4_MaTran.cs`)
- Dùng `int[,]`; kích thước lấy bằng `GetLength(0)` (dòng), `GetLength(1)` (cột).
- **Indexer 2 tham số**: `public int this[int i, int j]` → dùng `mt[i, j]`.
- Kiểm tra số nguyên tố: n < 2 thì không phải; thử chia cho k từ 2 đến √n (`k * k <= n`), chia hết là không nguyên tố. Chỉ cần tới √n vì nếu n = p·q thì một trong hai thừa số ≤ √n.

### Bài 2.3' – Đa thức (`Bai2_3b_DaThuc.cs`)
- Đa thức bậc n = **mảng n+1 đơn thức**, phần tử thứ i là `aᵢ·xⁱ` → tái sử dụng lớp `DonThuc` của Bài 1.5.
- Constructor `DaThuc(params double[] heSo)`: `new DaThuc(1, 2, 3)` tạo `3x² + 2x + 1`.
- Indexer trả về đơn thức thứ i; khi gán kiểm tra số mũ phải bằng i.
- `GiaTri(x)` = tổng giá trị các đơn thức (gọi `DonThuc.GiaTri`).

### Bài 2.4' – Dãy phân số (`Bai2_4b_DayPhanSo.cs`)
- Nhờ Bài 1.4 đã overload `+`, tính tổng viết tự nhiên như cộng số:
  ```csharp
  PhanSo s = new PhanSo();         // 0
  foreach (PhanSo p in ds) s = s + p;
  ```
  Đây chính là lợi ích của đa năng hoá toán tử.

### Bài 2.5 – Lương phòng ban (`Bai2_5_PhongBan.cs`)
- Lớp `NhanVien` (họ tên, mức lương, số ngày vắng) và lớp `PhongBan` chứa `List<NhanVien>`.
- Lương thực nhận = `mức lương − số ngày vắng × 100.000` (không cho âm).
- Số 100.000 đặt thành **hằng số** `TIEN_PHAT_MOT_NGAY` để dễ sửa, tránh "số ma thuật" rải trong code.

---

## CHƯƠNG 3 – Interface, Delegate/Event, Kế thừa & Đa hình

### Bài 3.1 – Array.Sort (`Bai3_1_ArraySort.cs`)
`Array.Sort` không biết so sánh 2 phân số hay 2 người thế nào, nên ta phải "dạy" nó bằng **interface**:

| Cách | Làm gì | Gọi |
|---|---|---|
| `IComparable<T>` | Chính lớp đó cài `int CompareTo(T other)` → thứ tự *mặc định* | `Array.Sort(arr)` |
| `IComparer<T>` | Viết lớp riêng cài `int Compare(T a, T b)` → *nhiều* cách sắp khác nhau | `Array.Sort(arr, new SoSanhTheoNamSinh())` |

Quy ước giá trị trả về: **âm** nếu a đứng trước b, **0** nếu bằng nhau, **dương** nếu a đứng sau b.

### Bài 3.2 – Sắp xếp tổng quát bằng interface (`Bai3_2_SortInterface.cs`)
```csharp
public static void Sort<T>(T[] a) where T : IComparable<T>
```
- `<T>` = **generic**: một hàm dùng cho mọi kiểu (int, string, PhanSo…).
- `where T : IComparable<T>` = **ràng buộc**: chỉ nhận kiểu có hàm `CompareTo`. Nếu truyền kiểu không so sánh được, trình biên dịch báo lỗi ngay.
- Thuật toán bên trong là sắp xếp chọn (selection sort); chỗ so sánh dùng `a[j].CompareTo(a[min]) < 0` thay vì `a[j] < a[min]`.
- Có thêm bản nhận `IComparer<T>` — y như `Array.Sort` thật.

### Bài 3.3 – Sắp xếp bằng delegate (`Bai3_3_SortDelegate.cs`)
```csharp
public delegate int HamSoSanh<T>(T a, T b);
public static void Sort<T>(T[] a, HamSoSanh<T> soSanh)
```
- **Delegate** là kiểu dữ liệu đại diện cho *một hàm*. Ta truyền hàm so sánh vào như truyền một biến.
- Có thể truyền tên hàm (`Sort(so, Tang)`) hoặc **lambda** (`Sort(so, (a, b) => b.CompareTo(a))`).
- So với interface: không cần viết thêm lớp, không cần sửa lớp T; muốn sắp kiểu mới chỉ cần viết một lambda.

### Bài 3.4* – ConsoleMenu (`Bai3_4_ConsoleMenu.cs`)
Lớp `ConsoleMenu` lo phần chung: in menu, đọc lựa chọn, lặp đến khi chọn 0. Phần "làm gì khi chọn x" được để mở theo **2 cách mở rộng** đúng như đề gợi ý:

1. **Kế thừa** – `class PTBac2Console : ConsoleMenu` override phương thức ảo `OnChoose(int x)` để xử lý chức năng 1 (nhập a, b, c) và 2 (giải PT).
2. **Sự kiện** – `ConsoleMenu` khai báo `public event EventHandler<MenuEventArgs> Choose;`. Bên ngoài đăng ký:
   ```csharp
   app.AddItem("Xem hệ số đã nhập");
   app.Choose += (sender, e) => { if (e.LuaChon == 3) ... };
   ```
   → thêm chức năng 3 mà **không sửa** lớp `PTBac2Console`.

`OnChoose` mặc định sẽ phát sự kiện; lớp con xử lý những lựa chọn nó biết, còn lại gọi `base.OnChoose(x)` để chuyển cho sự kiện. Nếu không ai đăng ký thì in *"Bạn thực hiện chức năng x"* như đề.

Giải PT `ax² + bx + c = 0`: xét cả trường hợp `a = 0` (thành PT bậc nhất: vô nghiệm / vô số nghiệm / 1 nghiệm), rồi mới xét Δ = b² − 4ac (< 0 vô nghiệm, = 0 nghiệm kép, > 0 hai nghiệm).

*Bonus:* menu chính trong `Program.cs` cũng dùng lại chính lớp `ConsoleMenu` này qua sự kiện `Choose`.

### Bài 3.5 – Lương nhân viên (`Bai3_5_LuongNhanVien.cs`)
```
        NhanVien (abstract): maNV, hoTen, TinhLuong()
        /                              \
NVKinhDoanh                          NVSanXuat
lương CB + 500.000 × số HĐ           SP × 1000, > 3000 SP thì +5%
```
- **Kế thừa**: phần chung (mã, tên, nhập mã/tên) viết 1 lần ở lớp cha.
- **`abstract TinhLuong()`**: lớp cha không biết tính lương thế nào → bắt buộc lớp con phải cài (`override`). Lớp abstract không thể `new` trực tiếp.
- **`virtual Input()`**: lớp cha có sẵn phần nhập chung; lớp con `override` và gọi `base.Input()` rồi nhập thêm phần riêng.
- **Đa hình**: `List<NhanVien>` chứa lẫn cả 2 loại. Khi gọi `nv.TinhLuong()`, C# tự chọn đúng phiên bản theo **kiểu thực sự** của đối tượng lúc chạy. Muốn thêm loại nhân viên mới chỉ cần thêm lớp con, không sửa `CongTy`.

Ví dụ kiểm tra: NV sản xuất 3500 SP → 3.500 × 1.000 = 3.500.000, vượt 3000 nên × 1,05 = **3.675.000**.

### Bài 3.6 – Tính điểm thí sinh (`Bai3_6_ThiSinh.cs`)
**Phân tích:**
- Thông tin chung (sbd, họ tên, bài 1–3) → lớp cha **`ThiSinh`** (abstract).
- Thông tin riêng → 2 lớp con: **`ThiSinhChuyen`** (+ tiếng Anh), **`ThiSinhSieuCup`** (+ CSDL).
- Lớp **`CuocThi`** chứa danh sách `List<ThiSinh>`.

**Cách tính:**
- `TongDiem` là property **abstract**, mỗi lớp con tự tính:
  - Chuyên: `bài1 + bài2 + bài3 + thưởng`, thưởng = 2 nếu TA ≥ 9, = 1 nếu 7 ≤ TA < 9, còn lại 0.
    (Đề ghi "7 ≤ TA ≤ 8" và "9 ≤ TA ≤ 10" nên bỏ ngỏ khoảng 8–9 như 8,5; ở đây xếp khoảng này vào +1. Nếu thầy/cô yêu cầu khác, chỉ cần sửa trong property `DiemThuong`.)
  - Siêu cúp: `bài1 + bài2 + bài3 + csdl`.
- `tongdiem` được **tính** chứ không lưu field → luôn khớp với điểm các bài, không bao giờ bị lệch.
- Kỹ thuật **Template Method**: `ToString()` ở lớp cha gọi hàm abstract `ChiTiet()` để mỗi lớp con tự in phần riêng.

---

## Tóm tắt 4 tính chất OOP qua bài tập

| Tính chất | Thể hiện ở đâu |
|---|---|
| **Đóng gói** | Field `private` + Property có kiểm tra (Bài 1.1, 1.3, 1.5) |
| **Trừu tượng** | Lớp `abstract NhanVien`, `ThiSinh` (Bài 3.5, 3.6) |
| **Kế thừa** | `NVKinhDoanh : NhanVien`, `PTBac2Console : ConsoleMenu` |
| **Đa hình** | `List<NhanVien>` gọi `TinhLuong()` đúng từng loại; overload toán tử & phương thức |
