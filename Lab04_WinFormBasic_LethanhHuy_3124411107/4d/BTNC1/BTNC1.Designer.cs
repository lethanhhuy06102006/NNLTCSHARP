using System.Drawing;
using System.Windows.Forms;

namespace CafeSinhVien {
    partial class BTNC1 {
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
            Font chuDam = new Font("Tahoma", 9F, FontStyle.Bold);

            //Tiêu đề
            this.lblTieuDe = new Label();
            this.lblTieuDe.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.DarkOrange;
            this.lblTieuDe.Location = new Point(0, 12);
            this.lblTieuDe.Size = new Size(400, 28);
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "CAFE SINH VIÊN";
            this.Controls.Add(this.lblTieuDe);

            //Tên khách hàng
            this.lblTen = TaoLabel(this, "lblTen", "Tên khách hàng", 25, 53);
            this.lblTen.Font = chuDam;
            this.txtTen = new TextBox();
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new Point(150, 50);
            this.txtTen.Size = new Size(220, 22);
            this.txtTen.TabIndex = 0;
            this.txtTen.TextChanged += new System.EventHandler(this.ThongTin_Changed);
            this.txtTen.Leave += new System.EventHandler(this.txtTen_Leave);
            this.Controls.Add(this.txtTen);

            //Số khách hàng
            this.lblSoKhach = TaoLabel(this, "lblSoKhach", "Số khách hàng", 35, 81);
            this.lblSoKhach.Font = chuDam;
            this.txtSoKhach = new TextBox();
            this.txtSoKhach.Name = "txtSoKhach";
            this.txtSoKhach.Location = new Point(150, 78);
            this.txtSoKhach.Size = new Size(220, 22);
            this.txtSoKhach.TabIndex = 1;
            this.txtSoKhach.TextChanged += new System.EventHandler(this.ThongTin_Changed);
            this.txtSoKhach.KeyPress += new KeyPressEventHandler(this.txtSoKhach_KeyPress);
            this.Controls.Add(this.txtSoKhach);

            //Sinh viên
            this.chkSinhVien = TaoCheck(this, "chkSinhVien", "Sinh viên ?", 150, 108, 0);
            this.chkSinhVien.TabIndex = 2;

            //Nhóm Nước uống (giá lưu ở Tag)
            this.grpNuocUong = TaoGroup("grpNuocUong", "Nước uống", 15, 135, 175, 110);
            this.rdoCafeDen = TaoRadio(this.grpNuocUong, "rdoCafeDen", "Cafe đen", 5, 25, 20000);
            this.rdoCafeDa = TaoRadio(this.grpNuocUong, "rdoCafeDa", "Cafe đá", 95, 25, 25000);
            this.rdoCafeSua = TaoRadio(this.grpNuocUong, "rdoCafeSua", "Cafe sữa", 5, 52, 25000);
            this.rdoCafeKem = TaoRadio(this.grpNuocUong, "rdoCafeKem", "Cafe kem", 95, 52, 35000);
            this.rdoCafeSuaDa = TaoRadio(this.grpNuocUong, "rdoCafeSuaDa", "Cafe sữa đá", 10, 79, 30000);

            //Nhóm Thức ăn (giá lưu ở Tag)
            this.grpThucAn = TaoGroup("grpThucAn", "Thức ăn", 200, 135, 185, 110);
            this.chkBanhMyTrung = TaoCheck(this.grpThucAn, "chkBanhMyTrung", "Bánh mỳ trứng", 10, 22, 15000);
            this.chkMyXaoBo = TaoCheck(this.grpThucAn, "chkMyXaoBo", "Mỳ xào bò", 140, 22, 30000);
            this.chkBanhMyCa = TaoCheck(this.grpThucAn, "chkBanhMyCa", "Bánh mỳ cá", 10, 49, 15000);
            this.chkMyCay = TaoCheck(this.grpThucAn, "chkMyCay", "Mỳ cay", 115, 49, 50000);
            this.chkMyTomTrung = TaoCheck(this.grpThucAn, "chkMyTomTrung", "Mỳ tôm trứng", 10, 76, 20000);

