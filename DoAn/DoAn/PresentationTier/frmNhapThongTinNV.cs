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

namespace DoAn.PresentationTier
{
    public partial class frmNhapThongTinNV : Form
    {
        AppQLKH dbContext;
        List<NhanVien> nhanViens;
        public frmNhapThongTinNV()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }
        private void frmNhapThongTinNV_Load(object sender, EventArgs e)
        {
            nhanViens = dbContext.NhanVien.ToList();
            FillDataToDataGridView(nhanViens);
        }

        private void FillDataToDataGridView(List<NhanVien> nhanViens)
        {
            dgvHienThiNV.Rows.Clear();
            foreach (NhanVien item in nhanViens)
            {
                int index = dgvHienThiNV.Rows.Add();
                dgvHienThiNV.Rows[index].Cells[0].Value = item.MaNV;
                dgvHienThiNV.Rows[index].Cells[1].Value = item.TenNV;
                dgvHienThiNV.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvHienThiNV.Rows[index].Cells[3].Value = item.DiaChi;
                dgvHienThiNV.Rows[index].Cells[4].Value = item.SDT;
                dgvHienThiNV.Rows[index].Cells[5].Value = item.Email;
                dgvHienThiNV.Rows[index].Cells[6].Value = item.TaiKhoan;
                dgvHienThiNV.Rows[index].Cells[7].Value = item.MatKhau;
            }

        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChiNV.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmailNV.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDTNV.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtpNgaySinhNV.Text))
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
            for (int i = 0; i < dgvHienThiNV.Rows.Count; i++)
            {
                if (dgvHienThiNV.Rows[i].Cells[0].Value != null)
                {
                    if (dgvHienThiNV.Rows[i].Cells[0].Value.ToString() == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void ResetForm()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinhNV.Text = "";
            txtDiaChiNV.Text = "";
            txtSDTNV.Text = "";
            txtEmailNV.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                if (Check(txtMaNV.Text) == -1)
                {
                    var p = new NhanVien();
                    p.MaNV = txtMaNV.Text;
                    p.TenNV = txtTenNV.Text;
                    p.NgaySinh = DateTime.Parse(dtpNgaySinhNV.Text);
                    p.DiaChi = txtDiaChiNV.Text;
                    p.Email = txtEmailNV.Text;
                    p.SDT = Int32.Parse(txtSDTNV.Text);
                    p.TaiKhoan = txtTaiKhoan.Text;
                    p.MatKhau = txtMatKhau.Text;
                    dbContext.NhanVien.AddOrUpdate(p);
                    dbContext.SaveChanges();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                //21232f297a57a5a743894a0e4a801fc3
                else
                {
                    MessageBox.Show("Nhân viên đã tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            nhanViens = dbContext.NhanVien.ToList();
            FillDataToDataGridView(nhanViens);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var update = dbContext.NhanVien.FirstOrDefault(
                  p => p.MaNV == txtMaNV.Text);
            if (update != null)
            {
                update.MaNV = txtMaNV.Text;
                update.TenNV = txtTenNV.Text;
                update.NgaySinh = DateTime.Parse(dtpNgaySinhNV.Text);
                update.DiaChi = txtDiaChiNV.Text;
                update.Email = txtEmailNV.Text;
                update.SDT = int.Parse(txtSDTNV.Text);
                update.TaiKhoan = txtTaiKhoan.Text;
                update.MatKhau = txtMatKhau.Text;
                dbContext.NhanVien.AddOrUpdate(update);
                dbContext.SaveChanges();
                FillDataToDataGridView(nhanViens);
                ResetForm();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var p = dbContext.NhanVien.FirstOrDefault(ph => ph.MaNV == txtMaNV.Text);
            if (p != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa {p.TenNV} không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbContext.NhanVien.Remove(p);
                    dbContext.SaveChanges();
                    ResetForm();
                    nhanViens = dbContext.NhanVien.ToList();
                    FillDataToDataGridView(nhanViens);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Nhân viên cần xóa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvHienThiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvHienThiNV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvHienThiNV.CurrentRow.Selected = true;
                txtMaNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtTenNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                dtpNgaySinhNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtDiaChiNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtSDTNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtEmailNV.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtTaiKhoan.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtMatKhau.Text = dgvHienThiNV.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                frmMainNV frm = new frmMainNV();
                frm.Show();
                this.Hide();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
