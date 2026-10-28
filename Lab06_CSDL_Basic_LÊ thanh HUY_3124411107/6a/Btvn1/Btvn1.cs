using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyLop {
    public partial class Bai01 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public Bai01() {
            InitializeComponent();
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txt_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError((TextBox)sender, "");
        }

        //Báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về textbox bị lỗi
        private void BaoLoi(TextBox txt, string loi) {
            errorProvider1.SetError(txt, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt.Focus();
            txt.SelectAll();
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

        //Xóa trắng các ô, đưa con trỏ về Mã khoa
        private void LamTrong() {
            errorProvider1.Clear();
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaKhoa.Focus();
        }

        //Nút Thêm: cả 3 thông tin đều bắt buộc
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (maKhoa.Length == 0) {
                BaoLoi(txtMaKhoa, "Mã khoa không được để trống");
                return;
            }
            if (maLop.Length == 0) {
                BaoLoi(txtMaLop, "Mã lớp không được để trống");
                return;
            }
            if (tenLop.Length == 0) {
                BaoLoi(txtTenLop, "Tên lớp không được để trống");
                return;
            }

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@khoa", maKhoa),
                new SqlParameter("@lop", maLop),
                new SqlParameter("@ten", tenLop)
            };

            try {
                ThucThi("INSERT INTO Lop(MaKhoa, MaLop, TenLop) VALUES (@khoa, @lop, @ten)", ds);
                MessageBox.Show("Thêm lớp thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 2627 || ex.Number == 2601) //vi phạm khóa chính: trùng mã lớp
                    BaoLoi(txtMaLop, "Mã lớp \"" + maLop + "\" đã tồn tại");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần Mã lớp, xóa lớp có mã đó
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maLop = txtMaLop.Text.Trim();

            if (maLop.Length == 0) {
                BaoLoi(txtMaLop, "Mã lớp không được để trống");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp có mã \"" + maLop + "\"?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@lop", maLop)
            };

            try {
                int soDong = ThucThi("DELETE FROM Lop WHERE MaLop = @lop", ds);
                if (soDong == 0) {
                    BaoLoi(txtMaLop, "Không tìm thấy lớp có mã \"" + maLop + "\"");
                    return;
                }
                MessageBox.Show("Xóa lớp thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Nút Sửa: Mã lớp bắt buộc; Mã khoa, Tên lớp phải có ít nhất 1 ô có dữ liệu.
        //Ô nào có dữ liệu thì sửa, ô nào để trống thì giữ nguyên.
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (maLop.Length == 0) {
                BaoLoi(txtMaLop, "Mã lớp không được để trống");
                return;
            }
            if (maKhoa.Length == 0 && tenLop.Length == 0) {
                BaoLoi(txtMaKhoa, "Phải nhập ít nhất một trong các thông tin: Mã khoa, Tên lớp");
                return;
            }

            List<string> cacCot = new List<string>(); //các phần của mệnh đề SET
            List<SqlParameter> ds = new List<SqlParameter>();

            if (maKhoa.Length > 0) {
                cacCot.Add("MaKhoa = @khoa");
                ds.Add(new SqlParameter("@khoa", maKhoa));
            }
            if (tenLop.Length > 0) {
                cacCot.Add("TenLop = @ten");
                ds.Add(new SqlParameter("@ten", tenLop));
            }
            ds.Add(new SqlParameter("@lop", maLop));

            string sql = "UPDATE Lop SET " + string.Join(", ", cacCot) + " WHERE MaLop = @lop";

            try {
                int soDong = ThucThi(sql, ds);
                if (soDong == 0) {
                    BaoLoi(txtMaLop, "Không tìm thấy lớp có mã \"" + maLop + "\"");
                    return;
                }
                MessageBox.Show("Sửa lớp thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }
    }
}