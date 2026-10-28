namespace Bai03 {
    partial class frmBai03 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblUCLN = new System.Windows.Forms.Label();
            this.lblBCNN = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtUCLN = new System.Windows.Forms.TextBox();
            this.txtBCNN = new System.Windows.Forms.TextBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //lblTieuDe
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 15);
            this.lblTieuDe.Size = new System.Drawing.Size(420, 32);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Ước Số Chung - Bội Số Chung";

            //Labels
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(50, 65);
            this.lblA.Name = "lblA";
            this.lblA.Text = "Nhập số a :";

            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(50, 100);
            this.lblB.Name = "lblB";
            this.lblB.Text = "Nhập số b :";

            this.lblUCLN.AutoSize = true;
            this.lblUCLN.Location = new System.Drawing.Point(50, 135);
            this.lblUCLN.Name = "lblUCLN";
            this.lblUCLN.Text = "Ước số chung lớn nhất :";

            this.lblBCNN.AutoSize = true;
            this.lblBCNN.Location = new System.Drawing.Point(50, 170);
            this.lblBCNN.Name = "lblBCNN";
            this.lblBCNN.Text = "Bội số chung nhỏ nhất :";

            //TextBox nhập
            this.txtA.Location = new System.Drawing.Point(140, 62);
            this.txtA.Size = new System.Drawing.Size(145, 26);
            this.txtA.Name = "txtA";
            this.txtA.TabIndex = 0;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);
            this.txtA.Leave += new System.EventHandler(this.txtSo_Leave);

            this.txtB.Location = new System.Drawing.Point(140, 97);
            this.txtB.Size = new System.Drawing.Size(145, 26);
            this.txtB.Name = "txtB";
            this.txtB.TabIndex = 1;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);
            this.txtB.Leave += new System.EventHandler(this.txtSo_Leave);

            //TextBox kết quả (chỉ đọc, nền xám)
            this.txtUCLN.Location = new System.Drawing.Point(230, 132);
            this.txtUCLN.Size = new System.Drawing.Size(55, 26);
            this.txtUCLN.Name = "txtUCLN";
            this.txtUCLN.ReadOnly = true;
            this.txtUCLN.TabStop = false;

            this.txtBCNN.Location = new System.Drawing.Point(230, 167);
            this.txtBCNN.Size = new System.Drawing.Size(55, 26);
            this.txtBCNN.Name = "txtBCNN";
            this.txtBCNN.ReadOnly = true;
            this.txtBCNN.TabStop = false;

            //Buttons
            this.btnThucHien.Location = new System.Drawing.Point(20, 210);
            this.btnThucHien.Size = new System.Drawing.Size(105, 32);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.TabIndex = 2;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            this.btnTiepTuc.Location = new System.Drawing.Point(150, 210);
            this.btnTiepTuc.Size = new System.Drawing.Size(105, 32);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.TabIndex = 3;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            this.btnThoat.Location = new System.Drawing.Point(280, 210);
            this.btnThoat.Size = new System.Drawing.Size(105, 32);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //frmBai3
            this.AcceptButton = this.btnThucHien; //Enter = Thực Hiện
            this.CancelButton = this.btnThoat; //Esc = Thoát
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 260);
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmBai3";
            this.Text = "Ước Số - Bội Số";
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblUCLN);
            this.Controls.Add(this.lblBCNN);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtUCLN);
            this.Controls.Add(this.txtBCNN);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblUCLN;
        private System.Windows.Forms.Label lblBCNN;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtUCLN;
        private System.Windows.Forms.TextBox txtBCNN;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}