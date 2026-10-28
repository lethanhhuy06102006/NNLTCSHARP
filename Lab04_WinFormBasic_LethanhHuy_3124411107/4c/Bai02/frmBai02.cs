using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai02 {
    public partial class frmBai02 : Form {
        public frmBai02() {
            InitializeComponent();
        }

        //kiểm tra khi rời khỏi textbox (Tên đăng nhập, Mật khẩu)
        private void txtBatBuoc_Leave(object sender, EventArgs e) {
            KiemTraBatBuoc((Control)sender);
        }

        //Trả về true nếu đã nhập, false nếu bỏ trống và hiện erorprovider
        private bool KiemTraBatBuoc(Control ctr) {
            if (ctr.Text.Trim().Length == 0) {
                errorProvider1.SetError(ctr, "Bạn phải nhập thông tin này");
                return false;
            }
            errorProvider1.SetError(ctr, "");
            return true;
        }

        //Kiểm tra định dạng email khi rời khỏi textbox Địa chỉ email
        private void txtEmail_Leave(object sender, EventArgs e) {
            KiemTraEmail();
        }

        private bool KiemTraEmail() {
            if (!KiemTraBatBuoc(txtEmail)) //bỏ trống
                return false;

            //Dạng: ten@tenmien.duoi
            string mau = @"^[\w\.\-]+@[\w\-]+(\.[\w\-]+)+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), mau)) {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng (vd: abc@gmail.com)");
                return false;
            }
            errorProvider1.SetError(txtEmail, "");
            return true;
        }

        //Nhấn Enter trong textbox Xác nhận mật khẩu = bấm nút Đăng ký
        private void txtXacNhan_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true; //tắt tiếng bíp
                btnDangKy.PerformClick();
            }
        }

        //Nút Đăng ký
        private void btnDangKy_Click(object sender, EventArgs e) {
            //Kiểm tra lại toàn bộ
            bool hopLe = KiemTraBatBuoc(txtTenDN);
            hopLe = KiemTraEmail() && hopLe;
            hopLe = KiemTraBatBuoc(txtMatKhau) && hopLe;

            if (!hopLe) {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng các thông tin có dấu (*)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtXacNhan.Text != txtMatKhau.Text) {
                errorProvider1.SetError(txtXacNhan, "Mật khẩu xác nhận không khớp");
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhan.Focus();
                txtXacNhan.SelectAll();
                return;
            }
            errorProvider1.SetError(txtXacNhan, "");

            //Hiển thị thông tin của tất cả các textbox
            string s = "Tên đăng nhập: " + txtTenDN.Text + "\n"
                    + "Địa chỉ email: " + txtEmail.Text + "\n"
                    + "Mật khẩu: " + txtMatKhau.Text + "\n"
                    + "Xác nhận mật khẩu: " + txtXacNhan.Text;
            MessageBox.Show(s, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Hỏi xác nhận trước khi đóng Form
        private void frmBai2_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}