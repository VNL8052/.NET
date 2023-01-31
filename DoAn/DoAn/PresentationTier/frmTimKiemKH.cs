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
    public partial class frmTimKiemKH : Form
    {
        AppQLKH dbContext;
        public frmTimKiemKH()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát khỏi trang tìm kiếm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = "";
            txtHoTen.Text = "";
            txtKetQua.Text = "0";
            txtMaKH.Text = "";
            dgvTimKiem.Rows.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Thông tin nhập vào chưa đúng!!!", "Thông Báo");
                txtMaKH.Focus();
                return;
            }
            List<KhachHang> listKH = dbContext.KhachHang.ToList();
            List<KhachHang> listFindKH = (from s in listKH
                                               where
                       s.MaKH == txtMaKH.Text ||
                       s.TenKH == txtHoTen.Text ||
                       s.SDT == Int32.Parse( txtSDT.Text)
                                             select s).ToList();
            txtKetQua.Text = (listFindKH.Count).ToString();
            DataToDataGriView(listFindKH);
        }
        private void DataToDataGriView(List<KhachHang> list)
        {
            dgvTimKiem.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvTimKiem.Rows.Add();
                dgvTimKiem.Rows[index].Cells[0].Value = item.MaKH;
                dgvTimKiem.Rows[index].Cells[1].Value = item.TenKH;
                dgvTimKiem.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvTimKiem.Rows[index].Cells[3].Value = item.DiaChi;
                dgvTimKiem.Rows[index].Cells[4].Value = item.SDT;
                dgvTimKiem.Rows[index].Cells[5].Value = item.Email;
                dgvTimKiem.Rows[index].Cells[6].Value = item.TaiKhoan;
                dgvTimKiem.Rows[index].Cells[7].Value = item.MatKhau;
            }
        }

    }
}
