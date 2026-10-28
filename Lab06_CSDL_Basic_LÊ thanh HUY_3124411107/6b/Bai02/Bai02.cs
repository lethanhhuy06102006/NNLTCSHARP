using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DiemCombo {
    public partial class Bai02 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public Bai02() {
            InitializeComponent();
        }

        //Form_Load: đưa mã sinh viên và mã môn học từ CSDL vào 2 combobox
        private void Bai02_Load(object sender, EventArgs e) {
            try {
                NapCombo(cboSinhVien, "SELECT MaSV FROM SinhVien ORDER BY MaSV", "Bảng SinhVien chưa có sinh viên nào!");
                NapCombo(cboMonHoc, "SELECT MaMH FROM MonHoc ORDER BY MaMH", "Bảng MonHoc chưa có môn học nào!");
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Chạy câu SELECT 1 cột và đưa kết quả vào combobox
        private void NapCombo(ComboBox cbo, string sql, string thongBaoRong) {
            cbo.Items.Clear();
            using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader()) {
                        while (rd.Read())
                            cbo.Items.Add(rd.GetString(0));
                    }
                }
            }

            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
            else
                MessageBox.Show(thongBaoRong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Điểm chỉ cho gõ chữ số và tối đa 1 dấu thập phân (. hoặc ,)
        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && txtDiem.Text.IndexOfAny(new char[] { '.', ',' }) < 0)
                return;
            e.Handled = true;
        }

        //Chọn lại combobox / gõ lại điểm thì xóa thông báo lỗi cũ
        private void cbo_SelectedIndexChanged(object sender, EventArgs e) {
            errorProvider1.SetError((Control)sender, "");
        }

        private void txtDiem_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError(txtDiem, "");
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

        //Kiểm tra đã chọn sinh viên và môn học chưa, đọc 2 mã. true nếu hợp lệ.
        private bool DocMa(out string maSV, out string maMH) {
            maSV = null;
            maMH = null;
            if (cboSinhVien.SelectedItem == null) {
                BaoLoi(cboSinhVien, "Chưa chọn sinh viên");
                return false;
            }
            if (cboMonHoc.SelectedItem == null) {
                BaoLoi(cboMonHoc, "Chưa chọn môn học");
                return false;
            }
            maSV = cboSinhVien.SelectedItem.ToString();
            maMH = cboMonHoc.SelectedItem.ToString();
            return true;
        }

        //Đọc điểm: phải nhập, là số và nằm trong khoảng 0 - 10
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

        //Kiểm tra khóa ngoại: mã sinh viên và mã môn học phải có trong CSDL
        private bool KiemTraTonTai(string maSV, string maMH) {
            int sv = DemDong("SELECT COUNT(*) FROM SinhVien WHERE MaSV = @ma",
                             new List<SqlParameter> { new SqlParameter("@ma", maSV) });
            if (sv == 0) {
                BaoLoi(cboSinhVien, "Mã sinh viên \"" + maSV + "\" không tồn tại trong bảng SinhVien");
                return false;
            }
            int mh = DemDong("SELECT COUNT(*) FROM MonHoc WHERE MaMH = @ma",
                             new List<SqlParameter> { new SqlParameter("@ma", maMH) });
            if (mh == 0) {
                BaoLoi(cboMonHoc, "Mã môn học \"" + maMH + "\" không tồn tại trong bảng MonHoc");
                return false;
            }
            return true;
        }

        //Điểm của (sinh viên, môn học) này đã có trong bảng Diem chưa (khóa chính)
        private bool DaCoDiem(string maSV, string maMH) {
            return DemDong("SELECT COUNT(*) FROM Diem WHERE MaSV = @sv AND MaMH = @mh",
                           new List<SqlParameter> { new SqlParameter("@sv", maSV), new SqlParameter("@mh", maMH) }) > 0;
        }

        //Nút Thêm: sinh viên và môn học phải tồn tại, cặp (sinh viên, môn học) chưa có điểm
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            if (!DocMa(out string maSV, out string maMH))
                return;
            if (!DocDiem(out decimal diem))
                return;

            try {
                if (!KiemTraTonTai(maSV, maMH))
                    return;

                if (DaCoDiem(maSV, maMH)) {
                    BaoLoi(cboMonHoc, "Sinh viên \"" + maSV + "\" đã có điểm môn \"" + maMH + "\" trong bảng Diem");
                    return;
                }

                List<SqlParameter> ds = new List<SqlParameter> {
                    new SqlParameter("@sv", maSV),
                    new SqlParameter("@mh", maMH),
                    new SqlParameter("@diem", diem)
                };
                ThucThi("INSERT INTO Diem(MaSV, MaMH, Diem) VALUES (@sv, @mh, @diem)", ds);
                MessageBox.Show("Thêm điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Clear();
            }
            catch (SqlException ex) {
                if (ex.Number == 2627 || ex.Number == 2601) //trùng khóa chính
                    BaoLoi(cboMonHoc, "Sinh viên \"" + maSV + "\" đã có điểm môn \"" + maMH + "\" trong bảng Diem");
                else if (ex.Number == 547) //vi phạm khóa ngoại
                    BaoLoi(cboSinhVien, "Mã sinh viên hoặc mã môn học không tồn tại (vi phạm khóa ngoại)");
                else
                    BaoLoiCSDL(ex);
            }
        }

        //Nút Xóa: chỉ cần sinh viên và môn học, điểm có trong bảng Diem mới xóa được
        private void btnXoa_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            if (!DocMa(out string maSV, out string maMH))
                return;

            try {
                //kiểm tra khóa chính: có dòng điểm này không
                if (!DaCoDiem(maSV, maMH)) {
                    BaoLoi(cboMonHoc, "Không tìm thấy điểm môn \"" + maMH + "\" của sinh viên \"" + maSV + "\"");
                    return;
                }

                DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm môn \"" + maMH + "\" của sinh viên \"" + maSV + "\"?",
                                                 "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;

                ThucThi("DELETE FROM Diem WHERE MaSV = @sv AND MaMH = @mh",
                        new List<SqlParameter> { new SqlParameter("@sv", maSV), new SqlParameter("@mh", maMH) });
                MessageBox.Show("Xóa điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Clear();
            }
            catch (SqlException ex) {
                BaoLoiCSDL(ex);
            }
        }

        //Nút Sửa: sinh viên, môn học phải tồn tại (khóa ngoại) và đã có điểm (khóa chính)
        private void btnSua_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            if (!DocMa(out string maSV, out string maMH))
                return;
            if (!DocDiem(out decimal diem))
                return;

            try {
                if (!KiemTraTonTai(maSV, maMH))
                    return;

                List<SqlParameter> ds = new List<SqlParameter> {
                    new SqlParameter("@diem", diem),
                    new SqlParameter("@sv", maSV),
                    new SqlParameter("@mh", maMH)
                };
                int soDong = ThucThi("UPDATE Diem SET Diem = @diem WHERE MaSV = @sv AND MaMH = @mh", ds);
                if (soDong == 0) {
                    BaoLoi(cboMonHoc, "Không tìm thấy điểm môn \"" + maMH + "\" của sinh viên \"" + maSV + "\" để sửa");
                    return;
                }
                MessageBox.Show("Sửa điểm thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Clear();
            }
            catch (SqlException ex) {
                if (ex.Number == 547)
                    BaoLoi(cboSinhVien, "Mã sinh viên hoặc mã môn học không tồn tại (vi phạm khóa ngoại)");
                else
                    BaoLoiCSDL(ex);
            }
        }
    }
}