using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DanhSachLop {
    public partial class BTNC1 : Form {
        //Chuỗi kết nối đến CSDL QLSinhVien. Sửa Server cho đúng máy của bạn, ví dụ: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, localhost
        private const string CHUOI_KET_NOI =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Trusted_Connection=True;TrustServerCertificate=True;";

        public BTNC1() {
            InitializeComponent();
        }

        //Nút Hiển thị dữ liệu: đọc bảng Lop và đưa vào ListView
        private void btnHienThi_Click(object sender, EventArgs e) {
            try {
                lvLop.BeginUpdate(); //tạm ngừng vẽ để thêm nhanh và không bị nháy
                lvLop.Items.Clear(); //bấm nhiều lần thì xóa danh sách cũ, không bị lặp dòng

                using (SqlConnection conn = new SqlConnection(CHUOI_KET_NOI)) {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaLop, TenLop, MaKhoa FROM Lop ORDER BY MaLop", conn)) {
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader()) {
                            int stt = 0;
                            while (rd.Read()) {
                                stt++;
                                ListViewItem dong = new ListViewItem(stt.ToString()); //cột 0: STT
                                dong.SubItems.Add(rd["MaLop"].ToString());
                                dong.SubItems.Add(rd["TenLop"].ToString());
                                dong.SubItems.Add(rd["MaKhoa"].ToString());
                                lvLop.Items.Add(dong);
                            }
                        }
                    }
                }

                if (lvLop.Items.Count == 0)
                    MessageBox.Show("Bảng Lop chưa có dữ liệu", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex) {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                lvLop.EndUpdate(); //luôn vẽ lại, kể cả khi có lỗi
            }
        }

        //Nút Thoát: đóng form
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}