using System.Drawing;
using System.Windows.Forms;

namespace UocSo {
    partial class Bai01 {
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

            //Nhóm Nhập Số: textbox, nút Cập nhật, combobox
            this.grpNhap = new GroupBox();
            this.grpNhap.Name = "grpNhap";
            this.grpNhap.Text = "Nhập Số";
            this.grpNhap.Location = new Point(15, 10);
            this.grpNhap.Size = new Size(195, 125);
            this.Controls.Add(this.grpNhap);

            this.txtSo = new TextBox();
            this.txtSo.Name = "txtSo";
            this.txtSo.Location = new Point(15, 30);
            this.txtSo.Size = new Size(100, 23);
            this.txtSo.TabIndex = 0;
            this.txtSo.KeyPress += new KeyPressEventHandler(this.txtSo_KeyPress);
            this.txtSo.TextChanged += new System.EventHandler(this.txtSo_TextChanged);
            this.grpNhap.Controls.Add(this.txtSo);

            this.btnCapNhat = TaoNut(this.grpNhap, "btnCapNhat", "&Cập nhật", 122, 28, 62, 26, 1);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.cboSo = new ComboBox();
            this.cboSo.Name = "cboSo";
            this.cboSo.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn, không gõ vào combobox
            this.cboSo.Location = new Point(15, 72);
            this.cboSo.Size = new Size(169, 23);
            this.cboSo.TabIndex = 2;
            this.cboSo.SelectedIndexChanged += new System.EventHandler(this.cboSo_SelectedIndexChanged);
            this.grpNhap.Controls.Add(this.cboSo);

            //Nhóm Danh sách các ước số: listbox
            this.grpDanhSach = new GroupBox();
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Text = "Danh sách các ước số";
            this.grpDanhSach.Location = new Point(225, 10);
            this.grpDanhSach.Size = new Size(240, 125);
            this.Controls.Add(this.grpDanhSach);

            this.lstUocSo = new ListBox();
            this.lstUocSo.Name = "lstUocSo";
            this.lstUocSo.Location = new Point(15, 22);
            this.lstUocSo.Size = new Size(210, 92);
            this.lstUocSo.TabStop = false;
            this.grpDanhSach.Controls.Add(this.lstUocSo);

            //Các nút tính (mỗi nút có phím tắt Alt + chữ có gạch chân)
            this.btnTong = TaoNut(this, "btnTong", "&Tổng các ước số", 225, 150, 240, 28, 3);
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);

            this.btnChan = TaoNut(this, "btnChan", "Số lượng các ước số c&hẵn", 225, 185, 240, 28, 4);
            this.btnChan.Click += new System.EventHandler(this.btnChan_Click);

            this.btnNguyenTo = TaoNut(this, "btnNguyenTo", "Số lượng các ước số &nguyên tố", 225, 220, 240, 28, 5);
            this.btnNguyenTo.Click += new System.EventHandler(this.btnNguyenTo_Click);

            this.btnThoat = TaoNut(this, "btnThoat", "Th&oát", 115, 220, 95, 28, 6);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai01
            this.AcceptButton = this.btnCapNhat; //nhấn Enter = bấm Cập nhật
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(480, 262);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai01";
            this.Text = "Combobox";
            this.FormClosing += new FormClosingEventHandler(this.Bai01_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Hàm phụ tạo nút
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
        private GroupBox grpNhap, grpDanhSach;
        private TextBox txtSo;
        private ComboBox cboSo;
        private ListBox lstUocSo;
        private Button btnCapNhat, btnTong, btnChan, btnNguyenTo, btnThoat;
    }
}