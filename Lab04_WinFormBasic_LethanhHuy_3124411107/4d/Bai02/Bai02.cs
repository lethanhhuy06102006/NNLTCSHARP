using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MangSo {
    public partial class Bai02 : Form {
        //Mảng sau lần Thực Hiện gần nhất (null = chưa có)
        private MangSoNguyen mang = null;

        public Bai02() {
            InitializeComponent();
        }

        //Ô nhập mảng: chỉ cho gõ chữ số, dấu cách, dấu '-'
        private void txtNhapMang_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-')
                e.Handled = true;
        }

        //Sửa mảng nhập thì kết quả cũ không còn đúng nữa
        private void txtNhapMang_TextChanged(object sender, EventArgs e) {
            mang = null;
            txtKetQua.Clear();
        }

        //Ô nhập giá trị: cho gõ chữ số và dấu '-' ở đầu
        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e) {
            TextBox txt = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar == '-' && txt.SelectionStart == 0 && !txt.Text.Contains("-"))
                return;
            e.Handled = true;
        }

        //Ô nhập vị trí: chỉ cho gõ chữ số
        private void txtViTri_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Thông báo lỗi bằng ErrorProvider + MessageBox, đưa con trỏ về ô bị lỗi
        private void BaoLoi(Control ctr, string loi) {
            errorProvider1.SetError(ctr, loi);
            MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ctr.Focus();
        }

        //Đọc 1 số nguyên từ textbox, sai thì báo lỗi
        private bool LaySo(TextBox txt, string tenO, out int so) {
            if (!int.TryParse(txt.Text.Trim(), out so)) {
                BaoLoi(txt, "Bạn chưa nhập hoặc nhập sai " + tenO);
                return false;
            }
            return true;
        }

        //Đọc dãy số trong ô Nhập mảng thành đối tượng MangSoNguyen
        private MangSoNguyen DocMang() {
            string[] cacSo = txtNhapMang.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (cacSo.Length == 0) {
                BaoLoi(txtNhapMang, "Bạn chưa nhập mảng (các số cách nhau bởi dấu cách)");
                return null;
            }

            List<int> ds = new List<int>();
            foreach (string s in cacSo) {
                if (!int.TryParse(s, out int x)) {
                    BaoLoi(txtNhapMang, "Giá trị \"" + s + "\" không phải số nguyên hợp lệ");
                    return null;
                }
                ds.Add(x);
            }
            return new MangSoNguyen(ds.ToArray());
        }

        //Lấy mảng đang có, chưa Thực Hiện thì đọc từ ô Nhập mảng
        private MangSoNguyen LayMangHienTai() {
            errorProvider1.Clear();
            if (mang != null)
                return mang;
            return DocMang();
        }

        //Nút Thực Hiện: sắp xếp, xóa, thêm, thay thế, tìm kiếm theo các lựa chọn
        private void btnThucHien_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            XoaKetQuaPhu();

            MangSoNguyen m = DocMang();
            if (m == null)
                return;

            //1. Sắp xếp
            if (rdoTang.Checked)
                m.SapXepTang();
            else if (rdoGiam.Checked)
                m.SapXepGiam();

            //2. Xóa
            if (rdoXoaGiaTri.Checked || rdoXoaViTri.Checked) {
                if (!rdoTang.Checked) {
                    BaoLoi(rdoTang, "Cần chọn Sắp xếp Tăng trước khi xóa");
                    return;
                }
                if (rdoXoaGiaTri.Checked) {
                    if (!LaySo(txtXoaGiaTri, "giá trị cần xóa", out int x))
                        return;
                    if (m.XoaGiaTri(x) == 0) {
                        BaoLoi(txtXoaGiaTri, "Không có giá trị " + x + " trong mảng để xóa");
                        return;
                    }
                }
                else {
                    if (!LaySo(txtXoaViTri, "vị trí cần xóa", out int i))
                        return;
                    if (!m.XoaViTri(i)) {
                        BaoLoi(txtXoaViTri, "Vị trí xóa phải từ 0 đến " + (m.SoPhanTu - 1));
                        return;
                    }
                }
            }

            //3. Thêm
            if (rdoThem.Checked) {
                if (!rdoTang.Checked) {
                    BaoLoi(rdoTang, "Cần chọn Sắp xếp Tăng trước khi thêm");
                    return;
                }
                if (!LaySo(txtThemGiaTri, "giá trị cần thêm", out int x))
                    return;
                if (!LaySo(txtThemViTri, "vị trí cần thêm", out int i))
                    return;
                if (!m.Them(x, i)) {
                    BaoLoi(txtThemViTri, "Vị trí thêm phải từ 0 đến " + m.SoPhanTu);
                    return;
                }
            }

            //4. Thay thế
            if (rdoThayGiaTri.Checked || rdoThayViTri.Checked) {
                if (!LaySo(txtSoThay, "số thay thế", out int moi))
                    return;

                if (rdoThayGiaTri.Checked) {
                    if (!LaySo(txtThayGiaTri, "giá trị cần thay thế", out int cu))
                        return;
                    if (m.ThayGiaTri(cu, moi) == 0) {
                        BaoLoi(txtThayGiaTri, "Không có giá trị " + cu + " trong mảng để thay thế");
                        return;
                    }
                }
                else {
                    if (!LaySo(txtThayViTri, "vị trí cần thay thế", out int i))
                        return;
                    if (!m.ThayViTri(i, moi)) {
                        BaoLoi(txtThayViTri, "Vị trí thay thế phải từ 0 đến " + (m.SoPhanTu - 1));
                        return;
                    }
                }
            }

            //5. Xuất kết quả mảng
            mang = m;
            txtKetQua.Text = m.ToString();

            //6. Tìm kiếm trên mảng kết quả
            if (rdoTimGiaTri.Checked) {
                if (!LaySo(txtTimGiaTri, "giá trị cần tìm", out int x))
                    return;
                int vt = m.TimGiaTri(x);
                if (vt == -1)
                    BaoLoi(txtTimGiaTri, "Không tìm thấy giá trị " + x + " trong mảng");
                else
                    txtSoTim.Text = vt.ToString(); //vị trí tìm được
            }
            else if (rdoTimViTri.Checked) {
                if (!LaySo(txtTimViTri, "vị trí cần tìm", out int i))
                    return;
                if (!m.ViTriHopLe(i))
                    BaoLoi(txtTimViTri, "Vị trí tìm phải từ 0 đến " + (m.SoPhanTu - 1));
                else
                    txtSoTim.Text = m.LayGiaTri(i).ToString(); //giá trị tại vị trí đó
            }
        }

        //Nút Tổng
        private void btnTong_Click(object sender, EventArgs e) {
            MangSoNguyen m = LayMangHienTai();
            if (m == null)
                return;
            if (m.SoPhanTu == 0) {
                BaoLoi(txtNhapMang, "Mảng rỗng, không tính được tổng");
                return;
            }
            txtTong.Text = m.Tong().ToString();
            txtChan.Text = m.TongChan().ToString();
            txtLe.Text = m.TongLe().ToString();
        }

        //Nút Tìm (Max - Min)
        private void btnTim_Click(object sender, EventArgs e) {
            MangSoNguyen m = LayMangHienTai();
            if (m == null)
                return;
            if (m.SoPhanTu == 0) {
                BaoLoi(txtNhapMang, "Mảng rỗng, không có giá trị lớn nhất / nhỏ nhất");
                return;
            }
            txtMax.Text = m.Max().ToString();
            txtMin.Text = m.Min().ToString();
        }

        //Xóa các ô kết quả phụ
        private void XoaKetQuaPhu() {
            txtSoTim.Clear();
            txtTong.Clear();
            txtChan.Clear();
            txtLe.Clear();
            txtMax.Clear();
            txtMin.Clear();
        }

        //Nút Reset: xóa hết textbox, bỏ chọn hết radio button
        private void btnReset_Click(object sender, EventArgs e) {
            XoaHet(this);
            mang = null;
            errorProvider1.Clear();
            txtNhapMang.Focus();
        }

        //Duyệt tất cả control
        private void XoaHet(Control cha) {
            foreach (Control ctr in cha.Controls) {
                if (ctr is TextBox)
                    ((TextBox)ctr).Clear();
                else if (ctr is RadioButton)
                    ((RadioButton)ctr).Checked = false;
                else if (ctr.HasChildren)
                    XoaHet(ctr); //gọi đệ quy cho GroupBox
            }
        }

        //Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e) {
            this.Close(); //sẽ kích hoạt FormClosing bên dưới
        }

        //Hỏi xác nhận trước khi đóng Form
        private void Bai02_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}