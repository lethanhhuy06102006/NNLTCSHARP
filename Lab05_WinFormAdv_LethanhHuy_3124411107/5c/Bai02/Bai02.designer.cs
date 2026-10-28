using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien {
    partial class Bai02 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //TreeView bên trái, có sẵn node gốc "Danh sách lớp"
            this.tvLop = new TreeView();
            this.tvLop.Name = "tvLop";
            this.tvLop.Location = new Point(12, 12);
            this.tvLop.Size = new Size(200, 315);
            this.tvLop.Nodes.Add("Danh sách lớp");
            this.tvLop.AfterSelect += new TreeViewEventHandler(this.tvLop_AfterSelect);
            this.Controls.Add(this.tvLop);

            //Chọn lớp
            TaoLabel(this, "lblChonLop", "Chọn Lớp", 235, 18);
            this.cboLop = new ComboBox();
            this.cboLop.Name = "cboLop";
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLop.Location = new Point(305, 14);
            this.cboLop.Size = new Size(245, 23);
            this.cboLop.TabIndex = 0;
            this.Controls.Add(this.cboLop);

            //Nhóm Thông tin sinh viên
            this.grpSinhVien = new GroupBox();
            this.grpSinhVien.Name = "grpSinhVien";
            this.grpSinhVien.Text = "Thông tin sinh viên";
            this.grpSinhVien.Location = new Point(225, 45);
            this.grpSinhVien.Size = new Size(330, 175);
            this.Controls.Add(this.grpSinhVien);

            TaoLabel(this.grpSinhVien, "lblMaSV", "Mã SV:", 20, 32);
            this.txtMaSV = TaoText(this.grpSinhVien, "txtMaSV", 90, 29, 225, 1);
            TaoLabel(this.grpSinhVien, "lblHoTen", "Họ Tên:", 20, 67);
            this.txtHoTen = TaoText(this.grpSinhVien, "txtHoTen", 90, 64, 225, 2);
            TaoLabel(this.grpSinhVien, "lblDiaChi", "Địa Chỉ", 20, 102);
            this.txtDiaChi = TaoText(this.grpSinhVien, "txtDiaChi", 90, 99, 225, 3);

            this.btnCapNhat = TaoNut(this.grpSinhVien, "btnCapNhat", "Cập Nhật", 90, 135, 110, 28, 4);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.btnXoa = TaoNut(this.grpSinhVien, "btnXoa", "Xóa", 215, 135, 100, 28, 5);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            //Checkbox Thêm lớp
            this.chkThemLop = new CheckBox();
            this.chkThemLop.Name = "chkThemLop";
            this.chkThemLop.Text = "Thêm lớp";
            this.chkThemLop.AutoSize = true;
            this.chkThemLop.Location = new Point(225, 232);
            this.chkThemLop.TabIndex = 6;
            this.chkThemLop.CheckedChanged += new System.EventHandler(this.chkThemLop_CheckedChanged);
            this.Controls.Add(this.chkThemLop);

            //Nhóm Thông tin lớp (ẩn khi chưa check Thêm lớp)
            this.grpThongTinLop = new GroupBox();
            this.grpThongTinLop.Name = "grpThongTinLop";
            this.grpThongTinLop.Text = "Thông tin lớp";
            this.grpThongTinLop.Location = new Point(225, 255);
            this.grpThongTinLop.Size = new Size(330, 70);
            this.Controls.Add(this.grpThongTinLop);

            TaoLabel(this.grpThongTinLop, "lblTenLop", "Tên lớp", 20, 32);
            this.txtTenLop = TaoText(this.grpThongTinLop, "txtTenLop", 90, 29, 120, 7);
            this.btnThemLop = TaoNut(this.grpThongTinLop, "btnThemLop", "Thêm lớp", 225, 27, 90, 26, 8);
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai02
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(570, 340);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai02";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Bai02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private Label TaoLabel(Control cha, string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            cha.Controls.Add(lbl);
            return lbl;
        }

        private TextBox TaoText(Control cha, string name, int x, int y, int w, int tab) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(w, 23);
            txt.TabIndex = tab;
            cha.Controls.Add(txt);
            return txt;
        }

        private Button TaoNut(Control cha, string name, string text, int x, int y, int w, int h, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.TabIndex = tab;
            cha.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private TreeView tvLop;
        private ComboBox cboLop;
        private GroupBox grpSinhVien, grpThongTinLop;
        private TextBox txtMaSV, txtHoTen, txtDiaChi, txtTenLop;
        private Button btnCapNhat, btnXoa, btnThemLop;
        private CheckBox chkThemLop;
    }
}