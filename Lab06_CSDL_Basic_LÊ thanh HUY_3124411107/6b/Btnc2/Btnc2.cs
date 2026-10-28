using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DanhSachDiem {
    public partial class BTNC2 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public BTNC2() {
            InitializeComponent();
        }

        //Form_Load: đưa mã môn học vào combobox (thêm 1 mục trống), rồi hiện tất cả điểm lên listview
        private void BTNC2_Load(object sender, EventArgs e) {
            try {
                cboMonHoc.Items.Add(""); //mục khoảng trắng = tất cả môn học
                using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaMH FROM MonHoc ORDER BY MaMH", conn)) {
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader()) {
                            while (rd.Read())
                                cboMonHoc.Items.Add(rd.GetString(0));
                        }
                    }
                }
                cboMonHoc.SelectedIndex = 0; //chọn sẵn mục trống
                HienThi("");
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Báo lỗi khi không làm việc được với CSDL (sai server, chưa tạo bảng...)
        private void BaoLoiCSDL(SqlException ex) {
            MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Hiện điểm lên listview: maMH rỗng thì hiện tất cả môn, ngược lại chỉ hiện môn có mã đó.
        //Đồng thời cộng tổng cột Điểm đang hiển thị.
        private void HienThi(string maMH) {
            //nối 3 bảng: điểm -> sinh viên (lấy tên, ngày sinh) và -> môn học (lấy tên môn)
            string sql = "SELECT sv.HoTen, sv.NgaySinh, mh.TenMH, d.Diem " +
                         "FROM Diem d " +
                         "JOIN SinhVien sv ON d.MaSV = sv.MaSV " +
                         "JOIN MonHoc mh ON d.MaMH = mh.MaMH " +
                         "WHERE (@mh = '' OR d.MaMH = @mh) " + //@mh rỗng thì điều kiện luôn đúng, lấy hết
                         "ORDER BY sv.MaSV, mh.MaMH";

            decimal tong = 0;
            try {
                lvDiem.BeginUpdate();
                lvDiem.Items.Clear(); //xóa dữ liệu cũ trước khi nạp lại

                using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                        cmd.Parameters.AddWithValue("@mh", maMH);
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader()) {
                            int stt = 0;
                            while (rd.Read()) {
                                stt++;
                                decimal diem = Convert.ToDecimal(rd["Diem"]);
                                tong += diem;

                                ListViewItem dong = new ListViewItem(stt.ToString()); //cột 0: STT
                                dong.SubItems.Add(rd["HoTen"].ToString());
                                dong.SubItems.Add(Convert.ToDateTime(rd["NgaySinh"]).ToString("dd/MM/yyyy"));
                                dong.SubItems.Add(rd["TenMH"].ToString());
                                dong.SubItems.Add(diem.ToString("0.##", CultureInfo.InvariantCulture)); //7 hiện "7", 8.5 hiện "8.5"
                                lvDiem.Items.Add(dong);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
            finally {
                lvDiem.EndUpdate();
            }

            txtTongDiem.Text = tong.ToString("0.##", CultureInfo.InvariantCulture);
        }

        //Nút Lọc dữ liệu: chọn mục trống thì hiện tất cả, chọn một mã môn thì chỉ hiện môn đó
        private void btnLoc_Click(object sender, EventArgs e) {
            string maMH = cboMonHoc.SelectedItem == null ? "" : cboMonHoc.SelectedItem.ToString();
            HienThi(maMH);

            if (lvDiem.Items.Count == 0)
                MessageBox.Show("Không có dữ liệu điểm phù hợp", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}