            //Các nút
            this.btnTinhTien = TaoNut("btnTinhTien", "Tính tiền", 25);
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            this.btnNhapLai = TaoNut("btnNhapLai", "Nhập lại", 115);
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            this.btnThanhToan = TaoNut("btnThanhToan", "Thanh toán", 205);
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThoat = TaoNut("btnThoat", "Thoát", 295);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //Tổng khách hàng, tổng tiền (dùng label có viền để hiển thị)
            this.lblTongKhachChu = TaoLabel(this, "lblTongKhachChu", "Tổng khách hàng", 35, 313);
            this.lblTongKhachChu.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            this.lblTongKhach = TaoLabelKetQua("lblTongKhach", 310);
            this.lblTongTienChu = TaoLabel(this, "lblTongTienChu", "Tổng tiền thanh toán", 35, 348);
            this.lblTongTienChu.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            this.lblTongTien = TaoLabelKetQua("lblTongTien", 345);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //BTNC1
            this.AcceptButton = this.btnTinhTien; //Enter = Tính tiền
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 385);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTNC1";
            this.Text = "Thanh toán tiền";
            this.Load += new System.EventHandler(this.BTNC1_Load);
            this.FormClosing += new FormClosingEventHandler(this.BTNC1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private GroupBox TaoGroup(string name, string text, int x, int y, int w, int h) {
            GroupBox grp = new GroupBox();
            grp.Name = name;
            grp.Text = text;
            grp.Location = new Point(x, y);
            grp.Size = new Size(w, h);
            this.Controls.Add(grp);
            return grp;
        }

        private Label TaoLabel(Control cha, string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            cha.Controls.Add(lbl);
            return lbl;
        }

        //Label có viền, canh phải, để hiện tổng khách / tổng tiền
        private Label TaoLabelKetQua(string name, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.AutoSize = false;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = Color.White;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            lbl.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.Blue;
            lbl.Location = new Point(190, y);
            lbl.Size = new Size(180, 24);
            this.Controls.Add(lbl);
            return lbl;
        }

        //Radio button nước uống, gia = giá tiền lưu vào Tag
        private RadioButton TaoRadio(Control cha, string name, string text, int x, int y, int gia) {
            RadioButton rdo = new RadioButton();
            rdo.Name = name;
            rdo.Text = text;
            rdo.Tag = gia;
            rdo.AutoSize = true;
            rdo.Location = new Point(x, y);
            rdo.CheckedChanged += new System.EventHandler(this.ThongTin_Changed);
            cha.Controls.Add(rdo);
            return rdo;
        }

        //CheckBox thức ăn (và Sinh viên), gia = giá tiền lưu vào Tag
        private CheckBox TaoCheck(Control cha, string name, string text, int x, int y, int gia) {
            CheckBox chk = new CheckBox();
            chk.Name = name;
            chk.Text = text;
            chk.Tag = gia;
            chk.AutoSize = true;
            chk.Location = new Point(x, y);
            chk.CheckedChanged += new System.EventHandler(this.ThongTin_Changed);
            cha.Controls.Add(chk);
            return chk;
        }

        private Button TaoNut(string name, string text, int x) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, 260);
            btn.Size = new Size(80, 30);
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private Label lblTieuDe, lblTen, lblSoKhach;
        private TextBox txtTen, txtSoKhach;
        private CheckBox chkSinhVien;
        private GroupBox grpNuocUong, grpThucAn;
        private RadioButton rdoCafeDen, rdoCafeDa, rdoCafeSua, rdoCafeKem, rdoCafeSuaDa;
        private CheckBox chkBanhMyTrung, chkMyXaoBo, chkBanhMyCa, chkMyCay, chkMyTomTrung;
        private Button btnTinhTien, btnNhapLai, btnThanhToan, btnThoat;
        private Label lblTongKhachChu, lblTongKhach, lblTongTienChu, lblTongTien;
    }
}