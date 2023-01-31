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
using DoAn.DataContext;

namespace DoAn.PresentationTier
{
    public partial class frmNhapHoaDon : Form
    {
        AppQLKH dbContext;
        List<HoaDon> hoaDons;
        public frmNhapHoaDon()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }
        private void frmNhapHoaDon_Load(object sender, EventArgs e)
        {
            hoaDons = dbContext.HoaDon.ToList();
            FillDataToDataGridView(hoaDons);
        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTongTien.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTongTien.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtpNgayMua.Text))
            {
                return false;
            }
            return true;
        }
        private void FillDataToDataGridView(List<HoaDon> hoaDons)
        {
            dgvHienThiHD.Rows.Clear();
            foreach (HoaDon item in hoaDons)
            {
                int index = dgvHienThiHD.Rows.Add();
                dgvHienThiHD.Rows[index].Cells[0].Value = item.MaHD;
                dgvHienThiHD.Rows[index].Cells[1].Value = item.NgayMua;
                dgvHienThiHD.Rows[index].Cells[2].Value = item.TongTien;
                dgvHienThiHD.Rows[index].Cells[3].Value = item.MaKH;
                dgvHienThiHD.Rows[index].Cells[4].Value = item.MaNV;
            }
        }
        private int Check(string id)
        {
            for (int i = 0; i < dgvHienThiHD.Rows.Count; i++)
            {
                if (dgvHienThiHD.Rows[i].Cells[0].Value != null)
                {
                    if (dgvHienThiHD.Rows[i].Cells[0].Value.ToString() == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void ResetForm()
        {
            txtMaHD.Text = "";
            txtTongTien.Text = "";
            dtpNgayMua.Text = "";
            txtMaKH.Text = "";
            txtMaNV.Text = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(ValidateData())
            {

                if (Check(txtMaHD.Text) == -1)
                {
                    var p = new HoaDon();
                    p.MaKH = txtMaKH.Text;
                    p.MaNV = txtMaNV.Text;
                    p.MaHD = int.Parse(txtMaHD.Text);
                    p.TongTien =decimal.Parse( txtTongTien.Text);
                    p.NgayMua = DateTime.Parse(dtpNgayMua.Text);
                    dbContext.HoaDon.AddOrUpdate(p);
                    dbContext.SaveChanges();
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Hóa đơn đã tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            hoaDons = dbContext.HoaDon.ToList();
            FillDataToDataGridView(hoaDons);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var num = int.Parse(txtMaHD.Text);
            var update = dbContext.HoaDon.FirstOrDefault(p => p.MaHD == num);
            if (update != null)
            {
                update.MaHD = int.Parse(txtMaHD.Text);
                update.MaKH = txtMaKH.Text;
                update.MaNV = txtMaNV.Text;
                update.TongTien = decimal.Parse(txtTongTien.Text);
                update.NgayMua = DateTime.Parse(dtpNgayMua.Text);
                dbContext.HoaDon.AddOrUpdate(update);
                dbContext.SaveChanges();
                FillDataToDataGridView(hoaDons);
                ResetForm();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn cần sửa!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int rp = int.Parse(txtMaHD.Text);
            var p = dbContext.HoaDon.FirstOrDefault(ph => ph.MaHD == rp);
            if (p != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa {p.MaHD} không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbContext.HoaDon.Remove(p);
                    dbContext.SaveChanges();
                    ResetForm();
                    hoaDons = dbContext.HoaDon.ToList();
                    FillDataToDataGridView(hoaDons);
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn cần xóa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvHienThiHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvHienThiHD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvHienThiHD.CurrentRow.Selected = true;
                txtMaHD.Text = dgvHienThiHD.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                dtpNgayMua.Text = dgvHienThiHD.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTongTien.Text = dgvHienThiHD.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtMaKH.Text = dgvHienThiHD.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtMaNV.Text = dgvHienThiHD.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();

            }
        }
    }
}
