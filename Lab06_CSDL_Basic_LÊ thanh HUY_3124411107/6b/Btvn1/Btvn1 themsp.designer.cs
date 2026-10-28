using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHang {
    partial class BTVN1_ThemSP {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            //Tên sản phẩm
            this.lblTenSP = new Label();
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Text = "Tên sản phẩm";
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new Point(30, 34);
            this.Controls.Add(this.lblTenSP);

            this.txtTenSP = new TextBox();
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.MaxLength = 100; //khớp độ dài cột TenSP
            this.txtTenSP.Location = new Point(125, 30);
            this.txtTenSP.Size = new Size(190, 23);
            this.txtTenSP.TabIndex = 0;
            this.txtTenSP.TextChanged += new System.EventHandler(this.txtTenSP_TextChanged);
            this.Controls.Add(this.txtTenSP);

            //2 nút
            this.btnThem = new Button();
            this.btnThem.Name = "btnThem";
            this.btnThem.Text = "&Thêm";
            this.btnThem.Location = new Point(70, 80);
            this.btnThem.Size = new Size(85, 28);
            this.btnThem.TabIndex = 1;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.Controls.Add(this.btnThem);

            this.btnThoat = new Button();
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "T&hoát";
            this.btnThoat.Location = new Point(190, 80);
            this.btnThoat.Size = new Size(85, 28);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.Controls.Add(this.btnThoat);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //BTVN1_ThemSP
            this.AcceptButton = this.btnThem; //nhấn Enter = Thêm
            this.CancelButton = this.btnThoat; //nhấn Esc = Thoát
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(345, 130);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "BTVN1_ThemSP";
            this.Text = "Thêm sản phẩm mới";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ErrorProvider errorProvider1;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Button btnThem, btnThoat;
    }
}