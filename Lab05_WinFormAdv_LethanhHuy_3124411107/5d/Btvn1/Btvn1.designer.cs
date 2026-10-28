using System.Drawing;
using System.Windows.Forms;

namespace DongHo {
    partial class Bai01 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //Timer: cứ 1000 ms (1 giây) chạy sự kiện Tick một lần
            this.tmrDemNguoc = new System.Windows.Forms.Timer(this.components);
            this.tmrDemNguoc.Interval = 1000;
            this.tmrDemNguoc.Tick += new System.EventHandler(this.tmrDemNguoc_Tick);

            //Label hiện thời gian còn lại
            this.lblThoiGian = new Label();
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Text = "30:00";
            this.lblThoiGian.Font = new Font("Courier New", 14F, FontStyle.Bold);
            this.lblThoiGian.AutoSize = false;
            this.lblThoiGian.TextAlign = ContentAlignment.MiddleCenter;
            this.lblThoiGian.Location = new Point(0, 12);
            this.lblThoiGian.Size = new Size(260, 30);
            this.Controls.Add(this.lblThoiGian);

            //Nút Bắt đầu / Tạm dừng / Tiếp tục
            this.btnBatDau = new Button();
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Text = "&Bắt đầu";
            this.btnBatDau.Location = new Point(90, 55);
            this.btnBatDau.Size = new Size(80, 28);
            this.btnBatDau.TabIndex = 0;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            this.Controls.Add(this.btnBatDau);

            //Bai01
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(260, 100);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai01";
            this.Text = "Đồng hồ";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer tmrDemNguoc;
        private Label lblThoiGian;
        private Button btnBatDau;
    }
}