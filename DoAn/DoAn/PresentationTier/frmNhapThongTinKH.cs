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
using DoAn.BusinessTier;
using DoAn.DataContext;
using DoAn.DataTier;
using DoAn.Lib;
using DoAn.PresentationTier;

namespace DoAn
{
    public partial class frmNhapThongTinKhachHang : Form
    {
        AppQLKH dbContext;
        List<KhachHang> khachHangs;
        public frmNhapThongTinKhachHang()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }
        private void frmNhapThongTinKhachHang_Load(object sender, EventArgs e)
        {
            khachHangs = dbContext.KhachHang.ToList();
            FillDataToDataGridView(khachHangs);
        }

        private void FillDataToDataGridView(List<KhachHang> khachHangs)
        {
            dgvHienThiKH.Rows.Clear();
            foreach (KhachHang item in khachHangs)
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
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChiKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmailKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDTKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtpNgaySinhKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                return false;
            }
            return true;
        }
        private int Check(string id)
        {
            for (int i = 0; i < dgvHienThiKH.Rows.Count; i++)
            {
                if (dgvHienThiKH.Rows[i].Cells[0].Value != null)
                {
                    if (dgvHienThiKH.Rows[i].Cells[0].Value.ToString() == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                frmMainNV frm = new frmMainNV();
                frm.Show();
                this.Hide();
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                if (Check(txtMaKH.Text) == -1)
                {
                    var p = new KhachHang();
                    p.MaKH = txtMaKH.Text;
                    p.TenKH = txtTenKH.Text;
                    p.NgaySinh = DateTime.Parse(dtpNgaySinhKH.Text);
                    p.DiaChi = txtDiaChiKH.Text;
                    p.Email = txtEmailKH.Text;
                    p.SDT = Int32.Parse(txtSDTKH.Text);
                    p.TaiKhoan = txtTaiKhoan.Text;
                    p.MatKhau = txtMatKhau.Text;
                    dbContext.KhachHang.AddOrUpdate(p);
                    dbContext.SaveChanges();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Khách hàng đã tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            khachHangs = dbContext.KhachHang.ToList();
            FillDataToDataGridView(khachHangs);
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
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var p = dbContext.KhachHang.FirstOrDefault(ph => ph.MaKH == txtMaKH.Text);
            if (p != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa {p.TenKH} không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbContext.KhachHang.Remove(p);
                    dbContext.SaveChanges();
                    ResetForm();
                    khachHangs = dbContext.KhachHang.ToList();
                    FillDataToDataGridView(khachHangs);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Khách hàng cần xóa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
