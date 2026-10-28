using System;
using System.Globalization;
using System.Windows.Forms;

namespace Bai01 {
    public partial class frmBai01 : Form {
        public frmBai01() {
            InitializeComponent();
        }

        //chặn không cho gõ ký tự khác số
        //chỉ cho phép chữ số, phím điều khiển, 1 dấu chấm thập phân, và dấu - ở đầu (số âm).
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return; //hợp lệ
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return; //chỉ 1 dấu chấm
            if (e.KeyChar == '-' && txt.SelectionStart == 0 && !txt.Text.Contains("-"))
                return; //dấu âm ở đầu
            e.Handled = true; //chặn ký tự còn lại
        }

        //dùng ErrorProvider báo lỗi nếu dữ liệu không hợp lệ
        private void txtSo_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length > 0 && !LaSo(ctr.Text, out _))
                errorProvider1.SetError(ctr, "Giá trị nhập phải là số");
            else
                errorProvider1.SetError(ctr, "");
        }

        private bool LaSo(string s, out double so)
        {
            return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out so);
        }

        // Đọc a, b. Nếu sai thì báo bằng MessageBox và trả về false.
        private bool DocDuLieu(out double a, out double b) {
            b = 0;
            if (!LaSo(txtA.Text, out a)) {
                MessageBox.Show("Giá trị a không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtA.Focus();
                return false;
            }
            if (!LaSo(txtB.Text, out b)) {
                MessageBox.Show("Giá trị b không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtB.Focus();
                return false;
            }
            return true;
        }

        private void HienKetQua(double kq) {
            txtKetQua.Text = kq.ToString(CultureInfo.InvariantCulture);
        }

        //Các nút phép tính
        private void btnCong_Click(object sender, EventArgs e) {
            if (DocDuLieu(out double a, out double b))
                HienKetQua(a + b);
        }

        private void btnTru_Click(object sender, EventArgs e) {
            if (DocDuLieu(out double a, out double b))
                HienKetQua(a - b);
        }

        private void btnNhan_Click(object sender, EventArgs e) {
            if (DocDuLieu(out double a, out double b))
                HienKetQua(a * b);
        }

        private void btnChia_Click(object sender, EventArgs e) {
            if (!DocDuLieu(out double a, out double b)) return;
            if (b == 0) {
                MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtB.Focus();
                return;
            }
            HienKetQua(a / b);
        }

        //Hỏi xác nhận trước khi đóng Form
        private void frmBai1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No) e.Cancel = true;
        }
    }
}