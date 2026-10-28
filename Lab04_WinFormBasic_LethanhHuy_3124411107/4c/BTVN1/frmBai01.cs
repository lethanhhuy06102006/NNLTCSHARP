using System;
using System.Globalization;
using System.Windows.Forms;

namespace Bai01 {
    public partial class frmBai01 : Form {
        private double so1 = 0; //số thứ nhất (đã nhập trước khi bấm phép toán)
        private char phepToan = ' '; //phép toán đang chờ: + - * / (dấu cách = chưa có)
        private bool nhapMoi = true; //true: số bấm tiếp theo sẽ bắt đầu một số mới trên màn hình

        public frmBai01() {
            InitializeComponent();
        }

        //Đọc số đang hiện trên màn hình
        private double SoTrenManHinh() {
            return double.Parse(txtManHinh.Text, CultureInfo.InvariantCulture);
        }

        private void HienSo(double x) {
            txtManHinh.Text = x.ToString(CultureInfo.InvariantCulture);
        }

        //Bấm nút số 0..9
        private void btnSo_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;

            if (nhapMoi || txtManHinh.Text == "0") {
                txtManHinh.Text = btn.Text; //bắt đầu số mới
                nhapMoi = false;
            }
            else if (txtManHinh.Text.Length < 15) { //giới hạn 15 chữ số
                txtManHinh.Text += btn.Text; //ghép thêm chữ số vào sau
            }
        }

        //Bấm nút + - * /
        private void btnPhepToan_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;

            //Nếu đang có phép toán chờ mà đã nhập số thứ 2 thì tính luôn (vd: 2 + 3 + ...)
            if (phepToan != ' ' && !nhapMoi) {
                if (!TinhKetQua())
                    return;
            }

            so1 = SoTrenManHinh();
            phepToan = btn.Text[0]; //lấy ký tự trên nút: '+', '-', '*', '/'
            nhapMoi = true;
        }

        //Bấm nút =
        private void btnBang_Click(object sender, EventArgs e) {
            if (phepToan == ' ') //chưa chọn phép toán thì không làm gì
                return;

            if (TinhKetQua()) {
                phepToan = ' ';
                nhapMoi = true;
            }
        }

        //Tính so1 (phepToan) số trên màn hình, hiện kết quả. Trả về false nếu lỗi.
        private bool TinhKetQua() {
            double so2 = SoTrenManHinh();
            double kq = 0;

            switch (phepToan) {
                case '+': kq = so1 + so2; break;
                case '-': kq = so1 - so2; break;
                case '*': kq = so1 * so2; break;
                case '/':
                    if (so2 == 0) {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        XoaHet();
                        return false;
                    }
                    kq = so1 / so2;
                    break;
            }

            HienSo(kq);
            so1 = kq;
            nhapMoi = true;
            return true;
        }

        //Bấm nút C: xóa hết, về trạng thái ban đầu
        private void btnXoa_Click(object sender, EventArgs e) {
            XoaHet();
        }

        private void XoaHet() {
            so1 = 0;
            phepToan = ' ';
            nhapMoi = true;
            txtManHinh.Text = "0";
        }
    }
}