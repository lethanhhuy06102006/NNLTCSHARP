using System;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyTaiKhoan {
    public partial class Bai02 : Form {
        public Bai02() {
            InitializeComponent();
        }

        //Form_Load: Thêm, Thoát được dùng; Lưu, Xóa bị mờ; con trỏ nằm ở Số tài khoản
        private void Bai02_Load(object sender, EventArgs e) {
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtTongTien.Text = "0";
            txtSoTK.Focus();
        }

        //Textbox Số tài khoản và Số tiền chỉ cho gõ chữ số
        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txt_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError((TextBox)sender, "");
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về textbox bị lỗi
        private void BaoLoi(TextBox txt, string loi) {
            errorProvider1.SetError(txt, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt.Focus();
            txt.SelectAll();
        }

        //Xóa trắng 4 textbox
        private void LamTrong() {
            errorProvider1.Clear();
            txtSoTK.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }

        //Chuyển giữa 2 trạng thái: them = true là đang nhập mới (nút Thêm đổi thành Hủy)
        private void DatCheDoThem(bool them) {
            lvTK.SelectedItems.Clear(); //bỏ chọn dòng trong listview
            LamTrong();
            btnThem.Text = them ? "Hủy" : "Thêm";
            btnLuu.Enabled = them;
            btnXoa.Enabled = false;
            txtSoTK.Focus();
        }

        //Nút Thêm / Hủy
        private void btnThem_Click(object sender, EventArgs e) {
            if (btnThem.Text == "Thêm")
                DatCheDoThem(true); //đổi thành Hủy, bật Lưu, textbox rỗng, con trỏ vào Số tài khoản
            else
                DatCheDoThem(false); //Hủy: quay về trạng thái ban đầu
        }

        //Kiểm tra số tài khoản đã có trong listview chưa
        private bool TonTaiSoTK(string so) {
            foreach (ListViewItem dong in lvTK.Items) {
                if (dong.SubItems[1].Text == so)
                    return true;
            }
            return false;
        }

        //Nút Lưu: đưa dữ liệu từ các textbox vào listview
        private void btnLuu_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string soTK = txtSoTK.Text.Trim();
            string ten = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (soTK.Length == 0) {
                BaoLoi(txtSoTK, "Số tài khoản không được để trống");
                return;
            }
            if (TonTaiSoTK(soTK)) {
                BaoLoi(txtSoTK, "Số tài khoản \"" + soTK + "\" đã tồn tại");
                return;
            }
            if (ten.Length == 0) {
                BaoLoi(txtTenKH, "Tên khách hàng không được để trống");
                return;
            }
            if (diaChi.Length == 0) {
                BaoLoi(txtDiaChi, "Địa chỉ không được để trống");
                return;
            }
            if (!long.TryParse(txtSoTien.Text, out long soTien)) {
                BaoLoi(txtSoTien, "Số tiền không hợp lệ");
                return;
            }

            ListViewItem dong = new ListViewItem((lvTK.Items.Count + 1).ToString()); //cột 0: STT
            dong.SubItems.Add(soTK);
            dong.SubItems.Add(ten);
            dong.SubItems.Add(diaChi);
            dong.SubItems.Add(soTien.ToString("N0", CultureInfo.InvariantCulture)); //dạng 5,200,000
            dong.Tag = soTien; //giữ số thật để cộng tổng
            lvTK.Items.Add(dong);

            CapNhatTong();
            DatCheDoThem(false); //lưu xong quay về trạng thái ban đầu
        }

        //Click một khách hàng trong listview thì hiện thông tin lên các textbox
        private void lvTK_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvTK.SelectedItems.Count == 0) {
                btnXoa.Enabled = false;
                if (btnThem.Text == "Thêm") //đang không nhập mới thì làm trống textbox
                    LamTrong();
                return;
            }

            ListViewItem dong = lvTK.SelectedItems[0];
            errorProvider1.Clear();
            txtSoTK.Text = dong.SubItems[1].Text;
            txtTenKH.Text = dong.SubItems[2].Text;
            txtDiaChi.Text = dong.SubItems[3].Text;
            txtSoTien.Text = ((long)dong.Tag).ToString();

            btnThem.Text = "Thêm"; //đang xem một mẫu tin thì thoát chế độ nhập mới
            btnLuu.Enabled = false;
            btnXoa.Enabled = true; //Xóa chỉ bật khi có mẫu tin được chọn
        }

        //Bấm vào vùng trống của listview thì bỏ chọn
        private void lvTK_MouseDown(object sender, MouseEventArgs e) {
            if (lvTK.GetItemAt(e.X, e.Y) == null)
                lvTK.SelectedItems.Clear();
        }

        //Nút Xóa: xóa mẫu tin đang chọn rồi đánh lại STT, tính lại tổng
        private void btnXoa_Click(object sender, EventArgs e) {
            if (lvTK.SelectedItems.Count == 0)
                return;

            ListViewItem dong = lvTK.SelectedItems[0];
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản " + dong.SubItems[1].Text + "?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            lvTK.Items.Remove(dong);
            CapNhatSTT();
            CapNhatTong();
        }

        //Đánh lại STT từ 1 cho tất cả các dòng
        private void CapNhatSTT() {
            for (int i = 0; i < lvTK.Items.Count; i++)
                lvTK.Items[i].SubItems[0].Text = (i + 1).ToString();
        }

        //Cộng số tiền của tất cả các dòng
        private void CapNhatTong() {
            long tong = 0;
            foreach (ListViewItem dong in lvTK.Items)
                tong += (long)dong.Tag;
            txtTongTien.Text = tong.ToString("N0", CultureInfo.InvariantCulture);
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void Bai02_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}