using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XuLyChuoi {
    public partial class BTNC1 : Form {
        //Các mảng chuỗi để ghép thành tên ngẫu nhiên: Họ + Tên lót + Tên
        private string[] dsHo = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        private string[] dsTenLot = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        private string[] dsTen = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Ký", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };
        private Random rd = new Random();

        public BTNC1() {
            InitializeComponent();
        }

        //Tách tên đầy đủ thành các từ
        private string[] TachTu(string s) {
            return s.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        //Họ là từ đầu tiên, tên là từ cuối cùng
        private string LayHo(string s) {
            string[] tu = TachTu(s);
            return tu.Length == 0 ? "" : tu[0];
        }

        private string LayTen(string s) {
            string[] tu = TachTu(s);
            return tu.Length == 0 ? "" : tu[tu.Length - 1];
        }

        //Lấy danh sách vị trí các phần tử đang chọn trong listbox
        private List<int> LayViTriDangChon() {
            List<int> ds = new List<int>();
            foreach (int i in lstTen.SelectedIndices)
                ds.Add(i);
            return ds;
        }

        //Báo cho người dùng chọn phần tử trước, trả về true nếu đã có phần tử được chọn
        private bool CoPhanTuChon() {
            if (lstTen.SelectedIndices.Count == 0) {
                MessageBox.Show("Hãy chọn ít nhất một phần tử trong danh sách!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //Nút Nhập tên ngẫu nhiên: thêm 50 tên ghép từ 3 mảng chuỗi
        private void btnNgauNhien_Click(object sender, EventArgs e) {
            lstTen.BeginUpdate(); //tạm dừng vẽ lại để thêm nhanh hơn
            for (int i = 0; i < 50; i++) {
                string ho = dsHo[rd.Next(dsHo.Length)];
                string lot = dsTenLot[rd.Next(dsTenLot.Length)];
                string ten = dsTen[rd.Next(dsTen.Length)];
                lstTen.Items.Add(ho + " " + lot + " " + ten);
            }
            lstTen.EndUpdate();
        }

        //Xóa các phần tử thỏa điều kiện, duyệt từ cuối lên để không bị lệch vị trí. Trả về số phần tử đã xóa.
        private int XoaPhanTu(Func<string, bool> dieuKien) {
            int dem = 0;
            for (int i = lstTen.Items.Count - 1; i >= 0; i--) {
                if (dieuKien((string)lstTen.Items[i])) {
                    lstTen.Items.RemoveAt(i);
                    dem++;
                }
            }
            return dem;
        }

        //Nút Xóa phần tử đang chọn
        private void btnXoaChon_Click(object sender, EventArgs e) {
            if (!CoPhanTuChon())
                return;
            List<int> ds = LayViTriDangChon();
            for (int i = ds.Count - 1; i >= 0; i--) //xóa từ vị trí lớn nhất trước
                lstTen.Items.RemoveAt(ds[i]);
        }

        //Nút Xóa phần tử có tên là Sơn
        private void btnXoaSon_Click(object sender, EventArgs e) {
            int dem = XoaPhanTu(s => string.Equals(LayTen(s), "Sơn", StringComparison.OrdinalIgnoreCase));
            if (dem == 0)
                MessageBox.Show("Không có phần tử nào có tên là Sơn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Nút Xóa phần tử có họ là Lê
        private void btnXoaLe_Click(object sender, EventArgs e) {
            int dem = XoaPhanTu(s => string.Equals(LayHo(s), "Lê", StringComparison.OrdinalIgnoreCase));
            if (dem == 0)
                MessageBox.Show("Không có phần tử nào có họ là Lê!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Biến đổi chuỗi của các phần tử đang chọn, giữ nguyên vị trí và vẫn giữ trạng thái đang chọn
        private void BienDoiPhanTuChon(Func<string, string> bienDoi) {
            if (!CoPhanTuChon())
                return;
            List<int> ds = LayViTriDangChon();
            lstTen.BeginUpdate();
            foreach (int i in ds)
                lstTen.Items[i] = bienDoi((string)lstTen.Items[i]);
            foreach (int i in ds) //gán phần tử xong bị mất chọn nên chọn lại
                lstTen.SetSelected(i, true);
            lstTen.EndUpdate();
        }

        //Nút chuyển thành chữ HOA
        private void btnHoa_Click(object sender, EventArgs e) {
            BienDoiPhanTuChon(s => s.ToUpper());
        }

        //Nút chuyển thành chữ thường
        private void btnThuong_Click(object sender, EventArgs e) {
            BienDoiPhanTuChon(s => s.ToLower());
        }

        //Nút chuyển thành viết Hoa đầu mỗi từ
        private void btnHoaDauTu_Click(object sender, EventArgs e) {
            BienDoiPhanTuChon(s => {
                string[] tu = TachTu(s.ToLower());
                for (int i = 0; i < tu.Length; i++)
                    tu[i] = char.ToUpper(tu[i][0]) + tu[i].Substring(1);
                return string.Join(" ", tu);
            });
        }

        //Nút Xóa tất cả các phần tử
        private void btnXoaTatCa_Click(object sender, EventArgs e) {
            if (lstTen.Items.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa tất cả các phần tử?", "Xóa tất cả",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                lstTen.Items.Clear();
        }

        //Double click vào một tên thì mở InputBox cho nhập tên mới thay vào vị trí đó
        private void lstTen_MouseDoubleClick(object sender, MouseEventArgs e) {
            int vt = lstTen.IndexFromPoint(e.Location); //vị trí phần tử vừa được double click
            if (vt == ListBox.NoMatches)
                return;

            string cu = (string)lstTen.Items[vt];
            string moi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên mới:", "Sửa tên", cu).Trim();
            if (moi.Length == 0) //bấm Cancel hoặc để trống thì giữ nguyên tên cũ
                return;

            lstTen.Items[vt] = moi;
            lstTen.SelectedIndex = vt;
        }
    }
}