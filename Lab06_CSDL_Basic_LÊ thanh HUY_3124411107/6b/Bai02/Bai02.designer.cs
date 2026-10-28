using System.Drawing;
using System.Windows.Forms;

namespace DiemCombo {
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

            //Sinh viên: combobox chứa mã sinh viên lấy từ bảng SinhVien
            TaoLabel("lblSinhVien", "Sinh viên", 25, 19);
            this.cboSinhVien = TaoCombo("cboSinhVien", 15, 0);

            //Môn học: combobox chứa mã môn học lấy từ bảng MonHoc
            TaoLabel("lblMonHoc", "Môn học", 25, 51);
            this.cboMonHoc = TaoCombo("cboMonHoc", 47, 1);

            //Điểm
            TaoLabel("lblDiem", "Điểm", 25, 83);
            this.txtDiem = new TextBox();
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Location = new Point(95, 79);
            this.txtDiem.Size = new Size(190, 23);
            this.txtDiem.MaxLength = 5;
            this.txtDiem.TabIndex = 2;
            this.txtDiem.KeyPress += new KeyPressEventHandler(this.txtDiem_KeyPress);
            this.txtDiem.TextChanged += new System.EventHandler(this.txtDiem_TextChanged);
            this.Controls.Add(this.txtDiem);

            //3 nút
            this.btnThem = TaoNut("btnThem", "&Thêm", 35, 3);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa = TaoNut("btnXoa", "&Xóa", 122, 4);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua = TaoNut("btnSua", "&Sửa", 209, 5);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai02
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(310, 170);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai02";
            this.Text = "frmDiem_combo";
            this.Load += new System.EventHandler(this.Bai02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private Label TaoLabel(string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            this.Controls.Add(lbl);
            return lbl;
        }

        private ComboBox TaoCombo(string name, int y, int tab) {
            ComboBox cbo = new ComboBox();
            cbo.Name = name;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn mã có sẵn, không gõ
            cbo.Location = new Point(95, y);
            cbo.Size = new Size(190, 23);
            cbo.TabIndex = tab;
            cbo.SelectedIndexChanged += new System.EventHandler(this.cbo_SelectedIndexChanged);
            this.Controls.Add(cbo);
            return cbo;
        }

        private Button TaoNut(string name, string text, int x, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, 122);
            btn.Size = new Size(75, 30);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private ComboBox cboSinhVien, cboMonHoc;
        private TextBox txtDiem;
        private Button btnThem, btnXoa, btnSua;
    }
}