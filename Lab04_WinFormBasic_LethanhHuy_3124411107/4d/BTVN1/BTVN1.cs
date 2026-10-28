using System;
using System.Windows.Forms;

namespace KhachSan {
    public partial class BTVN1 : Form {
        private int tongLuot = 0; //tổng số lượt người trả phòng (chưa tổng kết)
        private long tongTien = 0; //tổng tiền thu được (chưa tổng kết)
        private bool daThanhToan = false; //khách hiện tại đã thanh toán chưa

        public BTVN1() {
            InitializeComponent();
        }

        //Form_Load: con trỏ ở ô tên, các nút TongKet, NhapMoi, ThanhToan bị mờ
        private void BTVN1_Load(object sender, EventArgs e) {
            btnTongKet.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnThanhToan.Enabled = false;
            this.ActiveControl = txtHoTen;
        }

        //Số ngày ở chỉ cho nhập số
        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Tên và địa chỉ không được để trống
        private void txtBatBuoc_Leave(object sender, EventArgs e) {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Trim().Length == 0)
                errorProvider1.SetError(txt, "Không được để trống");
            else
                errorProvider1.SetError(txt, "");
        }

        //Thông tin thay đổi thì kiểm tra lại
        private void ThongTin_Changed(object sender, EventArgs e) {
            KiemTraNhap();
        }

        //Nhập đủ tên, địa chỉ, số ngày > 0, chọn loại phòng thì nút Thanh toán mới có tác dụng
        private void KiemTraNhap() {
            bool du = txtHoTen.Text.Trim().Length > 0
                   && txtDiaChi.Text.Trim().Length > 0
                   && int.TryParse(txtSoNgay.Text, out int n) && n > 0
                   && (rdoPhongDon.Checked || rdoPhongDoi.Checked || rdoPhongBa.Checked);
            btnThanhToan.Enabled = du && !daThanhToan; //đã thanh toán thì không cho thanh toán lại
        }

        //Tính tiền cho khách hiện tại
        private long TinhTien() {
            int soNgay = int.Parse(txtSoNgay.Text);
            long tien = 0;

            //Loại phòng: tính theo ngày
            if (rdoPhongDon.Checked)
                tien += 300000L * soNgay;
            else if (rdoPhongDoi.Checked)
                tien += 350000L * soNgay;
            else if (rdoPhongBa.Checked)
                tien += 400000L * soNgay;

            //Tiện nghi: mỗi loại cộng thêm 10.000đ
            if (chkTivi.Checked) tien += 10000;
            if (chkInternet.Checked) tien += 10000;
            if (chkMayNuocNong.Checked) tien += 10000;

            //Dịch vụ: Karaoke 50.000đ, Ăn sáng 15.000đ/1 ngày
            if (chkKaraoke.Checked) tien += 50000;
            if (chkAnSang.Checked) tien += 15000L * soNgay;

            return tien;
        }

        //Nút Thanh toán: tính tiền, hiện lên label Thành tiền, cộng dồn tổng tiền và tổng lượt
        private void btnThanhToan_Click(object sender, EventArgs e) {
            long tien = TinhTien();
            lblThanhTien.Text = tien + " VNĐ";

            tongTien += tien;
            tongLuot += 1;
            daThanhToan = true;

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
            btnNhapMoi.Focus();
        }

        //Nút Nhập mới: trả form về trạng thái ban đầu, nút Nhập mới mờ đi
        private void btnNhapMoi_Click(object sender, EventArgs e) {
            daThanhToan = false;
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Clear();
            rdoPhongDon.Checked = false;
            rdoPhongDoi.Checked = false;
            rdoPhongBa.Checked = false;
            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;
            lblThanhTien.Text = "";
            errorProvider1.Clear();

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            txtHoTen.Focus();
        }

        //Nút Tổng kết: hiện tổng lượt người và tổng tiền, rồi đặt lại về 0
        private void btnTongKet_Click(object sender, EventArgs e) {
            lblSoLuot.Text = tongLuot.ToString();
            lblTongTien.Text = tongTien + " VNĐ";

            tongLuot = 0;
            tongTien = 0;
            btnTongKet.Enabled = false;
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void BTVN1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}