using System.Drawing;
using System.Windows.Forms;

namespace ListBoxXuLy {
    partial class BTVN2 {
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

            //Tiêu đề (label có viền)
            this.lblTieuDe = new Label();
            this.lblTieuDe.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.DarkOrange;
            this.lblTieuDe.BorderStyle = BorderStyle.FixedSingle;
            this.lblTieuDe.Location = new Point(12, 10);
            this.lblTieuDe.Size = new Size(330, 36);
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "LISTBOX";
            this.Controls.Add(this.lblTieuDe);

            //Cột bên trái: nhập số và listbox
            TaoLabel("lblListbox", "Listbox", 12, 52);
            this.txtSo = new TextBox();
            this.txtSo.Name = "txtSo";
            this.txtSo.Location = new Point(12, 70);
            this.txtSo.Size = new Size(150, 23);
            this.txtSo.TabIndex = 0;
            this.txtSo.KeyPress += new KeyPressEventHandler(this.txtSo_KeyPress);
            this.txtSo.TextChanged += new System.EventHandler(this.txtSo_TextChanged);
            this.Controls.Add(this.txtSo);

            this.btnNhap = TaoNut("btnNhap", "&Nhập", 12, 100, 150, 32, 1);
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);

            //ListBox cho chọn nhiều phần tử (Ctrl, Shift)
            this.lstSo = new ListBox();
            this.lstSo.Name = "lstSo";
            this.lstSo.SelectionMode = SelectionMode.MultiExtended;
            this.lstSo.IntegralHeight = false;
            this.lstSo.Location = new Point(12, 140);
            this.lstSo.Size = new Size(150, 150);
            this.lstSo.TabIndex = 2;
            this.Controls.Add(this.lstSo);

            //Cột bên phải: Xử lý Listbox
            TaoLabel("lblXuLy", "Xử lý Listbox", 175, 52);
            this.btnTong = TaoNut("btnTong", "Tổng các phần tử trong List", 175, 70, 167, 28, 3);
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);

            this.btnXoaDauCuoi = TaoNut("btnXoaDauCuoi", "Xóa Phần tử đầu và cuối", 175, 102, 167, 28, 4);
            this.btnXoaDauCuoi.Click += new System.EventHandler(this.btnXoaDauCuoi_Click);

            this.btnXoaChon = TaoNut("btnXoaChon", "Xóa Phần tử đang chọn", 175, 134, 167, 28, 5);
            this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);

            this.btnTang2 = TaoNut("btnTang2", "Tăng mỗi phần tử lên 2", 175, 166, 167, 28, 6);
            this.btnTang2.Click += new System.EventHandler(this.btnTang2_Click);

            this.btnBinhPhuong = TaoNut("btnBinhPhuong", "Thay bằng bình phương", 175, 198, 167, 28, 7);
            this.btnBinhPhuong.Click += new System.EventHandler(this.btnBinhPhuong_Click);

            this.btnChonChan = TaoNut("btnChonChan", "Chọn số chẵn", 175, 230, 167, 28, 8);
            this.btnChonChan.Click += new System.EventHandler(this.btnChonChan_Click);

            this.btnChonLe = TaoNut("btnChonLe", "Chọn số lẻ", 175, 262, 167, 28, 9);
            this.btnChonLe.Click += new System.EventHandler(this.btnChonLe_Click);

            //Nút KẾT THÚC
            this.btnKetThuc = TaoNut("btnKetThuc", "&KẾT THÚC", 12, 300, 330, 28, 10);
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //BTVN2
            this.AcceptButton = this.btnNhap; //nhấn Enter = bấm Nhập
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(354, 340);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTVN2";
            this.Text = "frmListbox";
            this.FormClosing += new FormClosingEventHandler(this.BTVN2_FormClosing);
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

        private Button TaoNut(string name, string text, int x, int y, int w, int h, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private Label lblTieuDe;
        private TextBox txtSo;
        private ListBox lstSo;
        private Button btnNhap, btnTong, btnXoaDauCuoi, btnXoaChon, btnTang2;
        private Button btnBinhPhuong, btnChonChan, btnChonLe, btnKetThuc;
    }
}