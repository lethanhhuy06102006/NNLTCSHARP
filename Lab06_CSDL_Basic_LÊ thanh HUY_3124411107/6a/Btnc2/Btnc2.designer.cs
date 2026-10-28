using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDiem {
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

            //3 dòng nhập liệu
            TaoLabel("lblMaSV", "Mã sv", 25, 19);
            this.txtMaSV = TaoText("txtMaSV", 85, 15, 10, 0);

            TaoLabel("lblMaMH", "Mã mh", 25, 51);
            this.txtMaMH = TaoText("txtMaMH", 85, 47, 10, 1);

            TaoLabel("lblDiem", "Điểm", 25, 83);
            this.txtDiem = TaoText("txtDiem", 85, 79, 5, 2);
            this.txtDiem.KeyPress += new KeyPressEventHandler(this.txtDiem_KeyPress);

            //3 nút
            this.btnThem = TaoNut("btnThem", "&Thêm", 25, 3);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa = TaoNut("btnXoa", "&Xóa", 112, 4);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua = TaoNut("btnSua", "&Sửa", 199, 5);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai02
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 170);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai02";
            this.Text = "Quản lý Điểm";
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
            btn.Location = new Point(x, 122);
            btn.Size = new Size(75, 30);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private TextBox txtMaSV, txtMaMH, txtDiem;
        private Button btnThem, btnXoa, btnSua;
    }
}