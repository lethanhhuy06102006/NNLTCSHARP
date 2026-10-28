namespace GiaiPhuongTrinh {
    partial class Bai01 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpChon = new System.Windows.Forms.GroupBox();
            this.rdoBacNhat = new System.Windows.Forms.RadioButton();
            this.rdoBacHai = new System.Windows.Forms.RadioButton();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.btnGiai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //lblTieuDe
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 12);
            this.lblTieuDe.Size = new System.Drawing.Size(330, 35);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "GIẢI PHƯƠNG TRÌNH";

            //grpChon: chứa 2 radio button
            this.grpChon.Location = new System.Drawing.Point(20, 55);
            this.grpChon.Size = new System.Drawing.Size(290, 80);
            this.grpChon.Name = "grpChon";
            this.grpChon.Text = "Bạn vui lòng chọn";
            this.grpChon.Controls.Add(this.rdoBacNhat);
            this.grpChon.Controls.Add(this.rdoBacHai);

            this.rdoBacNhat.AutoSize = true;
            this.rdoBacNhat.Location = new System.Drawing.Point(25, 22);
            this.rdoBacNhat.Name = "rdoBacNhat";
            this.rdoBacNhat.Text = "Phương trình bậc nhất";
            this.rdoBacNhat.TabIndex = 0;
            this.rdoBacNhat.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);

            this.rdoBacHai.AutoSize = true;
            this.rdoBacHai.Location = new System.Drawing.Point(25, 48);
            this.rdoBacHai.Name = "rdoBacHai";
            this.rdoBacHai.Text = "Phương trình bậc hai";
            this.rdoBacHai.TabIndex = 1;
            this.rdoBacHai.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);

            //Labels
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(25, 155);
            this.lblA.Name = "lblA";
            this.lblA.Text = "Nhập a";

            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(25, 188);
            this.lblB.Name = "lblB";
            this.lblB.Text = "Nhập b";

            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(25, 221);
            this.lblC.Name = "lblC";
            this.lblC.Text = "Nhập c";

            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(25, 260);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Text = "Kết quả";

            //Các ô nhập: chữ canh phải, dùng chung KeyPress và TextChanged
            TaoONhap(this.txtA, "txtA", 152, 2);
            TaoONhap(this.txtB, "txtB", 185, 3);
            TaoONhap(this.txtC, "txtC", 218, 4);

            //txtKetQua: nhiều dòng, chỉ đọc
            this.txtKetQua.Location = new System.Drawing.Point(90, 257);
            this.txtKetQua.Size = new System.Drawing.Size(220, 50);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.TabStop = false;
            this.txtKetQua.Name = "txtKetQua";

            //btnGiai
            this.btnGiai.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnGiai.Location = new System.Drawing.Point(225, 148);
            this.btnGiai.Size = new System.Drawing.Size(85, 36);
            this.btnGiai.Name = "btnGiai";
            this.btnGiai.Text = "Giải";
            this.btnGiai.TabIndex = 5;
            this.btnGiai.Click += new System.EventHandler(this.btnGiai_Click);

            //btnThoat
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnThoat.Location = new System.Drawing.Point(225, 196);
            this.btnThoat.Size = new System.Drawing.Size(85, 36);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai01
            this.AcceptButton = this.btnGiai; //Enter = Giải
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 325);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Bai01";
            this.Text = "Giải phương trình bậc 1-2";
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.grpChon);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnGiai);
            this.Controls.Add(this.btnThoat);
            this.Load += new System.EventHandler(this.Bai01_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai01_FormClosing);
            this.grpChon.ResumeLayout(false);
            this.grpChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Hàm phụ: đặt thuộc tính cho 1 ô nhập và thêm vào form
        private void TaoONhap(System.Windows.Forms.TextBox txt, string name, int y, int tab) {
            txt.Name = name;
            txt.Location = new System.Drawing.Point(90, y);
            txt.Size = new System.Drawing.Size(110, 23);
            txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txt.TabIndex = tab;
            txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);
            txt.TextChanged += new System.EventHandler(this.txtSo_TextChanged);
            this.Controls.Add(txt);
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpChon;
        private System.Windows.Forms.RadioButton rdoBacNhat;
        private System.Windows.Forms.RadioButton rdoBacHai;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btnGiai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}