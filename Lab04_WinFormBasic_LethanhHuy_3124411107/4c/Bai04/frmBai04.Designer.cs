namespace Bai04 {
    partial class frmBai04 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblSo = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblChan = new System.Windows.Forms.Label();
            this.lblLe = new System.Windows.Forms.Label();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.txtChan = new System.Windows.Forms.TextBox();
            this.txtLe = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnTinhTong = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //lblTieuDe
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 15);
            this.lblTieuDe.Size = new System.Drawing.Size(440, 32);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Nhập Dãy Số và Tính Tổng";

            //Nhập số
            this.lblSo.AutoSize = true;
            this.lblSo.Location = new System.Drawing.Point(30, 70);
            this.lblSo.Name = "lblSo";
            this.lblSo.Text = "Nhập số :";

            this.txtSo.Location = new System.Drawing.Point(140, 66);
            this.txtSo.Size = new System.Drawing.Size(80, 26);
            this.txtSo.Name = "txtSo";
            this.txtSo.TabIndex = 0;
            this.txtSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);

            this.btnNhap.Location = new System.Drawing.Point(250, 64);
            this.btnNhap.Size = new System.Drawing.Size(85, 30);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Text = "Nhập";
            this.btnNhap.TabIndex = 1;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);

            //Dãy vừa nhập
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(30, 107);
            this.lblDay.Name = "lblDay";
            this.lblDay.Text = "Dãy vừa nhập :";

            this.txtDay.Location = new System.Drawing.Point(140, 103);
            this.txtDay.Size = new System.Drawing.Size(270, 26);
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.TabStop = false;

            //Tổng
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(30, 144);
            this.lblTong.Name = "lblTong";
            this.lblTong.Text = "Tổng các phần tử trong dãy :";

            this.txtTong.Location = new System.Drawing.Point(240, 140);
            this.txtTong.Size = new System.Drawing.Size(80, 26);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.TabStop = false;

            //Tổng chẵn
            this.lblChan.AutoSize = true;
            this.lblChan.Location = new System.Drawing.Point(30, 181);
            this.lblChan.Name = "lblChan";
            this.lblChan.Text = "Tổng Chẵn :";

            this.txtChan.Location = new System.Drawing.Point(120, 177);
            this.txtChan.Size = new System.Drawing.Size(70, 26);
            this.txtChan.Name = "txtChan";
            this.txtChan.ReadOnly = true;
            this.txtChan.TabStop = false;

            //Tổng lẻ
            this.lblLe.AutoSize = true;
            this.lblLe.Location = new System.Drawing.Point(215, 181);
            this.lblLe.Name = "lblLe";
            this.lblLe.Text = "Tổng Lẻ :";

            this.txtLe.Location = new System.Drawing.Point(290, 177);
            this.txtLe.Size = new System.Drawing.Size(70, 26);
            this.txtLe.Name = "txtLe";
            this.txtLe.ReadOnly = true;
            this.txtLe.TabStop = false;

            //Các nút dưới cùng
            this.btnTinhTong.Location = new System.Drawing.Point(40, 225);
            this.btnTinhTong.Size = new System.Drawing.Size(105, 32);
            this.btnTinhTong.Name = "btnTinhTong";
            this.btnTinhTong.Text = "Tính Tổng";
            this.btnTinhTong.TabIndex = 2;
            this.btnTinhTong.Click += new System.EventHandler(this.btnTinhTong_Click);

            this.btnTiepTuc.Location = new System.Drawing.Point(165, 225);
            this.btnTiepTuc.Size = new System.Drawing.Size(105, 32);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.TabIndex = 3;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            this.btnThoat.Location = new System.Drawing.Point(290, 225);
            this.btnThoat.Size = new System.Drawing.Size(105, 32);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //frmBai4
            this.AcceptButton = this.btnNhap; //nhấn Enter = bấm Nhập
            this.CancelButton = this.btnThoat; //nhấn Esc = bấm Thoát
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 280);
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmBai4";
            this.Text = "Dãy số và Tính Tổng";
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblSo);
            this.Controls.Add(this.txtSo);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.lblChan);
            this.Controls.Add(this.txtChan);
            this.Controls.Add(this.lblLe);
            this.Controls.Add(this.txtLe);
            this.Controls.Add(this.btnTinhTong);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai4_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSo;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblChan;
        private System.Windows.Forms.Label lblLe;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.TextBox txtChan;
        private System.Windows.Forms.TextBox txtLe;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnTinhTong;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}