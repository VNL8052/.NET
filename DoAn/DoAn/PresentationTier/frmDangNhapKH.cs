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

namespace DoAn
{
    public partial class frmDangNhapKH : Form
    {
        private TaiKhoanKH_BT taiKhoanKH_BT;

        public frmDangNhapKH()
        {
            InitializeComponent();
            taiKhoanKH_BT = new TaiKhoanKH_BT();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            string tenDangNhap = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            KhachHang taikhoan = taiKhoanKH_BT.LayTaiKhoanKH(tenDangNhap, matKhau);
            if (taikhoan != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMainKH frm1 = new frmMainKH(txtTaiKhoan.Text);
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmMain frm3 = new frmMain();
                frm3.Show();
            }
        }
    }
}


