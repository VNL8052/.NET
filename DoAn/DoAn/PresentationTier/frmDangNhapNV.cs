using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.BusinessTier;
using DoAn.DataContext;
using DoAn.DataTier;
using DoAn.PresentationTier;

namespace DoAn.PresentationTier
{
    public partial class frmDangNhapNV : Form
    {
        private TaiKhoanNV_BT taiKhoanNV_BT;
        public frmDangNhapNV()
        {
            InitializeComponent();
            taiKhoanNV_BT = new TaiKhoanNV_BT();
        }

        private void btnThoatKH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmMain frm3 = new frmMain();
                frm3.Show();
            }

        }
        private void btnDangNhapKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoanNV.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhauNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            string tenDangNhap = txtTaiKhoanNV.Text;
            string matKhau = txtMatKhauNV.Text;
            NhanVien taikhoan = taiKhoanNV_BT.LayTaiKhoanNV(tenDangNhap, matKhau);
            if (taikhoan != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMainNV frm1 = new frmMainNV();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
        }
    }
}
