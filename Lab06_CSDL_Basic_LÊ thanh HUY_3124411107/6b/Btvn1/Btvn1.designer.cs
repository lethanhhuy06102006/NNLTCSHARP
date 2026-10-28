using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHang {
    partial class BTVN1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //Thanh menu chứa các chức năng
            this.menuStrip1 = new MenuStrip();
            this.mnuTaoTonKho = new ToolStripMenuItem("&Tạo tồn kho");
            this.mnuThemSP = new ToolStripMenuItem("Thêm sản &phẩm mới");
            this.mnuTaoTonKho.Click += new System.EventHandler(this.mnuTaoTonKho_Click);
            this.mnuThemSP.Click += new System.EventHandler(this.mnuThemSP_Click);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuTaoTonKho, this.mnuThemSP });
            this.menuStrip1.Name = "menuStrip1";
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);

            //BTVN1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(520, 300);
            this.Font = new Font("Tahoma", 8.5F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTVN1";
            this.Text = "Quản lý cửa hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuTaoTonKho, mnuThemSP;
    }
}