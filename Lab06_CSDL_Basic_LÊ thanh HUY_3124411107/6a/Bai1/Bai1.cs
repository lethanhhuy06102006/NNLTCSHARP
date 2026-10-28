using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyMonHoc {
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

        //Chạy 1 câu lệnh INSERT/UPDATE/DELETE, trả về số dòng bị ảnh hưởng
        private int ThucThi(string sql, string ma, string ten) {
            using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                    //dùng tham số (@ma, @ten) thay vì ghép chuỗi để tránh lỗi SQL Injection
                    cmd.Parameters.AddWithValue("@ma", ma);
                    if (ten != null)
                        cmd.Parameters.AddWithValue("@ten", ten);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //Báo lỗi khi không làm việc được với CSDL (sai server, chưa tạo bảng...)
        private void BaoLoiCSDL(SqlException ex) {
            MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Xóa trắng 2 textbox, đưa con trỏ về Mã mh
        private void LamTrong() {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaMH.Focus();
        }

        //Nút Thêm: lưu mã môn học và tên môn học vào bảng MonHoc
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string ma = txtMaMH.Text.Trim();
            string ten = txtTenMH.Text.Trim();

            if (ma.Length == 0) {
                BaoLoi(txtMaMH, "Mã môn học không được để trống");
                return;
            }
            if (ten.Length == 0) {
                BaoLoi(txtTenMH, "Tên môn học không được để trống");
                return;
            }

            try {
                ThucThi("INSERT INTO MonHoc(MaMH, TenMH) VALUES (@ma, @ten)", ma, ten);
                MessageBox.Show("Thêm môn học thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                if (ex.Number == 2627 || ex.Number == 2601) //vi phạm khóa chính: trùng mã
                    BaoLoi(txtMaMH, "Mã môn học \"" + ma + "\" đã tồn tại");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần Mã mh, xóa môn học có mã đó
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string ma = txtMaMH.Text.Trim();

            if (ma.Length == 0) {
                BaoLoi(txtMaMH, "Mã môn học không được để trống");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học có mã \"" + ma + "\"?",
                                             "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            try {
                int soDong = ThucThi("DELETE FROM MonHoc WHERE MaMH = @ma", ma, null);
                if (soDong == 0) {
                    BaoLoi(txtMaMH, "Không tìm thấy môn học có mã \"" + ma + "\"");
                    return;
                }
                MessageBox.Show("Xóa môn học thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Nút Sửa: đổi tên môn học của môn có mã vừa nhập
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string ma = txtMaMH.Text.Trim();
            string ten = txtTenMH.Text.Trim();

            if (ma.Length == 0) {
                BaoLoi(txtMaMH, "Mã môn học không được để trống");
                return;
            }
            if (ten.Length == 0) {
                BaoLoi(txtTenMH, "Tên môn học không được để trống");
                return;
            }

            try {
                int soDong = ThucThi("UPDATE MonHoc SET TenMH = @ten WHERE MaMH = @ma", ma, ten);
                if (soDong == 0) {
                    BaoLoi(txtMaMH, "Không tìm thấy môn học có mã \"" + ma + "\"");
                    return;
                }
                MessageBox.Show("Sửa môn học thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamTrong();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }
    }
}