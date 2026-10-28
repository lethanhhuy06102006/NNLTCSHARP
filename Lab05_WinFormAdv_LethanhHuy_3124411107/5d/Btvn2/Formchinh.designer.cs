using System.Drawing;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    partial class FormChinh {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //MenuStrip: mỗi mục mở một bài tập
            this.menuStrip1 = new MenuStrip();
            this.mnuBai1 = new ToolStripMenuItem("Bài &1");
            this.mnuBai2 = new ToolStripMenuItem("Bài &2");
            this.mnuNangCao = new ToolStripMenuItem("Bài &nâng cao");
            this.mnuBai1.Click += new System.EventHandler(this.mnuBai1_Click);
            this.mnuBai2.Click += new System.EventHandler(this.mnuBai2_Click);
            this.mnuNangCao.Click += new System.EventHandler(this.mnuNangCao_Click);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuBai1, this.mnuBai2, this.mnuNangCao });
            this.menuStrip1.Name = "menuStrip1";
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.menuStrip1);

            //FormChinh
            this.IsMdiContainer = true; //cho phép chứa các form con bên trong
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(760, 520);
            this.Font = new Font("Tahoma", 8.5F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "FormChinh";
            this.Text = "BTVN_Tuan6";
            this.FormClosing += new FormClosingEventHandler(this.FormChinh_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuBai1, mnuBai2, mnuNangCao;
    }
}