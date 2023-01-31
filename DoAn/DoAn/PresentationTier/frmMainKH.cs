using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.PresentationTier
{
    public partial class frmMainKH : Form
    {
        public frmMainKH(string TaiKhoanKH)
        {
            InitializeComponent();
            string TaiKhoanDangDung = TaiKhoanKH;
            txtTK.Text = TaiKhoanDangDung;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmDangNhapNV frm = new frmDangNhapNV();
                frm.Show();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmHienThiThongTinKhachHang frm = new frmHienThiThongTinKhachHang(txtTK.Text);
            frm.Show();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmHienThiHoaDon frm1 = new frmHienThiHoaDon(txtTK.Text);
            frm1.Show();
        }

    }
}
