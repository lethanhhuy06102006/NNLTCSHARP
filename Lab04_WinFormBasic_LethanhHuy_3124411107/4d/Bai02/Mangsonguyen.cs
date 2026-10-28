namespace MangSo {
    //Class lưu trữ mảng một chiều số nguyên và các phương thức xử lý mảng
    public class MangSoNguyen {
        private int[] _a;

        //Property get/set
        public int[] A {
            get { return _a; }
            set { _a = (value == null) ? new int[0] : value; }
        }

        public int SoPhanTu {
            get { return _a.Length; }
        }

        //Phương thức khởi tạo
        public MangSoNguyen() {
            _a = new int[0];
        }

        public MangSoNguyen(int[] a) {
            _a = (int[])a.Clone(); //sao chép để không sửa vào mảng bên ngoài
        }

        //Vị trí tính từ 0 đến SoPhanTu - 1
        public bool ViTriHopLe(int i) {
            return i >= 0 && i < _a.Length;
        }

        public int LayGiaTri(int i) {
            return _a[i];
        }

        //Sắp xếp tăng dần (đổi chỗ trực tiếp)
        public void SapXepTang() {
            for (int i = 0; i < _a.Length - 1; i++)
                for (int j = i + 1; j < _a.Length; j++)
                    if (_a[i] > _a[j]) {
                        int t = _a[i];
                        _a[i] = _a[j];
                        _a[j] = t;
                    }
        }

        //Sắp xếp giảm dần
        public void SapXepGiam() {
            for (int i = 0; i < _a.Length - 1; i++)
                for (int j = i + 1; j < _a.Length; j++)
                    if (_a[i] < _a[j]) {
                        int t = _a[i];
                        _a[i] = _a[j];
                        _a[j] = t;
                    }
        }

        //Tìm giá trị x: trả về vị trí đầu tiên, không có thì trả về -1
        public int TimGiaTri(int x) {
            for (int i = 0; i < _a.Length; i++)
                if (_a[i] == x)
                    return i;
            return -1;
        }

        //Xóa phần tử tại vị trí i. Vị trí sai thì trả về false.
        public bool XoaViTri(int i) {
            if (!ViTriHopLe(i))
                return false;

            int[] b = new int[_a.Length - 1];
            for (int j = 0, k = 0; j < _a.Length; j++)
                if (j != i)
                    b[k++] = _a[j];
            _a = b;
            return true;
        }

        //Xóa tất cả phần tử có giá trị x. Trả về số phần tử đã xóa.
        public int XoaGiaTri(int x) {
            int dem = 0;
            foreach (int v in _a)
                if (v == x)
                    dem++;
            if (dem == 0)
                return 0;

            int[] b = new int[_a.Length - dem];
            int k = 0;
            foreach (int v in _a)
                if (v != x)
                    b[k++] = v;
            _a = b;
            return dem;
        }

        //Thêm x vào vị trí i (0..SoPhanTu, bằng SoPhanTu là thêm vào cuối)
        public bool Them(int x, int i) {
            if (i < 0 || i > _a.Length)
                return false;

            int[] b = new int[_a.Length + 1];
            for (int j = 0; j < i; j++)
                b[j] = _a[j];
            b[i] = x;
            for (int j = i; j < _a.Length; j++)
                b[j + 1] = _a[j];
            _a = b;
            return true;
        }

        //Tổng mảng, tổng chẵn, tổng lẻ
        public long Tong() {
            long s = 0;
            foreach (int v in _a)
                s += v;
            return s;
        }

        public long TongChan() {
            long s = 0;
            foreach (int v in _a)
                if (v % 2 == 0)
                    s += v;
            return s;
        }

        public long TongLe() {
            long s = 0;
            foreach (int v in _a)
                if (v % 2 != 0) //dùng != 0 để số lẻ âm (-3 % 2 = -1) vẫn đúng
                    s += v;
            return s;
        }

        //Max, Min (gọi khi mảng có ít nhất 1 phần tử)
        public int Max() {
            int m = _a[0];
            foreach (int v in _a)
                if (v > m)
                    m = v;
            return m;
        }

        public int Min() {
            int m = _a[0];
            foreach (int v in _a)
                if (v < m)
                    m = v;
            return m;
        }

        //Thay phần tử tại vị trí i bằng giá trị mới
        public bool ThayViTri(int i, int moi) {
            if (!ViTriHopLe(i))
                return false;
            _a[i] = moi;
            return true;
        }

        //Thay tất cả giá trị cu bằng moi. Trả về số phần tử đã thay.
        public int ThayGiaTri(int cu, int moi) {
            int dem = 0;
            for (int i = 0; i < _a.Length; i++)
                if (_a[i] == cu) {
                    _a[i] = moi;
                    dem++;
                }
            return dem;
        }

        //Xuất mảng thành chuỗi, vd: 1 2 3 4 5
        public override string ToString() {
            return string.Join(" ", _a);
        }
    }
}