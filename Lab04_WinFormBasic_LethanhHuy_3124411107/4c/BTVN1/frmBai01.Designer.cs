namespace Bai01 {
    partial class frmBai01 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtManHinh = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnBang = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCong = new System.Windows.Forms.Button();
            this.btnTru = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnChia = new System.Windows.Forms.Button();
            this.SuspendLayout();

            //lblTieuDe
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 10);
            this.lblTieuDe.Size = new System.Drawing.Size(290, 35);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Máy Tính Bỏ Túi";

            //txtManHinh: màn hình hiển thị số
            this.txtManHinh.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txtManHinh.ForeColor = System.Drawing.Color.Blue;
            this.txtManHinh.BackColor = System.Drawing.Color.White;
            this.txtManHinh.Location = new System.Drawing.Point(25, 52);
            this.txtManHinh.Size = new System.Drawing.Size(240, 29);
            this.txtManHinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; //chữ canh phải
            this.txtManHinh.ReadOnly = true;
            this.txtManHinh.TabStop = false;
            this.txtManHinh.Name = "txtManHinh";
            this.txtManHinh.Text = "0";

            //Các nút: 4 cột, 4 hàng
            //hàng 1: 1 2 3 4
            TaoNut(this.btn1, "btn1", "1", 25, 95);
            TaoNut(this.btn2, "btn2", "2", 90, 95);
            TaoNut(this.btn3, "btn3", "3", 155, 95);
            TaoNut(this.btn4, "btn4", "4", 220, 95);
            //hàng 2: 5 6 7 8
            TaoNut(this.btn5, "btn5", "5", 25, 135);
            TaoNut(this.btn6, "btn6", "6", 90, 135);
            TaoNut(this.btn7, "btn7", "7", 155, 135);
            TaoNut(this.btn8, "btn8", "8", 220, 135);
            //hàng 3: 9 0 = C
            TaoNut(this.btn9, "btn9", "9", 25, 175);
            TaoNut(this.btn0, "btn0", "0", 90, 175);
            TaoNut(this.btnBang, "btnBang", "=", 155, 175);
            TaoNut(this.btnXoa, "btnXoa", "C", 220, 175);
            //hàng 4: + - * /
            TaoNut(this.btnCong, "btnCong", "+", 25, 215);
            TaoNut(this.btnTru, "btnTru", "-", 90, 215);
            TaoNut(this.btnNhan, "btnNhan", "*", 155, 215);
            TaoNut(this.btnChia, "btnChia", "/", 220, 215);

            //10 nút số dùng chung 1 sự kiện
            this.btn0.Click += new System.EventHandler(this.btnSo_Click);
            this.btn1.Click += new System.EventHandler(this.btnSo_Click);
            this.btn2.Click += new System.EventHandler(this.btnSo_Click);
            this.btn3.Click += new System.EventHandler(this.btnSo_Click);
            this.btn4.Click += new System.EventHandler(this.btnSo_Click);
            this.btn5.Click += new System.EventHandler(this.btnSo_Click);
            this.btn6.Click += new System.EventHandler(this.btnSo_Click);
            this.btn7.Click += new System.EventHandler(this.btnSo_Click);
            this.btn8.Click += new System.EventHandler(this.btnSo_Click);
            this.btn9.Click += new System.EventHandler(this.btnSo_Click);

            //4 nút phép toán dùng chung 1 sự kiện
            this.btnCong.Click += new System.EventHandler(this.btnPhepToan_Click);
            this.btnTru.Click += new System.EventHandler(this.btnPhepToan_Click);
            this.btnNhan.Click += new System.EventHandler(this.btnPhepToan_Click);
            this.btnChia.Click += new System.EventHandler(this.btnPhepToan_Click);

            this.btnBang.Click += new System.EventHandler(this.btnBang_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            //frmBai5
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 260);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmBai5";
            this.Text = "Máy Tính Bỏ Túi";
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.txtManHinh);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Hàm phụ: đặt thuộc tính cho 1 nút và thêm vào form (đỡ phải viết lặp 16 lần)
        private void TaoNut(System.Windows.Forms.Button btn, string name, string text, int x, int y) {
            btn.Name = name;
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(50, 32);
            this.Controls.Add(btn);
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtManHinh;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnBang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.Button btnTru;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnChia;
    }
}