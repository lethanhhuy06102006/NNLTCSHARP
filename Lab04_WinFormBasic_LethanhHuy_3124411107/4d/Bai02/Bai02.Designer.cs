using System.Drawing;
using System.Windows.Forms;

namespace MangSo {
    partial class Bai02 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        //Form này có rất nhiều control nên dùng các hàm phụ TaoLabel, TaoText, TaoRadio...
        //(ở cuối file) để code ngắn gọn, dễ đọc hơn.
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //Tiêu đề
            this.lblTieuDe = new Label();
            this.lblTieuDe.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.Crimson;
            this.lblTieuDe.Location = new Point(0, 10);
            this.lblTieuDe.Size = new Size(470, 40);
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Mảng Số Nguyên";
            this.Controls.Add(this.lblTieuDe);

            //Hàng Nhập mảng
            this.lblNhapMang = TaoLabel(this, "lblNhapMang", "Nhập mảng :", 20, 63);
            this.lblNhapMang.AutoSize = false;
            this.lblNhapMang.Size = new Size(95, 24);
            this.lblNhapMang.BorderStyle = BorderStyle.FixedSingle;
            this.lblNhapMang.TextAlign = ContentAlignment.MiddleCenter;
            this.txtNhapMang = TaoText(this, "txtNhapMang", 125, 62, 220, false);
            this.txtNhapMang.TabIndex = 0;
            this.txtNhapMang.KeyPress += new KeyPressEventHandler(this.txtNhapMang_KeyPress);
            this.txtNhapMang.TextChanged += new System.EventHandler(this.txtNhapMang_TextChanged);
            this.btnReset = TaoNut(this, "btnReset", "Reset", 360, 60, 90, 28);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            //Hàng Kết quả mảng
            this.lblKetQuaMang = TaoLabel(this, "lblKetQuaMang", "Kết quả mảng :", 20, 98);
            this.txtKetQua = TaoText(this, "txtKetQua", 125, 95, 220, true);
            this.btnThoat = TaoNut(this, "btnThoat", "Thoát", 360, 93, 90, 28);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //Nút Thực Hiện + nhóm Sắp Xếp
            this.btnThucHien = TaoNut(this, "btnThucHien", "Thực Hiện", 20, 138, 95, 45);
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            this.grpSapXep = TaoGroup("grpSapXep", "Sắp Xếp", 130, 128, 320, 58);
            this.rdoTang = TaoRadio(this.grpSapXep, "rdoTang", "Sắp xếp Tăng", 20, 24);
            this.rdoGiam = TaoRadio(this.grpSapXep, "rdoGiam", "Sắp xếp Giảm", 170, 24);

            //Nhóm Tìm Kiếm
            this.grpTimKiem = TaoGroup("grpTimKiem", "Tìm Kiếm", 20, 195, 210, 100);
            this.rdoTimGiaTri = TaoRadio(this.grpTimKiem, "rdoTimGiaTri", "Tìm giá trị cần tìm", 10, 20);
            this.txtTimGiaTri = TaoText(this.grpTimKiem, "txtTimGiaTri", 160, 18, 40, false);
            this.txtTimGiaTri.KeyPress += new KeyPressEventHandler(this.txtGiaTri_KeyPress);
            this.rdoTimViTri = TaoRadio(this.grpTimKiem, "rdoTimViTri", "Tìm vị trí cần tìm", 10, 46);
            this.txtTimViTri = TaoText(this.grpTimKiem, "txtTimViTri", 160, 44, 40, false);
            this.txtTimViTri.KeyPress += new KeyPressEventHandler(this.txtViTri_KeyPress);
            this.lblSoTim = TaoLabel(this.grpTimKiem, "lblSoTim", "Số tìm được là :", 30, 74);
            this.txtSoTim = TaoText(this.grpTimKiem, "txtSoTim", 160, 70, 40, true);

            //Nhóm Xóa
            this.grpXoa = TaoGroup("grpXoa", "Xóa", 240, 195, 210, 100);
            this.rdoXoaGiaTri = TaoRadio(this.grpXoa, "rdoXoaGiaTri", "Tìm giá trị cần xóa", 10, 20);
            this.txtXoaGiaTri = TaoText(this.grpXoa, "txtXoaGiaTri", 160, 18, 40, false);
            this.txtXoaGiaTri.KeyPress += new KeyPressEventHandler(this.txtGiaTri_KeyPress);
            this.rdoXoaViTri = TaoRadio(this.grpXoa, "rdoXoaViTri", "Tìm vị trí cần xóa", 10, 46);
            this.txtXoaViTri = TaoText(this.grpXoa, "txtXoaViTri", 160, 44, 40, false);
            this.txtXoaViTri.KeyPress += new KeyPressEventHandler(this.txtViTri_KeyPress);
            this.lblXoaLuuY = TaoLabel(this.grpXoa, "lblXoaLuuY", "Cần sắp xếp tăng", 50, 74);
            this.lblXoaLuuY.ForeColor = Color.Red;

            //Nhóm Thêm
            this.grpThem = TaoGroup("grpThem", "Thêm", 20, 302, 210, 100);
            this.rdoThem = TaoRadio(this.grpThem, "rdoThem", "Giá trị cần thêm", 10, 20);
            this.txtThemGiaTri = TaoText(this.grpThem, "txtThemGiaTri", 160, 18, 40, false);
            this.txtThemGiaTri.KeyPress += new KeyPressEventHandler(this.txtGiaTri_KeyPress);
            this.lblThemViTri = TaoLabel(this.grpThem, "lblThemViTri", "Tại vị trí cần thêm :", 30, 48);
            this.txtThemViTri = TaoText(this.grpThem, "txtThemViTri", 160, 44, 40, false);
            this.txtThemViTri.KeyPress += new KeyPressEventHandler(this.txtViTri_KeyPress);
            this.lblThemLuuY = TaoLabel(this.grpThem, "lblThemLuuY", "Cần sắp xếp tăng", 50, 74);
            this.lblThemLuuY.ForeColor = Color.Red;

