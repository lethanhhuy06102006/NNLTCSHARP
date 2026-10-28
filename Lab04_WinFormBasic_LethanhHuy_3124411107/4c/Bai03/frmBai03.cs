using System;
using System.Windows.Forms;

namespace Bai03 {
    public partial class frmBai03 : Form {
        public frmBai03() {
            InitializeComponent();
        }

        //Chỉ cho gõ chữ số (UCLN, BCNN tính trên số nguyên dương)
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Rời khỏi textbox: báo lỗi bằng ErrorProvider
        private void txtSo_Leave(object sender, EventArgs e) {
            KiemTra((TextBox)sender, out _);
        }

        //Kiểm tra textbox chứa số nguyên dương. Sai thì hiện ErrorProvider và trả về false.
        private bool KiemTra(TextBox txt, out long so) {
            so = 0;
            string loi = "";

            if (txt.Text.Trim().Length == 0)
                loi = "Bạn chưa nhập số";
            else if (!long.TryParse(txt.Text.Trim(), out so))
                loi = "Phải nhập số nguyên (hoặc số quá lớn)";
            else if (so <= 0)
                loi = "Phải nhập số nguyên dương (> 0)";

            errorProvider1.SetError(txt, loi);
            return loi == "";
        }

        //Thuật toán Euclid tìm UCLN
        private long UCLN(long a, long b) {
            while (b != 0) {
                long r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        //BCNN = a * b / UCLN  (chia trước rồi nhân để tránh tràn số)
        private long BCNN(long a, long b) {
            return a / UCLN(a, b) * b;
        }

        //Nút Thực Hiện
        private void btnThucHien_Click(object sender, EventArgs e) {
            if (!KiemTra(txtA, out long a)) {
                MessageBox.Show("Số a không hợp lệ: " + errorProvider1.GetError(txtA), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtA.Focus();
                return;
            }
            if (!KiemTra(txtB, out long b)) {
                MessageBox.Show("Số b không hợp lệ: " + errorProvider1.GetError(txtB), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtB.Focus();
                return;
            }

            try {
                txtUCLN.Text = UCLN(a, b).ToString();
                txtBCNN.Text = checked(BCNN(a, b)).ToString();
            }
            catch (OverflowException) {
                MessageBox.Show("Kết quả BCNN quá lớn, không tính được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút Tiếp Tục: xóa dữ liệu, đưa con trỏ về ô a
        private void btnTiepTuc_Click(object sender, EventArgs e) {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            errorProvider1.Clear();
            txtA.Focus();
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi đóng Form
        private void frmBai3_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}