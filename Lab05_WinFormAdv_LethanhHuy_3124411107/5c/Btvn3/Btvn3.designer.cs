using System.Drawing;
using System.Windows.Forms;

namespace DanhBa {
    partial class BTVN3 {
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

            //TreeView bên trái
            this.tvDanhBa = new TreeView();
            this.tvDanhBa.Name = "tvDanhBa";
            this.tvDanhBa.Location = new Point(12, 12);
            this.tvDanhBa.Size = new Size(170, 245);
            this.tvDanhBa.TabStop = false;
            this.Controls.Add(this.tvDanhBa);

            //Khung nhập tên bên phải
            TaoLabel("lblFirstName", "First Name", 205, 32);
            this.txtFirstName = TaoText("txtFirstName", 280, 28, 125, 0);
            TaoLabel("lblLastName", "Last Name", 205, 67);
            this.txtLastName = TaoText("txtLastName", 280, 63, 125, 1);

            this.btnAdd = TaoNut("btnAdd", "Add", 330, 100, 75, 26, 2);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnExit = TaoNut("btnExit", "Exit", 330, 150, 75, 26, 3);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //BTVN3
            this.AcceptButton = this.btnAdd; //nhấn Enter = bấm Add
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(425, 270);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTVN3";
            this.Text = "frmBTVN3";
            this.Load += new System.EventHandler(this.BTVN3_Load);
            this.FormClosing += new FormClosingEventHandler(this.BTVN3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //Các hàm phụ tạo control
        private Label TaoLabel(string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            this.Controls.Add(lbl);
            return lbl;
        }

        private TextBox TaoText(string name, int x, int y, int w, int tab) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Location = new Point(x, y);
            txt.Size = new Size(w, 23);
            txt.TabIndex = tab;
            txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.Controls.Add(txt);
            return txt;
        }

        private Button TaoNut(string name, string text, int x, int y, int w, int h, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private TreeView tvDanhBa;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;
    }
}