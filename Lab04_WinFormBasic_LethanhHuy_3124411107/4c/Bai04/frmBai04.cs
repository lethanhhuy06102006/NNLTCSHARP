using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai04 {
    public partial class frmBai04 : Form {
        //Danh sách lưu các số đã nhập
        private List<int> day = new List<int>();

        public frmBai04() {
            InitializeComponent();
        }

        //Chỉ cho gõ chữ số, phím điều khiển và dấu - ở đầu (số âm)
        private void txtSo_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar == '-' && txtSo.SelectionStart == 0 && !txtSo.Text.Contains("-"))
                return;
            e.Handled = true;
        }

        //Nút Nhập: thêm số vào dãy và hiện ra textbox Dãy vừa nhập
        private void btnNhap_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtSo.Text.Trim(), out int so)) {
                errorProvider1.SetError(txtSo, "Phải nhập một số nguyên");
                MessageBox.Show("Bạn phải nhập một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo.Focus();
                txtSo.SelectAll();
                return;
            }
            errorProvider1.SetError(txtSo, "");

            day.Add(so);
            txtDay.Text = string.Join(" ", day); //vd: 2 1 3 5 4

            //Xóa kết quả cũ vì dãy đã thay đổi
            txtTong.Clear();
            txtChan.Clear();
            txtLe.Clear();

            //Xóa ô nhập, đặt con trỏ lại để nhập số tiếp theo
            txtSo.Clear();
            txtSo.Focus();
        }

        //Nút Tính Tổng: tính tổng, tổng chẵn, tổng lẻ
        private void btnTinhTong_Click(object sender, EventArgs e) {
            if (day.Count == 0) {
                MessageBox.Show("Dãy số đang rỗng, hãy nhập số trước!", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return;
            }

            long tong = 0, tongChan = 0, tongLe = 0;
            foreach (int x in day) {
                tong += x;
                if (x % 2 == 0)
                    tongChan += x;
                else
                    tongLe += x; //số lẻ âm: -3 % 2 = -1 nên vẫn vào đây
            }

            txtTong.Text = tong.ToString();
            txtChan.Text = tongChan.ToString();
            txtLe.Text = tongLe.ToString();
        }

        //Nút Tiếp Tục: trả form về trạng thái ban đầu
        private void btnTiepTuc_Click(object sender, EventArgs e) {
            day.Clear();
            txtSo.Clear();
            txtDay.Clear();
            txtTong.Clear();
            txtChan.Clear();
            txtLe.Clear();
            errorProvider1.Clear();
            txtSo.Focus();
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi đóng Form
        private void frmBai4_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}