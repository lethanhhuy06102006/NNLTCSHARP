using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyCuaHang {
    public partial class BTVN1 : Form {
        public BTVN1() {
            InitializeComponent();
        }

        //Menu Tạo tồn kho: tạo dòng tồn kho hôm nay cho tất cả sản phẩm (mỗi ngày 1 lần)
        private void mnuTaoTonKho_Click(object sender, EventArgs e) {
            DateTime homNay = DateTime.Today;

            try {
                using (SqlConnection conn = new SqlConnection(CSDL.CHUOI_KET_NOI)) {
                    conn.Open();

                    //mỗi ngày chỉ tạo 1 lần: nếu hôm nay đã có dòng tồn kho thì không tạo nữa
                    using (SqlCommand kt = new SqlCommand("SELECT COUNT(*) FROM TONKHO WHERE NgayTon = @ngay", conn)) {
                        kt.Parameters.Add(new SqlParameter("@ngay", SqlDbType.Date) { Value = homNay });
                        if ((int)kt.ExecuteScalar() > 0) {
                            MessageBox.Show("Tồn kho ngày " + homNay.ToString("dd/MM/yyyy") + " đã được tạo rồi (chỉ tạo 1 lần mỗi ngày)",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //SLDau hôm nay = SLDau + SLNhap - SLBan của ngày tồn kho gần nhất trước hôm nay; SLNhap và SLBan bằng 0
                    //Sản phẩm chưa từng có tồn kho thì SLDau = 0
                    string sql =
                        "INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) " +
                        "SELECT sp.MaSP, @ngay, ISNULL(t.SLDau + t.SLNhap - t.SLBan, 0), 0, 0 " +
                        "FROM SANPHAM sp " +
                        "LEFT JOIN TONKHO t ON t.MaSP = sp.MaSP " +
                        "AND t.NgayTon = (SELECT MAX(NgayTon) FROM TONKHO WHERE MaSP = sp.MaSP AND NgayTon < @ngay)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                        cmd.Parameters.Add(new SqlParameter("@ngay", SqlDbType.Date) { Value = homNay });
                        int soSP = cmd.ExecuteNonQuery(); //số dòng thêm vào = số sản phẩm
                        MessageBox.Show("Đã tạo tồn kho ngày " + homNay.ToString("dd/MM/yyyy") + " cho " + soSP + " sản phẩm",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex) {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Menu Thêm sản phẩm mới: mở form nhập (ShowDialog nên form chính tạm khóa)
        private void mnuThemSP_Click(object sender, EventArgs e) {
            BTVN1_ThemSP frm = new BTVN1_ThemSP();
            frm.ShowDialog(this);
        }
    }
}