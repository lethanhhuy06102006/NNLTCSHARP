using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    public partial class BTNC1 : Form {
        public BTNC1() {
            InitializeComponent();
        }

        //Form_Load: có sẵn vài học viên như hình
        private void BTNC1_Load(object sender, EventArgs e) {
            lstLopA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Từ" });
            lstLopB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
        }

        //Form nhập học viên mới gọi hàm này để thêm tên vào đúng lớp
        public void ThemHocVien(string hoTen, string lop) {
            if (lop == "Lớp A")
                lstLopA.Items.Add(hoTen);
            else
                lstLopB.Items.Add(hoTen);
        }

        //Menu Nhập học viên mới: mở form nhập (ShowDialog nên form chính tạm khóa)
        private void mnuNhap_Click(object sender, EventArgs e) {
            BTNC1_Nhap frm = new BTNC1_Nhap(this);
            frm.ShowDialog(this);
        }

        //Chuyển các mục đang chọn từ listbox nguon sang listbox dich
        private void ChuyenLop(ListBox nguon, ListBox dich) {
            if (nguon.SelectedIndices.Count == 0) {
                MessageBox.Show("Hãy chọn học viên cần chuyển lớp trước!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> vt = new List<int>(); //vị trí các mục đang chọn
            foreach (int i in nguon.SelectedIndices)
                vt.Add(i);

            foreach (int i in vt)
                dich.Items.Add(nguon.Items[i]); //thêm sang lớp kia
            for (int i = vt.Count - 1; i >= 0; i--)
                nguon.Items.RemoveAt(vt[i]); //xóa từ vị trí lớn nhất để không bị lệch
        }

        //Menu Chuyển sang lớp B: lấy từ Lớp A
        private void mnuSangB_Click(object sender, EventArgs e) {
            ChuyenLop(lstLopA, lstLopB);
        }

        //Menu Chuyển sang lớp A: lấy từ Lớp B
        private void mnuSangA_Click(object sender, EventArgs e) {
            ChuyenLop(lstLopB, lstLopA);
        }

        //Xóa các mục đang chọn trong listbox lst (xóa từ cuối lên đầu)
        private void XoaDangChon(ListBox lst) {
            for (int i = lst.Items.Count - 1; i >= 0; i--) {
                if (lst.GetSelected(i))
                    lst.Items.RemoveAt(i);
            }
        }

        //Menu Xóa học viên: xóa tất cả học viên đang chọn ở cả Lớp A và Lớp B
        private void mnuXoa_Click(object sender, EventArgs e) {
            if (lstLopA.SelectedIndices.Count == 0 && lstLopB.SelectedIndices.Count == 0) {
                MessageBox.Show("Hãy chọn học viên cần xóa trước!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            XoaDangChon(lstLopA);
            XoaDangChon(lstLopB);
        }

        //Menu Kết thúc: đóng form, việc hỏi xác nhận nằm ở FormClosing
        private void mnuKetThuc_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Hỏi người dùng có muốn dừng chương trình không
        private void BTNC1_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return; //form main đang đóng thì để form main hỏi một lần
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Kết thúc",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}