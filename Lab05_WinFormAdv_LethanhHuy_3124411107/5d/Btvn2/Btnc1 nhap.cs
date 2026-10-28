using System;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    public partial class BTNC1_Nhap : Form {
        private BTNC1 formChinh; //giữ form chính để thêm học viên vào listbox của nó

        public BTNC1_Nhap(BTNC1 chinh) {
            InitializeComponent();
            formChinh = chinh;
        }

        //Nút Cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e) {
            string hoTen = txtHoTen.Text.Trim();
            if (hoTen.Length == 0) {
                MessageBox.Show("Bạn phải nhập họ và tên!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus(); //đặt con trỏ vào textbox Họ và Tên
                return;
            }

            formChinh.ThemHocVien(hoTen, cboLop.Text); //thêm vào listbox của lớp đã chọn
            txtHoTen.Clear(); //xóa trắng để nhập tiếp người khác
            txtHoTen.Focus();
        }

        //Nút Trở về: đóng form này, quay lại form chính
        private void btnTroVe_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}