using System.Drawing;
using System.Windows.Forms;

namespace BTVN_Tuan6 {
    partial class Bai01 {
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

            //Họ và tên, Mã sinh viên
            TaoLabel("lblHoTen", "Họ và Tên", 70, 28);
            this.txtHoTen = TaoText("txtHoTen", 190, 25, 250, 0);
            TaoLabel("lblMaSV", "Mã sinh viên", 70, 68);
            this.txtMaSV = TaoText("txtMaSV", 190, 65, 250, 1);

            //Giới tính
            TaoLabel("lblGioiTinh", "Giới tính", 70, 108);
            this.radNam = new RadioButton();
            this.radNam.Name = "radNam";
            this.radNam.Text = "Nam";
            this.radNam.Checked = true;
            this.radNam.AutoSize = true;
            this.radNam.Location = new Point(190, 106);
            this.radNam.TabIndex = 2;
            this.Controls.Add(this.radNam);

            this.radNu = new RadioButton();
            this.radNu.Name = "radNu";
            this.radNu.Text = "Nữ";
            this.radNu.AutoSize = true;
            this.radNu.Location = new Point(300, 106);
            this.radNu.TabIndex = 3;
            this.Controls.Add(this.radNu);

            //Ngoại ngữ
            TaoLabel("lblNgoaiNgu", "Ngoại ngữ", 70, 148);
            this.chkAnh = TaoCheck("chkAnh", "Anh", 190, 146, 4);
            this.chkAnh.Checked = true;
            this.chkPhap = TaoCheck("chkPhap", "Pháp", 270, 146, 5);
            this.chkHoa = TaoCheck("chkHoa", "Hoa", 350, 146, 6);

            //Dân tộc
            TaoLabel("lblDanToc", "Dân tộc", 70, 188);
            this.cboDanToc = new ComboBox();
            this.cboDanToc.Name = "cboDanToc";
            this.cboDanToc.DropDownStyle = ComboBoxStyle.DropDownList; //chỉ chọn, không gõ
            this.cboDanToc.Location = new Point(190, 185);
            this.cboDanToc.Size = new Size(250, 23);
            this.cboDanToc.TabIndex = 7;
            this.Controls.Add(this.cboDanToc);

            //ListView
            this.lvSV = new ListView();
            this.lvSV.Name = "lvSV";
            this.lvSV.View = View.Details; //hiện dạng bảng có tiêu đề cột
            this.lvSV.FullRowSelect = true; //bấm vào đâu cũng chọn cả dòng
            this.lvSV.GridLines = true;
            this.lvSV.MultiSelect = false;
            this.lvSV.HideSelection = false; //mất focus vẫn thấy dòng đang chọn
            this.lvSV.Location = new Point(15, 225);
            this.lvSV.Size = new Size(490, 140);
            this.lvSV.TabIndex = 8;
            this.lvSV.Columns.Add("Họ tên", 140);
            this.lvSV.Columns.Add("Mã sinh viên", 90);
            this.lvSV.Columns.Add("Giới tính", 65);
            this.lvSV.Columns.Add("Ngoại ngữ", 110);
            this.lvSV.Columns.Add("Dân tộc", 80);
            this.lvSV.SelectedIndexChanged += new System.EventHandler(this.lvSV_SelectedIndexChanged);
            this.lvSV.MouseDown += new MouseEventHandler(this.lvSV_MouseDown);
            this.Controls.Add(this.lvSV);

            //ContextMenuStrip: bấm chuột phải vào ListView để Xóa
            this.ctmLV = new ContextMenuStrip(this.components);
            this.mnuXoa = new ToolStripMenuItem("Xóa");
            this.mnuXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.ctmLV.Items.Add(this.mnuXoa);
            this.ctmLV.Opening += new System.ComponentModel.CancelEventHandler(this.ctmLV_Opening);
            this.lvSV.ContextMenuStrip = this.ctmLV;

            //3 nút Thêm, Xóa, Sửa
            this.btnThem = TaoNut("btnThem", "&Thêm", 110, 378, 9);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa = TaoNut("btnXoa", "&Xóa", 215, 378, 10);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua = TaoNut("btnSua", "&Sửa", 320, 378, 11);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            //errorProvider1
            this.errorProvider1.ContainerControl = this;

            //Bai01
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(520, 425);
            this.Font = new Font("Tahoma", 8.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Bai01";
            this.Text = "frmBaitap1";
            this.Load += new System.EventHandler(this.Bai01_Load);
            this.FormClosing += new FormClosingEventHandler(this.Bai01_FormClosing);
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

        private CheckBox TaoCheck(string name, string text, int x, int y, int tab) {
            CheckBox chk = new CheckBox();
            chk.Name = name;
            chk.Text = text;
            chk.AutoSize = true;
            chk.Location = new Point(x, y);
            chk.TabIndex = tab;
            this.Controls.Add(chk);
            return chk;
        }

        private Button TaoNut(string name, string text, int x, int y, int tab) {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(90, 32);
            btn.TabIndex = tab;
            this.Controls.Add(btn);
            return btn;
        }

        private ErrorProvider errorProvider1;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton radNam, radNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lvSV;
        private ContextMenuStrip ctmLV;
        private ToolStripMenuItem mnuXoa;
        private Button btnThem, btnXoa, btnSua;
    }
}