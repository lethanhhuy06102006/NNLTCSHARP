using System;
using System.Globalization;
using System.Windows.Forms;

namespace CafeSinhVien {
    public partial class BTNC1 : Form {
        private int tongKhach = 0; //tổng số khách đã thanh toán
        private long tongTien = 0; //tổng tiền đã thanh toán
        private long tienNhomHienTai = 0; //tiền của nhóm khách vừa tính
        private int soKhachHienTai = 0;

        public BTNC1() {
            InitializeComponent();
        }

        //Định dạng tiền kiểu Việt Nam, vd: 20.000đ
        private string DinhDangTien(long tien) {
            return tien.ToString("#,##0", new CultureInfo("vi-VN")) + "đ";
        }

        //Form_Load: con trỏ ở ô tên, 3 nút TinhTien, NhapLai, ThanhToan bị mờ
        private void BTNC1_Load(object sender, EventArgs e) {
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
            lblTongKhach.Text = "0";
            lblTongTien.Text = DinhDangTien(0);
            this.ActiveControl = txtTen; //đặt con trỏ vào ô tên khi form hiện lên
        }

        //Ô số khách chỉ cho nhập số
        private void txtSoKhach_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Tên khách hàng không được để trống
        private void txtTen_Leave(object sender, EventArgs e) {
            if (txtTen.Text.Trim().Length == 0)
                errorProvider1.SetError(txtTen, "Tên khách hàng không được để trống");
            else
                errorProvider1.SetError(txtTen, "");
        }

        //Bất kỳ thông tin nào thay đổi: kiểm tra lại, và phải Tính tiền lại trước khi Thanh toán
        private void ThongTin_Changed(object sender, EventArgs e) {
            btnThanhToan.Enabled = false;
            KiemTraNhap();
        }

        //Nhập đủ tên, số khách > 0, có gọi ít nhất 1 món thì nút Tính tiền mới có tác dụng
        private void KiemTraNhap() {
            bool coTen = txtTen.Text.Trim().Length > 0;
            bool coSoKhach = int.TryParse(txtSoKhach.Text, out int n) && n > 0;
            bool coMon = LayGiaNuocUong() > 0 || LayGiaThucAn() > 0;
            btnTinhTien.Enabled = coTen && coSoKhach && coMon;
        }

        //Giá nước uống đang chọn (giá lưu trong thuộc tính Tag của radio button)
        private long LayGiaNuocUong() {
            foreach (Control ctr in grpNuocUong.Controls)
                if (ctr is RadioButton rdo && rdo.Checked)
                    return Convert.ToInt64(rdo.Tag);
            return 0;
        }

        //Tổng giá các món ăn được check
        private long LayGiaThucAn() {
            long s = 0;
            foreach (Control ctr in grpThucAn.Controls)
                if (ctr is CheckBox chk && chk.Checked)
                    s += Convert.ToInt64(chk.Tag);
            return s;
        }

        //Danh sách món đã gọi để hiện lên MessageBox
        private string DanhSachMon() {
            string s = "";
            foreach (Control ctr in grpNuocUong.Controls)
                if (ctr is RadioButton rdo && rdo.Checked)
                    s += "  - " + rdo.Text + ": " + DinhDangTien(Convert.ToInt64(rdo.Tag)) + "\n";
            foreach (Control ctr in grpThucAn.Controls)
                if (ctr is CheckBox chk && chk.Checked)
                    s += "  - " + chk.Text + ": " + DinhDangTien(Convert.ToInt64(chk.Tag)) + "\n";
            return s;
        }

        //Nút Tính tiền
        private void btnTinhTien_Click(object sender, EventArgs e) {
            soKhachHienTai = int.Parse(txtSoKhach.Text);
            long giaMotNguoi = LayGiaNuocUong() + LayGiaThucAn();
            long tien = giaMotNguoi * soKhachHienTai;

            string s = "Khách hàng: " + txtTen.Text.Trim() + "\n"
                    + "Số khách: " + soKhachHienTai + "\n"
                    + "Các món gọi (giá 1 phần):\n" + DanhSachMon()
                    + "Giá 1 người: " + DinhDangTien(giaMotNguoi) + "\n"
                    + "Thành tiền: " + DinhDangTien(tien) + "\n";

            if (chkSinhVien.Checked) { //sinh viên được giảm 20%
                long giam = tien * 20 / 100;
                tien -= giam;
                s += "Giảm giá sinh viên (20%): -" + DinhDangTien(giam) + "\n";
            }
            s += "TỔNG CỘNG: " + DinhDangTien(tien);

            tienNhomHienTai = tien;
            MessageBox.Show(s, "Tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        //Nút Nhập lại: về trạng thái ban đầu, nút Nhập lại mờ đi
        private void btnNhapLai_Click(object sender, EventArgs e) {
            XoaThongTinNhap();
        }

        //Nút Thanh toán: cộng dồn vào tổng khách, tổng tiền, sẵn sàng cho nhóm mới
        private void btnThanhToan_Click(object sender, EventArgs e) {
            tongKhach += soKhachHienTai;
            tongTien += tienNhomHienTai;
            lblTongKhach.Text = tongKhach.ToString();
            lblTongTien.Text = DinhDangTien(tongTien);
            MessageBox.Show("Đã thanh toán " + DinhDangTien(tienNhomHienTai) + " cho khách " + txtTen.Text.Trim(), "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaThongTinNhap(); //nút Thanh toán cũng mờ đi trong hàm này
        }

        //Xóa thông tin nhập của nhóm khách (không xóa tổng khách, tổng tiền)
        private void XoaThongTinNhap() {
            txtTen.Clear();
            txtSoKhach.Clear();
            chkSinhVien.Checked = false;
            foreach (Control ctr in grpNuocUong.Controls)
                if (ctr is RadioButton rdo)
                    rdo.Checked = false;
            foreach (Control ctr in grpThucAn.Controls)
                if (ctr is CheckBox chk)
                    chk.Checked = false;

            errorProvider1.Clear();
            tienNhomHienTai = 0;
            soKhachHienTai = 0;
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
            txtTen.Focus();
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void BTNC1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}