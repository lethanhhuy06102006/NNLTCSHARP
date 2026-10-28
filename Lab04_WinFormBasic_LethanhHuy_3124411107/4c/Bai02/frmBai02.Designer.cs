namespace Bai02 {
    partial class frmBai02 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblXacNhan = new System.Windows.Forms.Label();
            this.lblSao1 = new System.Windows.Forms.Label();
            this.lblSao2 = new System.Windows.Forms.Label();
            this.lblSao3 = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTieuDe
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 12);
            this.lblTieuDe.Size = new System.Drawing.Size(440, 30);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Đăng ký tài khoản";

            //Các label bên trái
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Location = new System.Drawing.Point(20, 60);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Text = "Tên đăng nhập";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 95);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Địa chỉ email";

            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(20, 130);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu";

            this.lblXacNhan.AutoSize = true;
            this.lblXacNhan.Location = new System.Drawing.Point(20, 165);
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Text = "Xác nhận mật khẩu";

            //Các TextBox
            this.txtTenDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDN.Location = new System.Drawing.Point(170, 56);
            this.txtTenDN.Size = new System.Drawing.Size(200, 25);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.TabIndex = 0;
            this.txtTenDN.Leave += new System.EventHandler(this.txtBatBuoc_Leave);

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(170, 91);
            this.txtEmail.Size = new System.Drawing.Size(200, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);

            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Location = new System.Drawing.Point(170, 126);
            this.txtMatKhau.Size = new System.Drawing.Size(200, 25);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';          // ẩn mật khẩu
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.Leave += new System.EventHandler(this.txtBatBuoc_Leave);

            this.txtXacNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXacNhan.Location = new System.Drawing.Point(170, 161);
            this.txtXacNhan.Size = new System.Drawing.Size(200, 25);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.PasswordChar = '*';
            this.txtXacNhan.TabIndex = 3;
            this.txtXacNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXacNhan_KeyDown);

            //Các dấu (*)
            this.lblSao1.AutoSize = true;
            this.lblSao1.Location = new System.Drawing.Point(395, 60);
            this.lblSao1.Name = "lblSao1";
            this.lblSao1.Text = "(*)";

            this.lblSao2.AutoSize = true;
            this.lblSao2.Location = new System.Drawing.Point(395, 95);
            this.lblSao2.Name = "lblSao2";
            this.lblSao2.Text = "(*)";

            this.lblSao3.AutoSize = true;
            this.lblSao3.Location = new System.Drawing.Point(395, 130);
            this.lblSao3.Name = "lblSao3";
            this.lblSao3.Text = "(*)";

            // btnDangKy
            this.btnDangKy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDangKy.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDangKy.Location = new System.Drawing.Point(170, 200);
            this.btnDangKy.Size = new System.Drawing.Size(200, 40);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBai02
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 260);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmBai2";
            this.Text = "Đăng ký tài khoản";
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblXacNhan);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.lblSao1);
            this.Controls.Add(this.lblSao2);
            this.Controls.Add(this.lblSao3);
            this.Controls.Add(this.btnDangKy);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblXacNhan;
        private System.Windows.Forms.Label lblSao1;
        private System.Windows.Forms.Label lblSao2;
        private System.Windows.Forms.Label lblSao3;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}