            //Nhóm Tổng
            this.grpTong = TaoGroup("grpTong", "Tổng", 240, 302, 210, 100);
            this.lblTong = TaoLabel(this.grpTong, "lblTong", "Tổng mảng", 10, 22);
            this.txtTong = TaoText(this.grpTong, "txtTong", 85, 18, 50, true);
            this.lblChan = TaoLabel(this.grpTong, "lblChan", "Tổng chẵn", 10, 48);
            this.txtChan = TaoText(this.grpTong, "txtChan", 85, 44, 50, true);
            this.lblLe = TaoLabel(this.grpTong, "lblLe", "Tổng lẻ", 10, 74);
            this.txtLe = TaoText(this.grpTong, "txtLe", 85, 70, 50, true);
            this.btnTong = TaoNut(this.grpTong, "btnTong", "Tổng", 145, 18, 55, 75);
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);

            //Nhóm Max - Min
            this.grpMaxMin = TaoGroup("grpMaxMin", "Max - Min", 20, 409, 210, 100);
            this.lblMax = TaoLabel(this.grpMaxMin, "lblMax", "Giá trị lớn nhất", 10, 30);
            this.txtMax = TaoText(this.grpMaxMin, "txtMax", 110, 26, 40, true);
            this.lblMin = TaoLabel(this.grpMaxMin, "lblMin", "Giá trị nhỏ nhất", 10, 66);
            this.txtMin = TaoText(this.grpMaxMin, "txtMin", 110, 62, 40, true);
            this.btnTim = TaoNut(this.grpMaxMin, "btnTim", "Tìm", 160, 20, 40, 70);
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            //Nhóm Thay Thế
            this.grpThayThe = TaoGroup("grpThayThe", "Thay Thế", 240, 409, 210, 100);
            this.rdoThayGiaTri = TaoRadio(this.grpThayThe, "rdoThayGiaTri", "Giá trị cần thay thế", 10, 20);
            this.txtThayGiaTri = TaoText(this.grpThayThe, "txtThayGiaTri", 160, 18, 40, false);
            this.txtThayGiaTri.KeyPress += new KeyPressEventHandler(this.txtGiaTri_KeyPress);
            this.rdoThayViTri = TaoRadio(this.grpThayThe, "rdoThayViTri", "Vị trí cần thay thế", 10, 46);
            this.txtThayViTri = TaoText(this.grpThayThe, "txtThayViTri", 160, 44, 40, false);
            this.txtThayViTri.KeyPress += new KeyPressEventHandler(this.txtViTri_KeyPress);
            this.lblSoThay = TaoLabel(this.grpThayThe, "lblSoThay", "Số thay thế là :", 30, 74);
            this.txtSoThay = TaoText(this.grpThayThe, "txtSoThay", 160, 70, 40, false);
            this.txtSoThay.KeyPress += new KeyPressEventHandler(this.txtGiaTri_KeyPress);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai02
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(470, 525);
            this.Font = new Font("Times New Roman", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai02";
            this.Text = "Mảng Số Nguyên";
            this.FormClosing += new FormClosingEventHandler(this.Bai02_FormClosing);
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

        private TextBox TaoText(Control cha, string name, int x, int y, int w, bool chiDoc) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(w, 23);
            txt.BorderStyle = BorderStyle.FixedSingle;
            if (chiDoc) { //ô kết quả: chỉ đọc, không nhận Tab
                txt.ReadOnly = true;
                txt.TabStop = false;
            }
            cha.Controls.Add(txt);
            return txt;
        }

        private RadioButton TaoRadio(Control cha, string name, string text, int x, int y) {
            RadioButton rdo = new RadioButton();
            rdo.Name = name;
            rdo.Text = text;
            rdo.AutoSize = true;
            rdo.Location = new Point(x, y);
            cha.Controls.Add(rdo);
            return rdo;
        }

        private Button TaoNut(Control cha, string name, string text, int x, int y, int w, int h) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            cha.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private Label lblTieuDe, lblNhapMang, lblKetQuaMang;
        private TextBox txtNhapMang, txtKetQua;
        private Button btnReset, btnThoat, btnThucHien, btnTong, btnTim;
        private GroupBox grpSapXep, grpTimKiem, grpXoa, grpThem, grpTong, grpMaxMin, grpThayThe;
        private RadioButton rdoTang, rdoGiam;
        private RadioButton rdoTimGiaTri, rdoTimViTri, rdoXoaGiaTri, rdoXoaViTri, rdoThem;
        private RadioButton rdoThayGiaTri, rdoThayViTri;
        private TextBox txtTimGiaTri, txtTimViTri, txtSoTim;
        private TextBox txtXoaGiaTri, txtXoaViTri;
        private TextBox txtThemGiaTri, txtThemViTri;
        private TextBox txtTong, txtChan, txtLe, txtMax, txtMin;
        private TextBox txtThayGiaTri, txtThayViTri, txtSoThay;
        private Label lblSoTim, lblXoaLuuY, lblThemViTri, lblThemLuuY;
        private Label lblTong, lblChan, lblLe, lblMax, lblMin, lblSoThay;
    }
}