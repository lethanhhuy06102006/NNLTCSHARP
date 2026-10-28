using System.Drawing;
using System.Windows.Forms;

namespace DanhSachDiem {
    partial class BTNC2 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //Môn học: combobox chứa mã môn học, có thêm 1 mục khoảng trắng đại diện cho tất cả môn
            this.lblMonHoc = new Label();
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Text = "Môn học";
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new Point(40, 24);
            this.Controls.Add(this.lblMonHoc);

            this.cboMonHoc = new ComboBox();
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn, không gõ
            this.cboMonHoc.Location = new Point(110, 20);
            this.cboMonHoc.Size = new Size(260, 23);
            this.cboMonHoc.TabIndex = 0;
            this.Controls.Add(this.cboMonHoc);

            //Nút Lọc dữ liệu
            this.btnLoc = new Button();
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Text = "&Lọc dữ liệu";
            this.btnLoc.Location = new Point(480, 18);
            this.btnLoc.Size = new Size(100, 27);
            this.btnLoc.TabIndex = 1;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            this.Controls.Add(this.btnLoc);

            //ListView hiện danh sách điểm
            this.lvDiem = new ListView();
            this.lvDiem.Name = "lvDiem";
            this.lvDiem.View = View.Details;
            this.lvDiem.FullRowSelect = true;
            this.lvDiem.GridLines = true;
            this.lvDiem.Location = new Point(20, 60);
            this.lvDiem.Size = new Size(600, 290);
            this.lvDiem.TabIndex = 2;
            this.lvDiem.Columns.Add("STT", 50);
            this.lvDiem.Columns.Add("Tên SV", 190);
            this.lvDiem.Columns.Add("Ngày sinh", 110);
            this.lvDiem.Columns.Add("Tên môn học", 170);
            this.lvDiem.Columns.Add("Điểm", 70, HorizontalAlignment.Right);
            this.Controls.Add(this.lvDiem);

            //Tổng điểm
            this.lblTongDiem = new Label();
            this.lblTongDiem.Name = "lblTongDiem";
            this.lblTongDiem.Text = "Tổng điểm";
            this.lblTongDiem.AutoSize = true;
            this.lblTongDiem.Location = new Point(330, 372);
            this.Controls.Add(this.lblTongDiem);

            this.txtTongDiem = new TextBox();
            this.txtTongDiem.Name = "txtTongDiem";
            this.txtTongDiem.ReadOnly = true; //chỉ để xem, chương trình tự tính
            this.txtTongDiem.TabStop = false;
            this.txtTongDiem.TextAlign = HorizontalAlignment.Right;
            this.txtTongDiem.Location = new Point(400, 368);
            this.txtTongDiem.Size = new Size(110, 23);
            this.Controls.Add(this.txtTongDiem);

            //BTNC2
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(640, 410);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTNC2";
            this.Text = "Danh sách sinh viên";
            this.Load += new System.EventHandler(this.BTNC2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblMonHoc, lblTongDiem;
        private ComboBox cboMonHoc;
        private Button btnLoc;
        private ListView lvDiem;
        private TextBox txtTongDiem;
    }
}