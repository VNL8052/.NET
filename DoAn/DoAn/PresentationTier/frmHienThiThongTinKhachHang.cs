using DoAn.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.PresentationTier
{
    public partial class frmHienThiThongTinKhachHang : Form
    {
        AppQLKH dbContext;
        List<KhachHang> khachHangs;
        public frmHienThiThongTinKhachHang(string TaiKhoanKH)
        {
            InitializeComponent();
            dbContext = new AppQLKH();
            string TaiKhoanDangDung = TaiKhoanKH;
            txtTaiKhoanDangDung.Text = TaiKhoanDangDung;
        }
        private void frmHienThiThongTinKhachHang_Load(object sender, EventArgs e)
        {
            khachHangs = dbContext.KhachHang.ToList();
            FillDataToDataGridView(khachHangs);
        }
        private void ResetForm()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            dtpNgaySinhKH.Text = "";
            txtDiaChiKH.Text = "";
            txtSDTKH.Text = "";
            txtEmailKH.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void FillDataToDataGridView(List<KhachHang> khachHangs)
        {
            dgvHienThiKH.Rows.Clear();
            foreach (KhachHang item in khachHangs)
            {
                if (String.Compare(txtTaiKhoanDangDung.Text, item.TaiKhoan, true)==0)
                {
                    int index = dgvHienThiKH.Rows.Add();
                    dgvHienThiKH.Rows[index].Cells[0].Value = item.MaKH;
                    dgvHienThiKH.Rows[index].Cells[1].Value = item.TenKH;
                    dgvHienThiKH.Rows[index].Cells[2].Value = item.NgaySinh;
                    dgvHienThiKH.Rows[index].Cells[3].Value = item.DiaChi;
                    dgvHienThiKH.Rows[index].Cells[4].Value = item.SDT;
                    dgvHienThiKH.Rows[index].Cells[5].Value = item.Email;
                    dgvHienThiKH.Rows[index].Cells[6].Value = item.TaiKhoan;
                    dgvHienThiKH.Rows[index].Cells[7].Value = item.MatKhau;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var update = dbContext.KhachHang.FirstOrDefault(
                   p => p.MaKH == txtMaKH.Text);
            if (update != null)
            {
                update.MaKH = txtMaKH.Text;
                update.TenKH = txtTenKH.Text;
                update.NgaySinh = DateTime.Parse(dtpNgaySinhKH.Text);
                update.DiaChi = txtDiaChiKH.Text;
                update.Email = txtEmailKH.Text;
                update.SDT = int.Parse(txtSDTKH.Text);
                update.TaiKhoan = txtTaiKhoan.Text;
                update.MatKhau = txtMatKhau.Text;
                dbContext.KhachHang.AddOrUpdate(update);
                dbContext.SaveChanges();
                FillDataToDataGridView(khachHangs);
                ResetForm();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvHienThiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvHienThiKH.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvHienThiKH.CurrentRow.Selected = true;
                txtMaKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtTenKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                dtpNgaySinhKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtDiaChiKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtSDTKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtEmailKH.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtTaiKhoan.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtMatKhau.Text = dgvHienThiKH.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            }
        }
    }
}
