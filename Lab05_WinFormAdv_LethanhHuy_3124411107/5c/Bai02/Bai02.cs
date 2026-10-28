using System;
using System.Windows.Forms;

namespace QuanLySinhVien {
    public partial class Bai02 : Form {
        public Bai02() {
            InitializeComponent();
        }

        //Form_Load: treeView và combobox có sẵn vài lớp, checkbox Thêm lớp = false (ẩn groupbox)
        private void Bai02_Load(object sender, EventArgs e) {
            TreeNode goc = tvLop.Nodes[0]; //node "Danh sách lớp"
            string[] dsLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (string lop in dsLop) {
                goc.Nodes.Add(lop);
                cboLop.Items.Add(lop);
            }
            goc.Expand();
            cboLop.SelectedIndex = 0;

            chkThemLop.Checked = false;
            grpThongTinLop.Visible = false;
        }

        //Checkbox Thêm lớp: true thì hiện groupbox Thông tin lớp, false thì ẩn đi
        private void chkThemLop_CheckedChanged(object sender, EventArgs e) {
            grpThongTinLop.Visible = chkThemLop.Checked;
            if (chkThemLop.Checked)
                txtTenLop.Focus();
            else {
                txtTenLop.Clear();
                errorProvider1.SetError(txtTenLop, "");
            }
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về control bị lỗi
        private void BaoLoi(Control ctr, string loi) {
            errorProvider1.SetError(ctr, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ctr.Focus();
        }

        //Tìm node lớp theo tên (không phân biệt hoa thường), không có thì trả về null
        private TreeNode TimNodeLop(string ten) {
            foreach (TreeNode lop in tvLop.Nodes[0].Nodes)
                if (string.Equals(lop.Text, ten, StringComparison.OrdinalIgnoreCase))
                    return lop;
            return null;
        }

        //Kiểm tra mã sinh viên đã tồn tại ở bất kỳ lớp nào chưa
        private bool TonTaiMaSV(string ma) {
            foreach (TreeNode lop in tvLop.Nodes[0].Nodes)
                foreach (TreeNode sv in lop.Nodes)
                    if (string.Equals(sv.Tag as string, ma, StringComparison.OrdinalIgnoreCase))
                        return true;
            return false;
        }

        //Nút Thêm lớp: thêm vào treeView và combobox
        private void btnThemLop_Click(object sender, EventArgs e) {
            errorProvider1.SetError(txtTenLop, "");
            string ten = txtTenLop.Text.Trim();

            if (ten.Length == 0) {
                BaoLoi(txtTenLop, "Tên lớp không được để trống");
                return;
            }
            if (TimNodeLop(ten) != null) {
                BaoLoi(txtTenLop, "Lớp " + ten + " đã tồn tại");
                txtTenLop.SelectAll();
                return;
            }

            tvLop.Nodes[0].Nodes.Add(ten); //thêm vào treeView
            cboLop.Items.Add(ten); //đồng thời thêm vào combobox
            cboLop.SelectedItem = ten; //chọn luôn lớp vừa thêm
            tvLop.Nodes[0].Expand();
            txtTenLop.Clear();
            txtTenLop.Focus();
        }

        //Nút Cập Nhật: thêm sinh viên vào lớp đang chọn trên combobox
        private void btnCapNhat_Click(object sender, EventArgs e) {
            errorProvider1.Clear();

            string ma = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            //Kiểm tra thông tin nhập
            if (cboLop.SelectedItem == null) {
                BaoLoi(cboLop, "Hãy chọn lớp cho sinh viên");
                return;
            }
            if (ma.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return;
            }
            if (hoTen.Length == 0) {
                BaoLoi(txtHoTen, "Họ tên không được để trống");
                return;
            }
            if (diaChi.Length == 0) {
                BaoLoi(txtDiaChi, "Địa chỉ không được để trống");
                return;
            }
            if (TonTaiMaSV(ma)) {
                BaoLoi(txtMaSV, "Mã sinh viên " + ma + " đã tồn tại");
                txtMaSV.SelectAll();
                return;
            }

            //Thêm node sinh viên "MãSV, Họ tên", bên trong có node con là địa chỉ
            TreeNode lop = TimNodeLop(cboLop.Text);
            TreeNode sv = new TreeNode(ma + ", " + hoTen);
            sv.Tag = ma; //lưu mã sinh viên để kiểm tra trùng
            sv.Nodes.Add(diaChi);
            lop.Nodes.Add(sv);
            lop.Expand();

            XoaThongTinSV();
        }

        //Node sinh viên nằm ở cấp 2: Danh sách lớp (0) > lớp (1) > sinh viên (2) > địa chỉ (3)
        private bool LaNodeSinhVien(TreeNode n) {
            return n != null && n.Level == 2 && n.Tag is string;
        }

        //Click chọn một node sinh viên thì hiện thông tin của sinh viên đó lên các textbox
        private void tvLop_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode n = e.Node;
            if (!LaNodeSinhVien(n))
                return;

            errorProvider1.Clear();
            string ma = (string)n.Tag;
            txtMaSV.Text = ma;
            txtHoTen.Text = n.Text.Substring(ma.Length + 2); //bỏ phần "MãSV, " ở đầu
            txtDiaChi.Text = n.Nodes.Count > 0 ? n.Nodes[0].Text : "";
            cboLop.SelectedItem = n.Parent.Text; //combobox hiện lớp của sinh viên
        }

        //Nút Xóa: chỉ cho xóa node sinh viên đang chọn trên TreeView, có xác nhận trước khi xóa
        private void btnXoa_Click(object sender, EventArgs e) {
            TreeNode n = tvLop.SelectedNode;
            if (!LaNodeSinhVien(n)) {
                MessageBox.Show("Chỉ được xóa sinh viên. Hãy chọn một sinh viên trên TreeView!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa sinh viên " + n.Text + " ?", "Xóa sinh viên",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) {
                n.Remove();
                XoaThongTinSV(); //xóa sau cùng vì lúc Remove, TreeView tự chọn node khác
                errorProvider1.Clear();
            }
        }

        private void XoaThongTinSV() {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtMaSV.Focus();
        }
    }
}