using System.Drawing;
using System.Windows.Forms;

namespace XuLyChuoi {
    partial class BTNC1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            //Nút Nhập tên ngẫu nhiên
            this.btnNgauNhien = TaoNut("btnNgauNhien", "Nhập tên ngẫu nhiên", 12, 12, 160, 32, 0);
            this.btnNgauNhien.Click += new System.EventHandler(this.btnNgauNhien_Click);

            //ListBox cho phép chọn nhiều phần tử (Ctrl, Shift)
            this.lstTen = new ListBox();
            this.lstTen.Name = "lstTen";
            this.lstTen.SelectionMode = SelectionMode.MultiExtended;
            this.lstTen.IntegralHeight = false;
            this.lstTen.Location = new Point(12, 55);
            this.lstTen.Size = new Size(190, 294);
            this.lstTen.TabIndex = 1;
            this.lstTen.MouseDoubleClick += new MouseEventHandler(this.lstTen_MouseDoubleClick);
            this.Controls.Add(this.lstTen);

            //Cột nút bên phải
            this.btnXoaChon = TaoNut("btnXoaChon", "Xóa Phần tử đang chọn", 215, 55, 255, 36, 2);
            this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);

            this.btnXoaSon = TaoNut("btnXoaSon", "Xóa phần tử có tên là Sơn", 215, 98, 255, 36, 3);
            this.btnXoaSon.Click += new System.EventHandler(this.btnXoaSon_Click);

            this.btnXoaLe = TaoNut("btnXoaLe", "Xóa Phần tử có họ là Lê", 215, 141, 255, 36, 4);
            this.btnXoaLe.Click += new System.EventHandler(this.btnXoaLe_Click);

            this.btnHoa = TaoNut("btnHoa", "Chuyển PT đang chọn thành chữ HOA", 215, 184, 255, 36, 5);
            this.btnHoa.Click += new System.EventHandler(this.btnHoa_Click);

            this.btnThuong = TaoNut("btnThuong", "Chuyển PT đang chọn thành chữ thường", 215, 227, 255, 36, 6);
            this.btnThuong.Click += new System.EventHandler(this.btnThuong_Click);

            this.btnHoaDauTu = TaoNut("btnHoaDauTu", "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ", 215, 270, 255, 36, 7);
            this.btnHoaDauTu.Click += new System.EventHandler(this.btnHoaDauTu_Click);

            this.btnXoaTatCa = TaoNut("btnXoaTatCa", "Xóa tất cả các Phần tử", 215, 313, 255, 36, 8);
            this.btnXoaTatCa.Click += new System.EventHandler(this.btnXoaTatCa_Click);

            //BTNC1
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(482, 362);
            this.Font = new Font("Tahoma", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "BTNC1";
            this.Text = "frmChuoi";
            this.ResumeLayout(false);
        }

        //Hàm phụ tạo nút
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

        private ListBox lstTen;
        private Button btnNgauNhien, btnXoaChon, btnXoaSon, btnXoaLe;
        private Button btnHoa, btnThuong, btnHoaDauTu, btnXoaTatCa;
    }
}