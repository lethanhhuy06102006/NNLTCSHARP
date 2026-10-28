using System;
using System.Windows.Forms;

namespace DongHo {
    public partial class Bai01 : Form {
        private const int TONG_GIAY = 30 * 60; //30 phút
        private int conLai = TONG_GIAY; //số giây còn lại

        public Bai01() {
            InitializeComponent();
        }

        //Hiện số giây còn lại dạng phút:giây, ví dụ 29:05
        private void HienThoiGian() {
            int phut = conLai / 60;
            int giay = conLai % 60;
            lblThoiGian.Text = phut.ToString("00") + ":" + giay.ToString("00");
        }

        //Nút Bắt đầu: chạy đếm ngược. Bấm khi đang chạy thì tạm dừng, bấm tiếp thì chạy tiếp.
        private void btnBatDau_Click(object sender, EventArgs e) {
            if (tmrDemNguoc.Enabled) {
                tmrDemNguoc.Stop();
                btnBatDau.Text = "&Tiếp tục";
            }
            else {
                tmrDemNguoc.Start();
                btnBatDau.Text = "&Tạm dừng";
            }
        }

        //Mỗi giây giảm 1 và cập nhật nhãn
        private void tmrDemNguoc_Tick(object sender, EventArgs e) {
            conLai--;
            HienThoiGian();

            if (conLai <= 0) {
                tmrDemNguoc.Stop();
                MessageBox.Show("Hết giờ!", "Đồng hồ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conLai = TONG_GIAY; //về lại 30:00 để bắt đầu lượt mới
                HienThoiGian();
                btnBatDau.Text = "&Bắt đầu";
            }
        }
    }
}