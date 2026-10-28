using System.Drawing;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    partial class BTNC1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //Menu: Cập nhật (có 4 mục con) và Kết thúc
            this.menuStrip1 = new MenuStrip();
            this.mnuCapNhat = new ToolStripMenuItem("&Cập nhật");
            this.mnuNhap = new ToolStripMenuItem("&Nhập học viên mới");
            this.mnuSangB = new ToolStripMenuItem("Chuyển sang lớp &B");
            this.mnuSangA = new ToolStripMenuItem("Chuyển sang lớp &A");
            this.mnuXoa = new ToolStripMenuItem("&Xóa học viên");
            this.mnuKetThuc = new ToolStripMenuItem("&Kết thúc");

            this.mnuNhap.Click += new System.EventHandler(this.mnuNhap_Click);
            this.mnuSangB.Click += new System.EventHandler(this.mnuSangB_Click);
            this.mnuSangA.Click += new System.EventHandler(this.mnuSangA_Click);
            this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);
            this.mnuKetThuc.Click += new System.EventHandler(this.mnuKetThuc_Click);

            this.mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] { this.mnuNhap, this.mnuSangB, this.mnuSangA, this.mnuXoa });
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuCapNhat, this.mnuKetThuc });
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.AllowMerge = false; //giữ menu trong form con, không gộp lên menu form main
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);

            //Hai nhóm Lớp A, Lớp B, mỗi nhóm có 1 listbox cho chọn nhiều mục
            this.lstLopA = TaoNhom("Lớp A", "lstLopA", 15);
            this.lstLopB = TaoNhom("Lớp B", "lstLopB", 165);

            //BTNC1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(310, 225);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTNC1";
            this.Text = "Quản lý học viên";
            this.Load += new System.EventHandler(this.BTNC1_Load);
            this.FormClosing += new FormClosingEventHandler(this.BTNC1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Tạo 1 GroupBox chứa 1 ListBox, trả về ListBox
        private ListBox TaoNhom(string tieuDe, string tenListBox, int x) {
            GroupBox grp = new GroupBox();
            grp.Name = "grp" + tenListBox;
            grp.Text = tieuDe;
            grp.Location = new Point(x, 35);
            grp.Size = new Size(130, 170);
            this.Controls.Add(grp);

            ListBox lst = new ListBox();
            lst.Name = tenListBox;
            lst.SelectionMode = SelectionMode.MultiExtended; //cho chọn nhiều mục (Ctrl, Shift)
            lst.IntegralHeight = false;
            lst.Location = new Point(10, 22);
            lst.Size = new Size(110, 135);
            grp.Controls.Add(lst);
            return lst;
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCapNhat, mnuNhap, mnuSangB, mnuSangA, mnuXoa, mnuKetThuc;
        private ListBox lstLopA, lstLopB;
    }
}