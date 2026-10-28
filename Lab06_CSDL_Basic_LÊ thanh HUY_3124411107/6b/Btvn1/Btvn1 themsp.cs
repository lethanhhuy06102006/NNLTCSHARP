using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyCuaHang {
    public partial class BTVN1_ThemSP : Form {
        public BTVN1_ThemSP() {
            InitializeComponent();
        }

        //Gõ lại thì xóa thông báo lỗi cũ
        private void txtTenSP_TextChanged(object sender, EventArgs e) {
            errorProvider1.SetError(txtTenSP, "");
        }

        //Nút Thêm: thêm sản phẩm vào bảng SANPHAM và thêm 1 dòng tồn kho hôm nay (SLDau = SLNhap = SLBan = 0)
        private void btnThem_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            string ten = txtTenSP.Text.Trim();

            if (ten.Length == 0) {
                string loi = "Tên sản phẩm không được để trống";
                errorProvider1.SetError(txtTenSP, loi);
                MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSP.Focus();
                return;
            }

            try {
                using (SqlConnection conn = new SqlConnection(CSDL.CHUOI_KET_NOI)) {
                    conn.Open();

                    //dùng transaction: cả 2 lệnh INSERT cùng thành công, hoặc cùng bị hủy nếu có lỗi
                    using (SqlTransaction tran = conn.BeginTransaction()) {
                        try {
                            //MaSP tự động tăng, OUTPUT INSERTED.MaSP trả về mã vừa được tạo
                            int maSP;
                            using (SqlCommand c1 = new SqlCommand("INSERT INTO SANPHAM(TenSP) OUTPUT INSERTED.MaSP VALUES (@ten)", conn, tran)) {
                                c1.Parameters.AddWithValue("@ten", ten);
                                maSP = (int)c1.ExecuteScalar();
                            }

                            using (SqlCommand c2 = new SqlCommand(
                                "INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) VALUES (@ma, @ngay, 0, 0, 0)", conn, tran)) {
                                c2.Parameters.AddWithValue("@ma", maSP);
                                c2.Parameters.Add(new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today });
                                c2.ExecuteNonQuery();
                            }

                            tran.Commit();
                        }
                        catch {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Thêm sản phẩm \"" + ten + "\" thành công", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Clear();
                txtTenSP.Focus();
            }
            catch (SqlException ex) {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút Thoát: đóng form, quay về form chính
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}