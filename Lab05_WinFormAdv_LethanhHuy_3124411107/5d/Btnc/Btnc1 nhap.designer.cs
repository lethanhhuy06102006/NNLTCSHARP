using System.Drawing;
using System.Windows.Forms;

namespace QuanLyHocVien {
    partial class BTNC1_Nhap {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            TaoLabel("lblHoTen", "Họ và Tên", 25, 24);
            this.txtHoTen = new TextBox();
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Location = new Point(100, 20);
            this.txtHoTen.Size = new Size(190, 23);
            this.txtHoTen.TabIndex = 0;
            this.Controls.Add(this.txtHoTen);

            TaoLabel("lblLop", "Lớp", 25, 60);
            this.cboLop = new ComboBox();
            this.cboLop.Name = "cboLop";
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn Lớp A hoặc Lớp B
            this.cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            this.cboLop.SelectedIndex = 0;
            this.cboLop.Location = new Point(100, 56);
            this.cboLop.Size = new Size(190, 23);
            this.cboLop.TabIndex = 1;
            this.Controls.Add(this.cboLop);

            this.btnCapNhat = TaoNut("btnCapNhat", "&Cập nhật", 100, 2);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.btnTroVe = TaoNut("btnTroVe", "&Trở về", 200, 3);
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);

            //BTNC1_Nhap
            this.AcceptButton = this.btnCapNhat; //nhấn Enter = Cập nhật
            this.CancelButton = this.btnTroVe; //nhấn Esc = Trở về
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(320, 135);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "BTNC1_Nhap";
            this.Text = "Nhập học viên mới";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label TaoLabel(string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            this.Controls.Add(lbl);
            return lbl;
        }

        private Button TaoNut(string name, string text, int x, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, 95);
            btn.Size = new Size(90, 28);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private TextBox txtHoTen;
        private ComboBox cboLop;
        private Button btnCapNhat, btnTroVe;
    }
}