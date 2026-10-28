using System.Drawing;
using System.Windows.Forms;

namespace DanhSachLop {
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

            //Nút Hiển thị dữ liệu
            this.btnHienThi = new Button();
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Text = "&Hiển thị dữ liệu";
            this.btnHienThi.Location = new Point(15, 12);
            this.btnHienThi.Size = new Size(110, 26);
            this.btnHienThi.TabIndex = 0;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            this.Controls.Add(this.btnHienThi);

            //ListView hiện danh sách lớp
            this.lvLop = new ListView();
            this.lvLop.Name = "lvLop";
            this.lvLop.View = View.Details; //hiện dạng bảng có tiêu đề cột
            this.lvLop.FullRowSelect = true;
            this.lvLop.GridLines = true;
            this.lvLop.Location = new Point(15, 48);
            this.lvLop.Size = new Size(530, 220);
            this.lvLop.TabIndex = 1;
            this.lvLop.Columns.Add("STT", 45);
            this.lvLop.Columns.Add("Mã lớp", 110);
            this.lvLop.Columns.Add("Tên lớp", 240);
            this.lvLop.Columns.Add("Mã khoa", 110);
            this.Controls.Add(this.lvLop);

            //Nút Thoát
            this.btnThoat = new Button();
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Location = new Point(445, 282);
            this.btnThoat.Size = new Size(100, 30);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.Controls.Add(this.btnThoat);

            //BTNC1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(560, 325);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTNC1";
            this.Text = "Danh sách Lớp";
            this.ResumeLayout(false);
        }

        private Button btnHienThi, btnThoat;
        private ListView lvLop;
    }
}