using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    public partial class FormChinh : Form {
        public FormChinh() {
            InitializeComponent();
        }

        //Mở form con T bên trong form main. Form đó đang mở rồi thì chỉ đưa lên trước.
        private void MoForm<T>() where T : Form, new() {
            foreach (Form con in this.MdiChildren) {
                if (con is T) {
                    con.Activate();
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = this; //đặt form main làm cha
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(0, 0);
            frm.Show();
        }

        //Menu Bài 1: quản lý sinh viên bằng ListView
        private void mnuBai1_Click(object sender, EventArgs e) {
            MoForm<Bai01>();
        }

        //Menu Bài 2: quản lý thông tin tài khoản
        private void mnuBai2_Click(object sender, EventArgs e) {
            MoForm<Bai02>();
        }

        //Menu Bài nâng cao: quản lý học viên
        private void mnuNangCao_Click(object sender, EventArgs e) {
            MoForm<BTNC1>();
        }

        //Hỏi xác nhận trước khi đóng chương trình
        private void FormChinh_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}