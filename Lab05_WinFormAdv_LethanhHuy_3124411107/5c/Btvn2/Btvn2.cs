using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListBoxXuLy {
    public partial class BTVN2 : Form {
        public BTVN2() {
            InitializeComponent();
        }

        //Textbox chỉ cho gõ chữ số (số tự nhiên)
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txtSo_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError(txtSo, "");
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về textbox
        private void BaoLoi(string loi) {
            errorProvider1.SetError(txtSo, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtSo.Focus();
            txtSo.SelectAll();
        }

        //Nút Nhập: thêm số tự nhiên vào listbox
        private void btnNhap_Click(object sender, EventArgs e) {
            string s = txtSo.Text.Trim();
            if (s.Length == 0) {
                BaoLoi("Bạn chưa nhập số");
                return;
            }
            if (!int.TryParse(s, out int n) || n < 0) {
                BaoLoi("Phải nhập số tự nhiên hợp lệ (0, 1, 2, ...)");
                return;
            }

            lstSo.Items.Add((long)n); //lưu kiểu long để tính bình phương không bị tràn số
            txtSo.Clear();
            txtSo.Focus();
        }

        //Báo cho người dùng biết nếu listbox đang rỗng, trả về true nếu có phần tử
        private bool CoPhanTu() {
            if (lstSo.Items.Count == 0) {
                MessageBox.Show("Listbox đang rỗng, hãy nhập số trước!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return false;
            }
            return true;
        }

        //Nút Tổng các phần tử trong List
        private void btnTong_Click(object sender, EventArgs e) {
            if (!CoPhanTu())
                return;
            try {
                long tong = 0;
                foreach (object item in lstSo.Items)
                    tong = checked(tong + (long)item); //checked: báo lỗi nếu tràn số
                MessageBox.Show("Tổng các phần tử trong listbox là: " + tong, "Tổng",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OverflowException) {
                MessageBox.Show("Tổng quá lớn, không tính được!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút Xóa phần tử đầu và cuối
        private void btnXoaDauCuoi_Click(object sender, EventArgs e) {
            if (!CoPhanTu())
                return;
            lstSo.Items.RemoveAt(lstSo.Items.Count - 1); //xóa cuối trước để vị trí đầu không đổi
            if (lstSo.Items.Count > 0) //nếu ban đầu chỉ có 1 phần tử thì phần tử đó là cả đầu lẫn cuối
                lstSo.Items.RemoveAt(0);
        }

        //Nút Xóa phần tử đang chọn trong listbox
        private void btnXoaChon_Click(object sender, EventArgs e) {
            if (lstSo.SelectedIndices.Count == 0) {
                MessageBox.Show("Hãy chọn ít nhất một phần tử cần xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> ds = new List<int>();
            foreach (int i in lstSo.SelectedIndices)
                ds.Add(i);
            for (int i = ds.Count - 1; i >= 0; i--) //xóa từ vị trí lớn nhất để không bị lệch
                lstSo.Items.RemoveAt(ds[i]);
        }

        //Tính giá trị mới cho mọi phần tử bằng hàm bienDoi. Nếu bị tràn số thì không đổi gì cả.
        private void BienDoiTatCa(Func<long, long> bienDoi) {
            if (!CoPhanTu())
                return;

            long[] moi = new long[lstSo.Items.Count];
            try {
                for (int i = 0; i < moi.Length; i++)
                    moi[i] = bienDoi((long)lstSo.Items[i]);
            }
            catch (OverflowException) {
                MessageBox.Show("Kết quả vượt quá giới hạn của kiểu số, không thực hiện được!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstSo.BeginUpdate();
            for (int i = 0; i < moi.Length; i++)
                lstSo.Items[i] = moi[i];
            lstSo.EndUpdate();
        }

        //Nút Tăng mỗi phần tử lên 2
        private void btnTang2_Click(object sender, EventArgs e) {
            BienDoiTatCa(x => checked(x + 2));
        }

        //Nút Thay bằng bình phương của chính nó
        private void btnBinhPhuong_Click(object sender, EventArgs e) {
            BienDoiTatCa(x => checked(x * x));
        }

        //Nút Chọn số chẵn
        private void btnChonChan_Click(object sender, EventArgs e) {
            ChonTheoDieuKien(true);
        }

        //Nút Chọn số lẻ
        private void btnChonLe_Click(object sender, EventArgs e) {
            ChonTheoDieuKien(false);
        }

        //Chọn (bôi đen) các phần tử là số chẵn hoặc số lẻ
        private void ChonTheoDieuKien(bool chan) {
            if (!CoPhanTu())
                return;

            lstSo.ClearSelected(); //bỏ chọn hết trước khi chọn mới
            for (int i = 0; i < lstSo.Items.Count; i++) {
                bool laChan = (long)lstSo.Items[i] % 2 == 0;
                if (laChan == chan)
                    lstSo.SetSelected(i, true);
            }
            lstSo.Focus(); //để các dòng được chọn hiện rõ
        }

        //Nút KẾT THÚC
        private void btnKetThuc_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void BTVN2_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}