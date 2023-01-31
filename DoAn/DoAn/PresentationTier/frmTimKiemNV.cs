using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DataContext;

namespace DoAn.PresentationTier
{
    public partial class frmTimKiemNV : Form
    {
        AppQLKH dbContext;
        public frmTimKiemNV()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Thông tin nhập vào chưa đúng!!!", "Thông Báo");
                txtMaNV.Focus();
                return;
            }
            List<NhanVien> listNV = dbContext.NhanVien.ToList();
            List<NhanVien> listFindNV = (from s in listNV
                                          where
                  s.MaNV == txtMaNV.Text ||
                  s.TenNV == txtHoTen.Text ||
                  s.SDT == Int32.Parse(txtSDT.Text)
                                          select s).ToList();
            txtKetQua.Text = (listFindNV.Count).ToString();
            DataToDataGriView(listFindNV);
        }
        private void DataToDataGriView(List<NhanVien> list)
        {
            dgvTimKiem.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvTimKiem.Rows.Add();
                dgvTimKiem.Rows[index].Cells[0].Value = item.MaNV;
                dgvTimKiem.Rows[index].Cells[1].Value = item.TenNV;
                dgvTimKiem.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvTimKiem.Rows[index].Cells[3].Value = item.DiaChi;
                dgvTimKiem.Rows[index].Cells[4].Value = item.SDT;
                dgvTimKiem.Rows[index].Cells[5].Value = item.Email;
                dgvTimKiem.Rows[index].Cells[6].Value = item.TaiKhoan;
                dgvTimKiem.Rows[index].Cells[7].Value = item.MatKhau;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = "";
            txtHoTen.Text = "";
            txtKetQua.Text = "0";
            txtMaNV.Text = "";
            dgvTimKiem.Rows.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát khỏi trang tìm kiếm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }
    }
}
