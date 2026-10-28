using System;
using System.Globalization;
using System.Windows.Forms;

namespace GiaiPhuongTrinh {
    public partial class Bai01 : Form {
        public Bai01() {
            InitializeComponent();
        }

        //Khi form load: chọn bậc nhất, nút Giải mờ đi
        private void Bai01_Load(object sender, EventArgs e) {
            rdoBacNhat.Checked = true;
            CapNhatGiaoDien();
            btnGiai.Enabled = false;
        }

        //Đổi lựa chọn bậc nhất / bậc hai
        private void rdo_CheckedChanged(object sender, EventArgs e) {
            CapNhatGiaoDien();
        }

        //Bậc nhất: ô c mờ đi. Bậc hai: hiện đủ 3 ô.
        private void CapNhatGiaoDien() {
            bool bacHai = rdoBacHai.Checked;
            lblC.Enabled = bacHai;
            txtC.Enabled = bacHai;
            if (!bacHai) {
                txtC.Clear();
                errorProvider1.SetError(txtC, "");
            }
            txtKetQua.Clear();
            KiemTraNhap();
        }

        //Chỉ cho gõ chữ số, 1 dấu chấm, dấu '-' ở đầu
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e) {
            TextBox txt = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;
            if (e.KeyChar == '-' && txt.SelectionStart == 0 && !txt.Text.Contains("-"))
                return;
            e.Handled = true;
        }

        //Mỗi lần sửa ô nhập: báo lỗi nếu sai và kiểm tra có bật nút Giải không
        private void txtSo_TextChanged(object sender, EventArgs e) {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Length > 0 && !LaSo(txt.Text, out _))
                errorProvider1.SetError(txt, "Giá trị nhập phải là số");
            else
                errorProvider1.SetError(txt, "");

            txtKetQua.Clear();
            KiemTraNhap();
        }

        private bool LaSo(string s, out double so) {
            return double.TryParse(s.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out so);
        }

        //Nhập đủ và đúng các ô cần thiết thì nút Giải mới có tác dụng
        private void KiemTraNhap() {
            bool du = LaSo(txtA.Text, out _) && LaSo(txtB.Text, out _);
            if (rdoBacHai.Checked)
                du = du && LaSo(txtC.Text, out _);
            btnGiai.Enabled = du;
        }

        //Nút Giải: tạo đối tượng PhuongTrinhBacHai và gọi phương thức giải
        private void btnGiai_Click(object sender, EventArgs e) {
            LaSo(txtA.Text, out double a);
            LaSo(txtB.Text, out double b);

            PhuongTrinhBacHai pt;
            if (rdoBacNhat.Checked) {
                pt = new PhuongTrinhBacHai(a, b);
                txtKetQua.Text = pt.GiaiBacNhat();
            }
            else {
                LaSo(txtC.Text, out double c);
                pt = new PhuongTrinhBacHai(a, b, c);
                txtKetQua.Text = pt.GiaiBacHai();
            }

            btnGiai.Enabled = false; //giải xong thì nút Giải mờ đi
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi đóng Form
        private void Bai01_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}