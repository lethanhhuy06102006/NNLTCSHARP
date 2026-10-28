using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyDiem {
    public partial class Bai02 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public Bai02() {
            InitializeComponent();
        }

        //Điểm chỉ cho gõ chữ số và tối đa 1 dấu thập phân (. hoặc ,)
        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && txtDiem.Text.IndexOfAny(new char[] { '.', ',' }) < 0)
                return;
            e.Handled = true;
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

        //Xóa trắng các ô, đưa con trỏ về Mã sv
        private void LamTrong() {
            errorProvider1.Clear();
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtDiem.Clear();
            txtMaSV.Focus();
        }

        //Kiểm tra Mã sv và Mã mh không trống, true nếu hợp lệ
        private bool KiemTraMa(string maSV, string maMH) {
            if (maSV.Length == 0) {
                BaoLoi(txtMaSV, "Mã sinh viên không được để trống");
                return false;
            }
            if (maMH.Length == 0) {
                BaoLoi(txtMaMH, "Mã môn học không được để trống");
                return false;
            }
            return true;
        }

        //Đọc điểm từ textbox, phải nhập, là số và nằm trong khoảng 0 - 10
        private bool DocDiem(out decimal diem) {
            diem = 0;
            string s = txtDiem.Text.Trim().Replace(',', '.'); //cho phép gõ 8,5 hoặc 8.5
            if (s.Length == 0) {
                BaoLoi(txtDiem, "Điểm không được để trống");
                return false;
            }
            if (!decimal.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out diem)) {
                BaoLoi(txtDiem, "Điểm phải là số");
                return false;
            }
            if (diem < 0 || diem > 10) {
                BaoLoi(txtDiem, "Điểm phải nằm trong khoảng từ 0 đến 10");
                return false;
            }
            diem = Math.Round(diem, 2); //khớp cột DECIMAL(4,2)
            return true;
        }

        //Nút Thêm: cả 3 thông tin đều bắt buộc
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();

            if (!KiemTraMa(maSV, maMH))
                return;
            if (!DocDiem(out decimal diem))
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@sv", maSV),
                new SqlParameter("@mh", maMH),
                new SqlParameter("@diem", diem)
            };

            try {
                ThucThi("INSERT INTO Diem(MaSV, MaMH, Diem) VALUES (@sv, @mh, @diem)", ds);
                MessageBox.Show("Thêm điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 2627 || ex.Number == 2601) //trùng khóa chính (MaSV, MaMH)
                    BaoLoi(txtMaSV, "Sinh viên \"" + maSV + "\" đã có điểm môn \"" + maMH + "\"");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần Mã sv và Mã mh, xóa dòng điểm tương ứng
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();

            if (!KiemTraMa(maSV, maMH))
                return;

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm môn \"" + maMH + "\" của sinh viên \"" + maSV + "\"?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@sv", maSV),
                new SqlParameter("@mh", maMH)
            };

            try {
                int soDong = ThucThi("DELETE FROM Diem WHERE MaSV = @sv AND MaMH = @mh", ds);
                if (soDong == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy điểm của sinh viên và môn học này");
                    return;
                }
                MessageBox.Show("Xóa điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Nút Sửa: đổi điểm của sinh viên theo môn học
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string maSV = txtMaSV.Text.Trim();
            string maMH = txtMaMH.Text.Trim();

            if (!KiemTraMa(maSV, maMH))
                return;
            if (!DocDiem(out decimal diem))
                return;

            List<SqlParameter> ds = new List<SqlParameter> {
                new SqlParameter("@diem", diem),
                new SqlParameter("@sv", maSV),
                new SqlParameter("@mh", maMH)
            };

            try {
                int soDong = ThucThi("UPDATE Diem SET Diem = @diem WHERE MaSV = @sv AND MaMH = @mh", ds);
                if (soDong == 0) {
                    BaoLoi(txtMaSV, "Không tìm thấy điểm của sinh viên và môn học này");
                    return;
                }
                MessageBox.Show("Sửa điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }
    }
}