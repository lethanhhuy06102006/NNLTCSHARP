using System.Drawing;
using System.Windows.Forms;

namespace SinhVienCombo {
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

            //Lớp: combobox chứa mã lớp lấy từ bảng Lop
            TaoLabel("lblLop", "Lớp", 25, 19);
            this.cboLop = new ComboBox();
            this.cboLop.Name = "cboLop";
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn, không gõ mã lớp lạ
            this.cboLop.Location = new Point(95, 15);
            this.cboLop.Size = new Size(190, 23);
            this.cboLop.TabIndex = 0;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            this.Controls.Add(this.cboLop);

            //Mã sv, Họ tên
            TaoLabel("lblMaSV", "Mã sv", 25, 51);
            this.txtMaSV = TaoText("txtMaSV", 95, 47, 10, 1);

            TaoLabel("lblHoTen", "Họ tên", 25, 83);
            this.txtHoTen = TaoText("txtHoTen", 95, 79, 100, 2);

            //Ngày sinh
            TaoLabel("lblNgaySinh", "Ngày sinh", 25, 115);
            this.txtNgaySinh = new MaskedTextBox();
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Mask = "00/00/0000"; //khung nhập dd/MM/yyyy, chỉ cho gõ số
            this.txtNgaySinh.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Text chỉ trả về các chữ số: 01022005
            this.txtNgaySinh.Location = new Point(95, 111);
            this.txtNgaySinh.Size = new Size(190, 23);
            this.txtNgaySinh.TabIndex = 3;
            this.txtNgaySinh.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.Controls.Add(this.txtNgaySinh);

            //3 nút
            this.btnThem = TaoNut("btnThem", "&Thêm", 35, 4);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa = TaoNut("btnXoa", "&Xóa", 122, 5);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua = TaoNut("btnSua", "&Sửa", 209, 6);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai01
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(310, 205);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai01";
            this.Text = "frmSinhvien_Combo";
            this.Load += new System.EventHandler(this.Bai01_Load);
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

        private TextBox TaoText(string name, int x, int y, int maxLength, int tab) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(190, 23);
            txt.MaxLength = maxLength; //khớp độ dài cột trong bảng
            txt.TabIndex = tab;
            txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.Controls.Add(txt);
            return txt;
        }

        private Button TaoNut(string name, string text, int x, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, 155);
            btn.Size = new Size(75, 30);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen;
        private MaskedTextBox txtNgaySinh;
        private Button btnThem, btnXoa, btnSua;
    }
}