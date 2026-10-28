using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UocSo {
    public partial class Bai01 : Form {
        public Bai01() {
            InitializeComponent();
        }

        //Textbox Nhập số: chỉ cho gõ chữ số
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

        //Nút Cập nhật: kiểm tra số vừa nhập rồi thêm vào combobox
        private void btnCapNhat_Click(object sender, EventArgs e) {
            string s = txtSo.Text.Trim();

            if (s.Length == 0) {
                BaoLoi("Bạn chưa nhập số");
                return;
            }
            if (!int.TryParse(s, out int so)) {
                BaoLoi("Số nhập vào không hợp lệ hoặc quá lớn");
                return;
            }
            if (so <= 0) {
                BaoLoi("Phải nhập số nguyên dương (lớn hơn 0)");
                return;
            }
            if (cboSo.Items.Contains(so)) { //số đã có trong combobox thì không thêm
                BaoLoi("Số " + so + " đã có trong danh sách");
                return;
            }

            cboSo.Items.Add(so);
            cboSo.SelectedItem = so; //chọn luôn số vừa thêm, listbox hiện ước số của nó
            txtSo.Clear(); //xóa dữ liệu trong textbox
            txtSo.Focus(); //đặt con trỏ lại textbox
        }

        //Chọn một số trong combobox thì liệt kê các ước số vào listbox
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e) {
            lstUocSo.Items.Clear();
            if (cboSo.SelectedItem == null)
                return;

            int n = (int)cboSo.SelectedItem;
            foreach (int u in LayUocSo(n))
                lstUocSo.Items.Add(u);
        }

        //Lấy các ước số của n theo thứ tự tăng dần
        private List<int> LayUocSo(int n) {
            List<int> nhoHon = new List<int>(); //các ước nhỏ: 1 .. căn n
            List<int> lonHon = new List<int>(); //các ước lớn tương ứng: n / ước nhỏ
            for (int i = 1; (long)i * i <= n; i++) {
                if (n % i == 0) {
                    nhoHon.Add(i);
                    if (i != n / i)
                        lonHon.Add(n / i);
                }
            }
            lonHon.Reverse();
            nhoHon.AddRange(lonHon);
            return nhoHon;
        }

        private bool LaNguyenTo(int x) {
            if (x < 2)
                return false;
            for (int i = 2; (long)i * i <= x; i++)
                if (x % i == 0)
                    return false;
            return true;
        }

        //Listbox chưa có ước số thì báo cho người dùng chọn số trước
        private bool CoUocSo() {
            if (lstUocSo.Items.Count == 0) {
                MessageBox.Show("Hãy chọn một số trong combobox trước!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSo.Focus();
                return false;
            }
            return true;
        }

        //Nút Tổng các ước số
        private void btnTong_Click(object sender, EventArgs e) {
            if (!CoUocSo())
                return;
            long tong = 0;
            foreach (object item in lstUocSo.Items) //tính dựa trên các ước số trong listbox
                tong += (int)item;
            MessageBox.Show("Tổng các ước số của " + cboSo.SelectedItem + " là: " + tong,
                            "Tổng các ước số", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Nút Số lượng các ước số chẵn
        private void btnChan_Click(object sender, EventArgs e) {
            if (!CoUocSo())
                return;
            int dem = 0;
            foreach (object item in lstUocSo.Items)
                if ((int)item % 2 == 0)
                    dem++;
            MessageBox.Show("Số lượng các ước số chẵn của " + cboSo.SelectedItem + " là: " + dem,
                            "Ước số chẵn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Nút Số lượng các ước số nguyên tố
        private void btnNguyenTo_Click(object sender, EventArgs e) {
            if (!CoUocSo())
                return;
            int dem = 0;
            foreach (object item in lstUocSo.Items)
                if (LaNguyenTo((int)item))
                    dem++;
            MessageBox.Show("Số lượng các ước số nguyên tố của " + cboSo.SelectedItem + " là: " + dem,
                            "Ước số nguyên tố", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void Bai01_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}