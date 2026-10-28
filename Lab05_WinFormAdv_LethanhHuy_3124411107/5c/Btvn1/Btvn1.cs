using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TuDien {
    public partial class BTVN1 : Form {
        //Danh sách các từ lưu sẵn vào List
        private List<TuVung> dsTu = new List<TuVung>();

        private bool dangTuDien = false; //true: đang tự điền chữ vào combobox, bỏ qua TextChanged
        private bool dangXoaChu = false; //true: người dùng vừa bấm Backspace/Delete, không tự điền lại

        public BTVN1() {
            InitializeComponent();
        }

        //Form_Load: nạp danh sách từ vào List rồi đưa vào 2 combobox
        private void BTVN1_Load(object sender, EventArgs e) {
            dsTu.Add(new TuVung("student", "Sinh viên, học sinh"));
            dsTu.Add(new TuVung("teacher", "Giáo viên"));
            dsTu.Add(new TuVung("worker", "Công nhân"));
            dsTu.Add(new TuVung("hat", "Cái mũ"));
            dsTu.Add(new TuVung("head", "Cái đầu"));
            dsTu.Add(new TuVung("mouse", "Con chuột"));
            dsTu.Add(new TuVung("cat", "Con mèo"));
            dsTu.Add(new TuVung("dog", "Con chó"));
            dsTu.Add(new TuVung("snake", "Con rắn"));
            dsTu.Add(new TuVung("lamb", "Con cừu non"));
            dsTu.Add(new TuVung("loan", "Khoản vay"));
            dsTu.Add(new TuVung("frog", "Con ếch"));
            dsTu.Add(new TuVung("sheep", "Con cừu"));

            foreach (TuVung t in dsTu) {
                cboAnh.Items.Add(t.Anh); //tab Anh - Việt: danh sách từ tiếng Anh
                cboViet.Items.Add(t.Viet); //tab Việt - Anh: danh sách từ tiếng Việt
            }
            cboAnh.SelectedIndex = -1;
            cboViet.SelectedIndex = -1;
        }

        //Gõ vào combobox: dò đến từ khớp với các ký tự đã gõ và tự điền phần còn lại
        private void cbo_TextChanged(object sender, EventArgs e) {
            if (dangTuDien || dangXoaChu)
                return;

            ComboBox cbo = (ComboBox)sender;
            string daGo = cbo.Text;
            if (daGo.Length == 0)
                return;

            int vt = cbo.FindString(daGo); //tìm từ đầu tiên bắt đầu bằng chuỗi vừa gõ
            if (vt < 0)
                return; //không có từ nào khớp thì giữ nguyên chữ người dùng gõ

            string tu = cbo.Items[vt].ToString();
            dangTuDien = true;
            cbo.SelectedIndex = vt; //danh sách cuộn đến từ này
            if (cbo.Text != tu)
                cbo.Text = tu;
            cbo.SelectionStart = daGo.Length; //bôi đen phần chữ tự điền, gõ tiếp sẽ ghi đè lên
            cbo.SelectionLength = tu.Length - daGo.Length;
            dangTuDien = false;
        }

        //Nhấn Enter thì tra từ. Các phím khác: ghi nhớ có phải Backspace/Delete không.
        private void cbo_KeyDown(object sender, KeyEventArgs e) {
            ComboBox cbo = (ComboBox)sender;
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true; //tắt tiếng "bíp"
                TraTu(cbo);
                return;
            }
            dangXoaChu = (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete);
        }

        //Double click vào từ trong danh sách thì tra từ
        private void cbo_DoubleClick(object sender, EventArgs e) {
            TraTu((ComboBox)sender);
        }

        //Tra từ đang nằm trong combobox, hiện nghĩa vào textbox bên phải
        private void TraTu(ComboBox cbo) {
            string tu = cbo.Text.Trim();
            if (tu.Length == 0) {
                MessageBox.Show("Bạn chưa nhập từ cần tra!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool anhViet = (cbo == cboAnh); //true: tab Anh - Việt, false: tab Việt - Anh
            TextBox ketQua = anhViet ? txtViet : txtAnh;

            foreach (TuVung t in dsTu) {
                string goc = anhViet ? t.Anh : t.Viet;
                if (string.Equals(goc, tu, StringComparison.OrdinalIgnoreCase)) {
                    ketQua.Text = anhViet ? t.Viet : t.Anh;
                    return;
                }
            }

            ketQua.Clear();
            MessageBox.Show("Không tìm thấy từ \"" + tu + "\" trong từ điển", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void BTVN1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}