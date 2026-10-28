using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    public partial class Bai01 : Form {
        public Bai01() {
            InitializeComponent();
        }

        //Form_Load: thêm dữ liệu vào combobox dân tộc
        private void Bai01_Load(object sender, EventArgs e) {
            cboDanToc.Items.AddRange(new object[] { "Kinh", "Tày", "Thái", "Mường", "Hoa", "Khmer", "Nùng", "H'Mông", "Dao", "Khác" });
            cboDanToc.SelectedIndex = 0; //mặc định là Kinh
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txt_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError((TextBox)sender, "");
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về textbox bị lỗi
        private void BaoLoi(TextBox txt, string loi) {
            errorProvider1.SetError(txt, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt.Focus();
            txt.SelectAll();
        }

        //Kiểm tra họ tên và mã sinh viên đã nhập chưa, true nếu hợp lệ
        private bool KiemTraNhap() {
            errorProvider1.Clear();
            if (txtHoTen.Text.Trim().Length == 0) {
                BaoLoi(txtHoTen, "Họ và tên không được để trống");
                return false;
            }
            if (txtMaSV.Text.Trim().Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return false;
            }
            return true;
        }

        //Kiểm tra mã sinh viên đã có trong ListView chưa (không phân biệt hoa thường)
        private bool TonTaiMa(string ma) {
            foreach (ListViewItem dong in lvSV.Items) {
                if (string.Equals(dong.SubItems[1].Text, ma, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        //Ghép các ngoại ngữ được tick thành 1 chuỗi: "Anh, Pháp"
        private string LayNgoaiNgu() {
            List<string> ds = new List<string>();
            if (chkAnh.Checked)
                ds.Add("Anh");
            if (chkPhap.Checked)
                ds.Add("Pháp");
            if (chkHoa.Checked)
                ds.Add("Hoa");
            return string.Join(", ", ds);
        }

        //Đưa form về trạng thái nhập mới
        private void LamMoi() {
            errorProvider1.Clear();
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false; //nhập mới thì cho gõ mã
            radNam.Checked = true;
            chkAnh.Checked = true;
            chkPhap.Checked = false;
            chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        //Nút Thêm: đưa sinh viên mới vào ListView, không cho trùng mã
        private void btnThem_Click(object sender, EventArgs e) {
            if (!KiemTraNhap())
                return;

            string ma = txtMaSV.Text.Trim();
            if (TonTaiMa(ma)) {
                BaoLoi(txtMaSV, "Mã sinh viên \"" + ma + "\" đã tồn tại, không được thêm trùng");
                return;
            }

            ListViewItem dong = new ListViewItem(txtHoTen.Text.Trim()); //cột 0: họ tên
            dong.SubItems.Add(ma); //cột 1: mã sinh viên
            dong.SubItems.Add(radNam.Checked ? "Nam" : "Nữ"); //cột 2: giới tính
            dong.SubItems.Add(LayNgoaiNgu()); //cột 3: ngoại ngữ
            dong.SubItems.Add(cboDanToc.Text); //cột 4: dân tộc
            lvSV.Items.Add(dong);

            lvSV.SelectedItems.Clear();
            LamMoi();
        }

        //Chọn 1 dòng trong ListView thì hiện thông tin lên các control
        private void lvSV_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvSV.SelectedItems.Count == 0) {
                LamMoi(); //bỏ chọn thì về trạng thái nhập mới
                return;
            }

            ListViewItem dong = lvSV.SelectedItems[0];
            errorProvider1.Clear();
            txtHoTen.Text = dong.SubItems[0].Text;
            txtMaSV.Text = dong.SubItems[1].Text;
            txtMaSV.ReadOnly = true; //không cho sửa mã sinh viên
            radNam.Checked = (dong.SubItems[2].Text == "Nam");
            radNu.Checked = !radNam.Checked;

            string ngoaiNgu = dong.SubItems[3].Text;
            chkAnh.Checked = ngoaiNgu.Contains("Anh");
            chkPhap.Checked = ngoaiNgu.Contains("Pháp");
            chkHoa.Checked = ngoaiNgu.Contains("Hoa");
            cboDanToc.SelectedItem = dong.SubItems[4].Text;
        }

        //Bấm vào vùng trống của ListView thì bỏ chọn để quay lại nhập mới
        private void lvSV_MouseDown(object sender, MouseEventArgs e) {
            if (lvSV.GetItemAt(e.X, e.Y) == null)
                lvSV.SelectedItems.Clear();
        }

        //Nút Sửa: cập nhật dòng đang chọn (trừ mã sinh viên)
        private void btnSua_Click(object sender, EventArgs e) {
            if (lvSV.SelectedItems.Count == 0) {
                MessageBox.Show("Hãy chọn sinh viên cần sửa trong danh sách!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraNhap())
                return;

            ListViewItem dong = lvSV.SelectedItems[0];
            dong.SubItems[0].Text = txtHoTen.Text.Trim();
            //SubItems[1] là mã sinh viên: giữ nguyên
            dong.SubItems[2].Text = radNam.Checked ? "Nam" : "Nữ";
            dong.SubItems[3].Text = LayNgoaiNgu();
            dong.SubItems[4].Text = cboDanToc.Text;

            lvSV.SelectedItems.Clear();
            LamMoi();
        }

        //Nút Xóa (và mục Xóa trong menu chuột phải): xóa dòng đang chọn
        private void btnXoa_Click(object sender, EventArgs e) {
            if (lvSV.SelectedItems.Count == 0) {
                MessageBox.Show("Hãy chọn sinh viên cần xóa trong danh sách!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem dong = lvSV.SelectedItems[0];
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên \"" + dong.SubItems[0].Text + "\"?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            lvSV.Items.Remove(dong); //ListView tự bỏ chọn, SelectedIndexChanged sẽ làm mới form
        }

        //Chỉ hiện menu chuột phải khi đang có dòng được chọn
        private void ctmLV_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = (lvSV.SelectedItems.Count == 0);
        }

        //Hỏi xác nhận trước khi đóng form
        private void Bai01_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return; //form main đang đóng thì để form main hỏi một lần
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}