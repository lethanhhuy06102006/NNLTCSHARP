using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SinhVienCombo {
    public partial class Bai01 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        private const int TUOI_TOI_THIEU = 17;

        public Bai01() {
            InitializeComponent();
        }

        //Form_Load: lấy mã lớp từ bảng Lop đưa vào combobox
        private void Bai01_Load(object sender, EventArgs e) {
            try {
                using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaLop FROM Lop ORDER BY MaLop", conn)) {
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader()) {
                            while (rd.Read())
                                cboLop.Items.Add(rd.GetString(0));
                        }
                    }
                }
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
                return;
            }

            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0; //hiện sẵn lớp đầu tiên
            else
                MessageBox.Show("Bảng Lop chưa có lớp nào, hãy thêm lớp trước!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Đổi lớp thì xóa thông báo lỗi cũ
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e) {
            errorProvider1.SetError(cboLop, "");
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txt_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError((Control)sender, "");
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về ô bị lỗi
        private void BaoLoi(Control o, string loi) {
            errorProvider1.SetError(o, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            o.Focus();
        }

        //Báo lỗi khi không làm việc được với CSDL (sai server, chưa tạo bảng...)
        private void BaoLoiCSDL(SqlException ex) {
            MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Chạy 1 câu lệnh INSERT/UPDATE/DELETE, trả về số dòng bị ảnh hưởng
        private int ThucThi(string sql, List<SqlParameter> ds) {
            using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddRange(ds.ToArray());
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //Chạy câu SELECT COUNT(*), trả về số dòng đếm được
        private int DemDong(string sql, List<SqlParameter> ds) {
            using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                    cmd.Parameters.AddRange(ds.ToArray());
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        //Xóa trắng các ô nhập (giữ nguyên lớp đang chọn), đưa con trỏ về Mã sv
        private void LamTrong() {
            errorProvider1.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaSV.Focus();
        }

        //Kiểm tra tất cả thông tin đã nhập, và tuổi từ 17 trở lên (chỉ tính theo năm sinh).
        //Trả về true nếu hợp lệ, các giá trị đọc được trả qua tham số out.
        private bool KiemTraDayDu(out string maLop, out string maSV, out string hoTen, out DateTime ngay) {
            maLop = null;
            maSV = txtMaSV.Text.Trim();
            hoTen = txtHoTen.Text.Trim();
            ngay = DateTime.MinValue;

            if (cboLop.SelectedItem == null) {
                BaoLoi(cboLop, "Chưa chọn lớp");
                return false;
            }
            maLop = cboLop.SelectedItem.ToString();

            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return false;
            }
            if (hoTen.Length == 0) {
                BaoLoi(txtHoTen, "Họ tên không được để trống");
                return false;
            }
            if (txtNgaySinh.Text.Length == 0) {
                BaoLoi(txtNgaySinh, "Ngày sinh không được để trống");
                return false;
            }
            if (!DateTime.TryParseExact(txtNgaySinh.Text, "ddMMyyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out ngay)) {
                BaoLoi(txtNgaySinh, "Ngày sinh không hợp lệ (định dạng dd/MM/yyyy)");
                return false;
            }
            if (DateTime.Today.Year - ngay.Year < TUOI_TOI_THIEU) { //chỉ so sánh năm, không xét tháng ngày
                BaoLoi(txtNgaySinh, "Sinh viên phải từ " + TUOI_TOI_THIEU + " tuổi trở lên (tính theo năm sinh)");
                return false;
            }
            return true;
        }

        //Nút Thêm
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            if (!KiemTraDayDu(out string maLop, out string maSV, out string hoTen, out DateTime ngay))
                return;

            try {
                //kiểm tra khóa chính: mã sinh viên đã có trong bảng chưa
                int daCo = DemDong("SELECT COUNT(*) FROM SinhVien WHERE MaSV = @ma",
                                   new List<SqlParameter> { new SqlParameter("@ma", maSV) });
                if (daCo > 0) {
                    BaoLoi(txtMaSV, "Mã sinh viên \"" + maSV + "\" đã tồn tại trong bảng SinhVien");
                    return;
                }

                List<SqlParameter> ds = new List<SqlParameter> {
                    new SqlParameter("@lop", maLop),
                    new SqlParameter("@ma", maSV),
                    new SqlParameter("@ten", hoTen),
                    new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay }
                };
                ThucThi("INSERT INTO SinhVien(MaLop, MaSV, HoTen, NgaySinh) VALUES (@lop, @ma, @ten, @ngay)", ds);
                MessageBox.Show("Thêm sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 547) //vi phạm khóa ngoại: mã lớp không có trong bảng Lop
                    BaoLoi(cboLop, "Mã lớp \"" + maLop + "\" không tồn tại trong bảng Lop");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần Mã sv. Kiểm tra sinh viên có tồn tại và chưa có điểm (khóa ngoại) mới cho xóa.
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maSV = txtMaSV.Text.Trim();

            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return;
            }

            try {
                List<SqlParameter> tim = new List<SqlParameter> { new SqlParameter("@ma", maSV) };

                //kiểm tra khóa chính: có sinh viên này không
                if (DemDong("SELECT COUNT(*) FROM SinhVien WHERE MaSV = @ma", tim) == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy sinh viên có mã \"" + maSV + "\"");
                    return;
                }

                //kiểm tra khóa ngoại: bảng Diem đang tham chiếu đến sinh viên này không
                if (CoDiem(maSV)) {
                    BaoLoi(txtMaSV, "Sinh viên \"" + maSV + "\" đã có điểm trong bảng Diem, phải xóa điểm trước");
                    return;
                }

                DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên \"" + maSV + "\"?",
                                                 "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;

                ThucThi("DELETE FROM SinhVien WHERE MaSV = @ma", new List<SqlParameter> { new SqlParameter("@ma", maSV) });
                MessageBox.Show("Xóa sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 547) //còn bảng khác tham chiếu đến sinh viên này
                    BaoLoi(txtMaSV, "Không xóa được vì sinh viên này đang được bảng khác sử dụng (vi phạm khóa ngoại)");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Sinh viên đã có điểm trong bảng Diem chưa. Chưa tạo bảng Diem (lỗi 208) thì coi như chưa có.
        private bool CoDiem(string maSV) {
            try {
                return DemDong("SELECT COUNT(*) FROM Diem WHERE MaSV = @ma",
                               new List<SqlParameter> { new SqlParameter("@ma", maSV) }) > 0;
            }
            catch (SqlException ex) {
                if (ex.Number == 208) //Invalid object name: không có bảng Diem
                    return false;
                throw;
            }
        }

        //Nút Sửa: sinh viên phải tồn tại (khóa chính), lớp mới phải có trong bảng Lop (khóa ngoại)
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            if (!KiemTraDayDu(out string maLop, out string maSV, out string hoTen, out DateTime ngay))
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@lop", maLop),
                new SqlParameter("@ten", hoTen),
                new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay },
                new SqlParameter("@ma", maSV)
            };

            try {
                int soDong = ThucThi("UPDATE SinhVien SET MaLop = @lop, HoTen = @ten, NgaySinh = @ngay WHERE MaSV = @ma", ds);
                if (soDong == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy sinh viên có mã \"" + maSV + "\"");
                    return;
                }
                MessageBox.Show("Sửa sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 547) //vi phạm khóa ngoại: mã lớp không có trong bảng Lop
                    BaoLoi(cboLop, "Mã lớp \"" + maLop + "\" không tồn tại trong bảng Lop");
                else
                    BaoLoiCSDL(ex);
            }
        }
    }
}