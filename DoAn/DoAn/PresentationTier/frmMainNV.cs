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
    public partial class frmMainNV : Form
    {
        public frmMainNV()
        {
            InitializeComponent();
        }
        private void nHẬPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapThongTinKhachHang frm2 = new frmNhapThongTinKhachHang();
            frm2.Show();
        }

        private void đĂNGXUẤTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmDangNhapNV frm3 = new frmDangNhapNV();
                frm3.Show();
            }
        }

        private void tHÔNGTINNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapThongTinNV frm4 = new frmNhapThongTinNV();
            frm4.Show();
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemKH frm1 = new frmTimKiemKH();
            frm1.Show();
        }

        private void nHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemNV frm5 = new frmTimKiemNV();
            frm5.Show();
        }

        private void iNREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportKH frm6 = new frmReportKH();
            frm6.Show();
        }

        private void iNNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportNV frm7 = new frmReportNV();
            frm7.Show();
        }

        private void iNHÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportHD frm8 = new frmReportHD();
            frm8.Show();
        }

        private void hÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapHoaDon frm9 = new frmNhapHoaDon();
            frm9.Show();
        }

        private void frmMainNV_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker1.Enabled = false;
        }
    }
}
