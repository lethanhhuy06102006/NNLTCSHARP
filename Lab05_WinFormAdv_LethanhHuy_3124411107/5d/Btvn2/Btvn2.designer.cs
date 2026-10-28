using System.Drawing;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
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

            //Tiêu đề
            this.lblTieuDe = new Label();
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            this.lblTieuDe.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.FromArgb(0, 0, 192);
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Location = new Point(0, 10);
            this.lblTieuDe.Size = new Size(520, 32);
            this.Controls.Add(this.lblTieuDe);

            //4 dòng nhập liệu
            TaoLabel("lblSoTK", "Số tài khoản", 20, 55);
            this.txtSoTK = TaoText("txtSoTK", 180, 55, 0);
            this.txtSoTK.KeyPress += new KeyPressEventHandler(this.txtChiSo_KeyPress);

            TaoLabel("lblTenKH", "Tên khách hàng", 20, 90);
            this.txtTenKH = TaoText("txtTenKH", 180, 90, 1);

            TaoLabel("lblDiaChi", "Địa chỉ khách hàng", 20, 125);
            this.txtDiaChi = TaoText("txtDiaChi", 180, 125, 2);

            TaoLabel("lblSoTien", "Số tiền trong tài khoản", 20, 160);
            this.txtSoTien = TaoText("txtSoTien", 180, 160, 3);
            this.txtSoTien.TextAlign = HorizontalAlignment.Right;
            this.txtSoTien.KeyPress += new KeyPressEventHandler(this.txtChiSo_KeyPress);

            //4 nút
            this.btnThem = TaoNut("btnThem", "Thêm", 180, 4);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnLuu = TaoNut("btnLuu", "Lưu", 262, 5);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXoa = TaoNut("btnXoa", "Xóa", 344, 6);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnThoat = TaoNut("btnThoat", "Thoát", 426, 7);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //ListView
            this.lvTK = new ListView();
            this.lvTK.Name = "lvTK";
            this.lvTK.View = View.Details;
            this.lvTK.FullRowSelect = true;
            this.lvTK.GridLines = true;
            this.lvTK.MultiSelect = false;
            this.lvTK.HideSelection = false;
            this.lvTK.Location = new Point(15, 240);
            this.lvTK.Size = new Size(490, 115);
            this.lvTK.TabIndex = 8;
            this.lvTK.Columns.Add("STT", 45);
            this.lvTK.Columns.Add("Số tài khoản", 105);
            this.lvTK.Columns.Add("Tên khách hàng", 130);
            this.lvTK.Columns.Add("Địa chỉ", 100);
            this.lvTK.Columns.Add("Số tiền", 95, HorizontalAlignment.Right);
            this.lvTK.SelectedIndexChanged += new System.EventHandler(this.lvTK_SelectedIndexChanged);
            this.lvTK.MouseDown += new MouseEventHandler(this.lvTK_MouseDown);
            this.Controls.Add(this.lvTK);

            //Tổng tiền
            TaoLabel("lblTongTien", "Tổng tiền", 330, 366);
            this.txtTongTien = new TextBox();
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true; //chỉ để xem, chương trình tự tính
            this.txtTongTien.TabStop = false;
            this.txtTongTien.TextAlign = HorizontalAlignment.Right;
            this.txtTongTien.Location = new Point(400, 362);
            this.txtTongTien.Size = new Size(105, 23);
            this.Controls.Add(this.txtTongTien);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai02
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(520, 400);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai02";
            this.Text = "frmBaiTap2";
            this.Load += new System.EventHandler(this.Bai02_Load);
            this.FormClosing += new FormClosingEventHandler(this.Bai02_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private Label TaoLabel(string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(150, 23);
            if (name == "lblTongTien") {
                lbl.Size = new Size(65, 23);
            }
            this.Controls.Add(lbl);
            return lbl;
        }

        private TextBox TaoText(string name, int x, int y, int tab) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(320, 23);
            txt.TabIndex = tab;
            txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.Controls.Add(txt);
            return txt;
        }

        private Button TaoNut(string name, string text, int x, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, 197);
            btn.Size = new Size(75, 27);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private Label lblTieuDe;
        private TextBox txtSoTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lvTK;
    }
}