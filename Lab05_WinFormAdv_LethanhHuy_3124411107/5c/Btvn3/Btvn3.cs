using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace DanhBa {
    public partial class BTVN3 : Form {
        public BTVN3() {
            InitializeComponent();
        }

        //Form_Load: treeView chứa tất cả các ký tự từ A đến Z
        private void BTVN3_Load(object sender, EventArgs e) {
            for (char c = 'A'; c <= 'Z'; c++)
                tvDanhBa.Nodes.Add(c.ToString(), c.ToString()); //tham số đầu là key để tìm node theo chữ cái
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về textbox bị lỗi
        private void BaoLoi(TextBox txt, string loi) {
            errorProvider1.SetError(txt, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt.Focus();
            txt.SelectAll();
        }

        //Lấy chữ cái đầu (A - Z) của chuỗi, đã bỏ dấu tiếng Việt: "Ánh" -> A, "Đức" -> D
        //Nếu ký tự đầu không phải chữ cái thì trả về dấu cách
        private char LayChuCaiDau(string s) {
            s = s.Trim().Replace('đ', 'd').Replace('Đ', 'D'); //đ không tách dấu được nên đổi riêng
            string tach = s.Normalize(NormalizationForm.FormD); //tách chữ và dấu: "ì" thành "i" + dấu huyền
            foreach (char c in tach) {
                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                    continue; //bỏ qua các dấu
                char hoa = char.ToUpperInvariant(c);
                if (hoa >= 'A' && hoa <= 'Z')
                    return hoa;
                return ' ';
            }
            return ' ';
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txt_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError((TextBox)sender, "");
        }

        //Nút Add: đưa người mới vào node tương ứng với chữ cái đầu của tên
        private void btnAdd_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (firstName.Length == 0) {
                BaoLoi(txtFirstName, "First Name không được để trống");
                return;
            }
            if (lastName.Length == 0) {
                BaoLoi(txtLastName, "Last Name không được để trống");
                return;
            }

            char chu = LayChuCaiDau(lastName); //xếp theo chữ cái đầu của tên (Last Name)
            if (chu == ' ') {
                BaoLoi(txtLastName, "Last Name phải bắt đầu bằng một chữ cái (A - Z)");
                return;
            }

            TreeNode nodeChu = tvDanhBa.Nodes[chu.ToString()]; //node chữ cái tương ứng
            TreeNode nguoi = nodeChu.Nodes.Add(lastName + ", " + firstName); //vd: "Bình, Ngô Thanh"
            nodeChu.Expand();
            tvDanhBa.SelectedNode = nguoi;

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        //Nút Exit
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi thoát
        private void BTVN3_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}