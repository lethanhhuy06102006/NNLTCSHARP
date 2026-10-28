using System.Drawing;
using System.Windows.Forms;

namespace TuDien {
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

            //TabControl có 2 tab
            this.tabChinh = new TabControl();
            this.tabChinh.Name = "tabChinh";
            this.tabChinh.Location = new Point(12, 12);
            this.tabChinh.Size = new Size(376, 245);
            this.tabChinh.TabIndex = 0;
            this.Controls.Add(this.tabChinh);

            this.tabAnhViet = new TabPage("ANH - VIỆT");
            this.tabAnhViet.Name = "tabAnhViet";
            this.tabChinh.Controls.Add(this.tabAnhViet);

            this.tabVietAnh = new TabPage("VIỆT - ANH");
            this.tabVietAnh.Name = "tabVietAnh";
            this.tabChinh.Controls.Add(this.tabVietAnh);

            //Tab ANH - VIỆT
            TaoLabel(this.tabAnhViet, "lblTiengAnh1", "Tiếng Anh", 15, 12);
            this.cboAnh = TaoCombo(this.tabAnhViet, "cboAnh", 15, 32);
            TaoLabel(this.tabAnhViet, "lblTiengViet1", "Tiếng Việt", 205, 12);
            this.txtViet = TaoKetQua(this.tabAnhViet, "txtViet", 205, 32);

            //Tab VIỆT - ANH
            TaoLabel(this.tabVietAnh, "lblTiengViet2", "Tiếng Việt", 15, 12);
            this.cboViet = TaoCombo(this.tabVietAnh, "cboViet", 15, 32);
            TaoLabel(this.tabVietAnh, "lblTiengAnh2", "Tiếng Anh", 205, 12);
            this.txtAnh = TaoKetQua(this.tabVietAnh, "txtAnh", 205, 32);

            //Nút Thoát
            this.btnThoat = new Button();
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(298, 267);
            this.btnThoat.Size = new Size(90, 28);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.Controls.Add(this.btnThoat);

            //BTVN1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 305);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTVN1";
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.Load += new System.EventHandler(this.BTVN1_Load);
            this.FormClosing += new FormClosingEventHandler(this.BTVN1_FormClosing);
            this.ResumeLayout(false);
        }

        //Các hàm phụ tạo control
        private Label TaoLabel(Control cha, string name, string text, int x, int y) {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            cha.Controls.Add(lbl);
            return lbl;
        }

        //Combobox kiểu Simple: ô nhập có sẵn danh sách hiện ngay bên dưới
        private ComboBox TaoCombo(Control cha, string name, int x, int y) {
            ComboBox cbo = new ComboBox();
            cbo.Name = name;
            cbo.DropDownStyle = ComboBoxStyle.Simple;
            cbo.IntegralHeight = false;
            cbo.Location = new Point(x, y);
            cbo.Size = new Size(165, 175);
            cbo.TextChanged += new System.EventHandler(this.cbo_TextChanged);
            cbo.KeyDown += new KeyEventHandler(this.cbo_KeyDown);
            cbo.DoubleClick += new System.EventHandler(this.cbo_DoubleClick);
            cha.Controls.Add(cbo);
            return cbo;
        }

        //Textbox hiện kết quả tra từ: nhiều dòng, chỉ đọc
        private TextBox TaoKetQua(Control cha, string name, int x, int y) {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Multiline = true;
            txt.ReadOnly = true;
            txt.TabStop = false;
            txt.BackColor = Color.White;
            txt.Location = new Point(x, y);
            txt.Size = new Size(155, 175);
            cha.Controls.Add(txt);
            return txt;
        }

        private TabControl tabChinh;
        private TabPage tabAnhViet, tabVietAnh;
        private ComboBox cboAnh, cboViet;
        private TextBox txtViet, txtAnh;
        private Button btnThoat;
    }
}