using System.Drawing;
using System.Windows.Forms;

namespace KhachSan {
    partial class BTVN1 {
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
            this.lblTieuDe.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.DarkOrange;
            this.lblTieuDe.BorderStyle = BorderStyle.FixedSingle;
            this.lblTieuDe.Location = new Point(10, 10);
            this.lblTieuDe.Size = new Size(560, 40);
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            this.Controls.Add(this.lblTieuDe);

            //Khung bên trái: thông tin khách
            this.pnlKhach = TaoPanel("pnlKhach", 10, 55, 345, 240);

            TaoLabel(this.pnlKhach, "lblHoTen", "Họ và tên:", 15, 25);
            this.txtHoTen = TaoText(this.pnlKhach, "txtHoTen", 85, 22, 160, 0);
            this.txtHoTen.Leave += new System.EventHandler(this.txtBatBuoc_Leave);

            TaoLabel(this.pnlKhach, "lblDiaChi", "Địa chỉ:", 30, 55);
            this.txtDiaChi = TaoText(this.pnlKhach, "txtDiaChi", 85, 52, 240, 1);
            this.txtDiaChi.Leave += new System.EventHandler(this.txtBatBuoc_Leave);

            TaoLabel(this.pnlKhach, "lblSoNgay", "Số ngày ở:", 15, 89);
            this.txtSoNgay = TaoText(this.pnlKhach, "txtSoNgay", 85, 86, 60, 2);
            this.txtSoNgay.TextAlign = HorizontalAlignment.Right;
            this.txtSoNgay.KeyPress += new KeyPressEventHandler(this.txtSoNgay_KeyPress);

            //Loại phòng
            this.grpLoaiPhong = TaoGroup(this.pnlKhach, "grpLoaiPhong", "Loại phòng", 8, 118, 100, 110);
            this.rdoPhongDon = TaoRadio(this.grpLoaiPhong, "rdoPhongDon", "Phòng đơn", 10, 22);
            this.rdoPhongDoi = TaoRadio(this.grpLoaiPhong, "rdoPhongDoi", "Phòng đôi", 10, 51);
            this.rdoPhongBa = TaoRadio(this.grpLoaiPhong, "rdoPhongBa", "Phòng ba", 10, 80);

            //Tiện nghi
            this.grpTienNghi = TaoGroup(this.pnlKhach, "grpTienNghi", "Tiện nghi", 113, 118, 110, 110);
            this.chkTivi = TaoCheck(this.grpTienNghi, "chkTivi", "Tivi", 10, 22);
            this.chkInternet = TaoCheck(this.grpTienNghi, "chkInternet", "Internet", 10, 51);
            this.chkMayNuocNong = TaoCheck(this.grpTienNghi, "chkMayNuocNong", "Máy nước nóng", 10, 80);

            //Dịch vụ
            this.grpDichVu = TaoGroup(this.pnlKhach, "grpDichVu", "Dịch vụ", 228, 118, 105, 110);
            this.chkKaraoke = TaoCheck(this.grpDichVu, "chkKaraoke", "Karaoke", 10, 30);
            this.chkAnSang = TaoCheck(this.grpDichVu, "chkAnSang", "Ăn sáng", 10, 65);

            //Khung bên phải: thanh toán, tổng kết
            this.pnlThanhToan = TaoPanel("pnlThanhToan", 360, 55, 210, 240);

            this.btnThanhToan = TaoNut(this.pnlThanhToan, "btnThanhToan", "&Thanh toán", 12, 10);
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnNhapMoi = TaoNut(this.pnlThanhToan, "btnNhapMoi", "&Nhập mới", 105, 10);
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);

            TaoLabel(this.pnlThanhToan, "lblThanhTienChu", "Thành tiền:", 12, 48);
            this.lblThanhTien = TaoLabelKetQua(this.pnlThanhToan, "lblThanhTien", 80, 45, 115);

            this.btnTongKet = TaoNut(this.pnlThanhToan, "btnTongKet", "Tổng &Kết", 12, 80);
            this.btnTongKet.Click += new System.EventHandler(this.btnTongKet_Click);

            this.grpTongKet = TaoGroup(this.pnlThanhToan, "grpTongKet", "Thông tin tổng kết", 8, 115, 192, 75);
            TaoLabel(this.grpTongKet, "lblSoLuotChu", "Số lượt người:", 8, 23);
            this.lblSoLuot = TaoLabelKetQua(this.grpTongKet, "lblSoLuot", 95, 20, 88);
            TaoLabel(this.grpTongKet, "lblTongTienChu", "Tổng số tiền:", 8, 50);
            this.lblTongTien = TaoLabelKetQua(this.grpTongKet, "lblTongTien", 95, 47, 88);

            this.btnThoat = TaoNut(this.pnlThanhToan, "btnThoat", "Th&oát", 12, 202);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //BTVN1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(580, 305);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTVN1";
            this.Text = "frmDangkyKS";
            this.Load += new System.EventHandler(this.BTVN1_Load);
            this.FormClosing += new FormClosingEventHandler(this.BTVN1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private Panel TaoPanel(string name, int x, int y, int w, int h) {
            Panel pnl = new Panel();
            pnl.Name = name;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Location = new Point(x, y);
            pnl.Size = new Size(w, h);
            this.Controls.Add(pnl);
            return pnl;
        }

        private GroupBox TaoGroup(Control cha, string name, string text, int x, int y, int w, int h) {
            GroupBox grp = new GroupBox();
            grp.Name = name;
            grp.Text = text;
            grp.Location = new Point(x, y);
            grp.Size = new Size(w, h);
            cha.Controls.Add(grp);
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

        //Label có viền để hiện kết quả
        private Label TaoLabelKetQua(Control cha, string name, int x, int y, int w) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.AutoSize = false;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = Color.White;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(w, 22);
            cha.Controls.Add(lbl);
            return lbl;
        }

        private TextBox TaoText(Control cha, string name, int x, int y, int w, int tab) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(w, 22);
            txt.TabIndex = tab;
            txt.TextChanged += new System.EventHandler(this.ThongTin_Changed);
            cha.Controls.Add(txt);
            return txt;
        }

        private RadioButton TaoRadio(Control cha, string name, string text, int x, int y) {
            RadioButton rdo = new RadioButton();
            rdo.Name = name;
            rdo.Text = text;
            rdo.AutoSize = true;
            rdo.Location = new Point(x, y);
            rdo.CheckedChanged += new System.EventHandler(this.ThongTin_Changed);
            cha.Controls.Add(rdo);
            return rdo;
        }

        private CheckBox TaoCheck(Control cha, string name, string text, int x, int y) {
            CheckBox chk = new CheckBox();
            chk.Name = name;
            chk.Text = text;
            chk.AutoSize = true;
            chk.Location = new Point(x, y);
            cha.Controls.Add(chk);
            return chk;
        }

        private Button TaoNut(Control cha, string name, string text, int x, int y) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(85, 27);
            cha.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private Label lblTieuDe;
        private Panel pnlKhach, pnlThanhToan;
        private TextBox txtHoTen, txtDiaChi, txtSoNgay;
        private GroupBox grpLoaiPhong, grpTienNghi, grpDichVu, grpTongKet;
        private RadioButton rdoPhongDon, rdoPhongDoi, rdoPhongBa;
        private CheckBox chkTivi, chkInternet, chkMayNuocNong, chkKaraoke, chkAnSang;
        private Button btnThanhToan, btnNhapMoi, btnTongKet, btnThoat;
        private Label lblThanhTien, lblSoLuot, lblTongTien;
    }
}