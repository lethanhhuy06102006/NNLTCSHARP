namespace Bai01 {
    partial class frmBai01 {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        //Tự viết code tạo control vì trong VS Code không có cửa sổ design kéo-thả
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.btnCong = new System.Windows.Forms.Button();
            this.btnTru = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnChia = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblA
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(20, 22);
            this.lblA.Name = "lblA";
            this.lblA.Text = "a =";
            this.lblA.TabIndex = 0;

            // txtA
            this.txtA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA.Location = new System.Drawing.Point(90, 18);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(110, 25);
            this.txtA.TabIndex = 1;
            this.txtA.TextChanged += new System.EventHandler(this.txtSo_TextChanged);
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);

            // lblB
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(230, 22);
            this.lblB.Name = "lblB";
            this.lblB.Text = "b =";
            this.lblB.TabIndex = 2;

            // txtB
            this.txtB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtB.Location = new System.Drawing.Point(270, 18);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(110, 25);
            this.txtB.TabIndex = 3;
            this.txtB.TextChanged += new System.EventHandler(this.txtSo_TextChanged);
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSo_KeyPress);

            // lblKetQua
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(20, 60);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Text = "Kết quả";
            this.lblKetQua.TabIndex = 4;

            // txtKetQua
            this.txtKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKetQua.Location = new System.Drawing.Point(90, 56);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;          // chỉ hiển thị, không cho sửa
            this.txtKetQua.TabStop = false;
            this.txtKetQua.Size = new System.Drawing.Size(290, 25);

            // btnCong
            this.btnCong.Location = new System.Drawing.Point(20, 100);
            this.btnCong.Name = "btnCong";
            this.btnCong.Size = new System.Drawing.Size(80, 32);
            this.btnCong.Text = "+";
            this.btnCong.TabIndex = 5;
            this.btnCong.Click += new System.EventHandler(this.btnCong_Click);

            // btnTru
            this.btnTru.Location = new System.Drawing.Point(115, 100);
            this.btnTru.Name = "btnTru";
            this.btnTru.Size = new System.Drawing.Size(80, 32);
            this.btnTru.Text = "-";
            this.btnTru.TabIndex = 6;
            this.btnTru.Click += new System.EventHandler(this.btnTru_Click);

            // btnNhan
            this.btnNhan.Location = new System.Drawing.Point(210, 100);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(80, 32);
            this.btnNhan.Text = "x";
            this.btnNhan.TabIndex = 7;
            this.btnNhan.Click += new System.EventHandler(this.btnNhan_Click);

            // btnChia
            this.btnChia.Location = new System.Drawing.Point(305, 100);
            this.btnChia.Name = "btnChia";
            this.btnChia.Size = new System.Drawing.Size(80, 32);
            this.btnChia.Text = "/";
            this.btnChia.TabIndex = 8;
            this.btnChia.Click += new System.EventHandler(this.btnChia_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // frmBai1
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 150);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmBai1";
            this.Text = "Cộng trừ nhân chia";
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnChia);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBai1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.Button btnTru;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnChia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}