using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVienSQL {
    public partial class BTNC1 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public BTNC1() {
            InitializeComponent();
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

        //Xóa trắng các ô nhập, đưa con trỏ về Mã lớp
        private void LamTrong() {
            errorProvider1.Clear();
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaLop.Focus();
        }

        //Ô ngày sinh đã gõ gì chưa (Text chỉ chứa các chữ số nên rỗng là chưa gõ)
        private bool NgaySinhRong() {
            return txtNgaySinh.Text.Length == 0;
        }

        //Đọc ngày sinh dạng ddMMyyyy, trả về false nếu chưa gõ đủ hoặc ngày không có thật (vd 31/02/2000)
        private bool DocNgaySinh(out DateTime ngay) {
            return DateTime.TryParseExact(txtNgaySinh.Text, "ddMMyyyy", CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out ngay);
        }

        //Nút Thêm: cả 4 thông tin đều bắt buộc
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (maLop.Length == 0) {
                BaoLoi(txtMaLop, "Mã lớp không được để trống");
                return;
            }
            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return;
            }
            if (hoTen.Length == 0) {
                BaoLoi(txtHoTen, "Tên sinh viên không được để trống");
                return;
            }
            if (NgaySinhRong()) {
                BaoLoi(txtNgaySinh, "Ngày sinh không được để trống");
                return;
            }
            if (!DocNgaySinh(out DateTime ngay)) {
                BaoLoi(txtNgaySinh, "Ngày sinh không hợp lệ (định dạng dd/MM/yyyy)");
                return;
            }

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@lop", maLop),
                new SqlParameter("@ma", maSV),
                new SqlParameter("@ten", hoTen),
                new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay }
            };

            try {
                ThucThi("INSERT INTO SinhVien(MaLop, MaSV, HoTen, NgaySinh) VALUES (@lop, @ma, @ten, @ngay)", ds);
                MessageBox.Show("Thêm sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 2627 || ex.Number == 2601) //vi phạm khóa chính: trùng mã sinh viên
                    BaoLoi(txtMaSV, "Mã sinh viên \"" + maSV + "\" đã tồn tại");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần Mã sinh viên và Tên sinh viên, xóa sinh viên có cả mã và tên trùng khớp
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return;
            }
            if (hoTen.Length == 0) {
                BaoLoi(txtHoTen, "Tên sinh viên không được để trống");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên \"" + hoTen + "\" (" + maSV + ")?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@ma", maSV),
                new SqlParameter("@ten", hoTen)
            };

            try {
                int soDong = ThucThi("DELETE FROM SinhVien WHERE MaSV = @ma AND HoTen = @ten", ds);
                if (soDong == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy sinh viên có mã và tên như trên");
                    return;
                }
                MessageBox.Show("Xóa sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Nút Sửa: Mã sinh viên bắt buộc; Mã lớp, Họ tên, Ngày sinh phải có ít nhất 1 ô có dữ liệu.
        //Ô nào có dữ liệu thì sửa, ô nào để trống thì giữ nguyên.
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return;
            }
            if (maLop.Length == 0 && hoTen.Length == 0 && NgaySinhRong()) {
                BaoLoi(txtMaLop, "Phải nhập ít nhất một trong các thông tin: Mã lớp, Họ tên, Ngày sinh");
                return;
            }

            List<string> cacCot = new List<string>(); //các phần của mệnh đề SET
            List<SqlParameter> ds = new List<SqlParameter>();

            if (maLop.Length > 0) {
                cacCot.Add("MaLop = @lop");
                ds.Add(new SqlParameter("@lop", maLop));
            }
            if (hoTen.Length > 0) {
                cacCot.Add("HoTen = @ten");
                ds.Add(new SqlParameter("@ten", hoTen));
            }
            if (!NgaySinhRong()) {
                if (!DocNgaySinh(out DateTime ngay)) {
                    BaoLoi(txtNgaySinh, "Ngày sinh không hợp lệ (định dạng dd/MM/yyyy)");
                    return;
                }
                cacCot.Add("NgaySinh = @ngay");
                ds.Add(new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay });
            }
            ds.Add(new SqlParameter("@ma", maSV));

            string sql = "UPDATE SinhVien SET " + string.Join(", ", cacCot) + " WHERE MaSV = @ma";

            try {
                int soDong = ThucThi(sql, ds);
                if (soDong == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy sinh viên có mã \"" + maSV + "\"");
                    return;
                }
                MessageBox.Show("Sửa sinh viên thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }
    }
}