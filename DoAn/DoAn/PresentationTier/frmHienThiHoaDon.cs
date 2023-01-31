using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DTO;
using DoAn.DataContext;
using Microsoft.Reporting.WinForms;
namespace DoAn.PresentationTier
{

    public partial class frmHienThiHoaDon : Form
    {
        List<HoaDon> hoaDons;
        AppQLKH dbContext;
        public frmHienThiHoaDon(string TaiKhoanKH)
        {
            dbContext = new AppQLKH();
            InitializeComponent();
            string TaiKhoanDangDung = TaiKhoanKH;
            txtTK.Text = TaiKhoanDangDung;
            hoaDons = dbContext.HoaDon.ToList();
            FillDataDGV(hoaDons);
        }
        private void FillDataDGV(List<HoaDon> list)
        {
            if (list == null) return;
            dgvNgay.Rows.Clear();
            foreach (var item in list)
            {
                if (String.Compare(txtTK.Text, item.KhachHang.TaiKhoan, true) == 0)
                {
                    int index = dgvNgay.Rows.Add();
                    dgvNgay.Rows[index].Cells[0].Value = item.MaHD;
                    dgvNgay.Rows[index].Cells[1].Value = item.KhachHang.TenKH;
                    dgvNgay.Rows[index].Cells[2].Value = item.NgayMua;
                    dgvNgay.Rows[index].Cells[3].Value = item.TongTien;
                }
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            var listKq = new List<HoaDon>();
            foreach (var kq in hoaDons)
            {
                if (String.Compare(txtTK.Text, kq.KhachHang.TaiKhoan, true) == 0)
                {
                    if (DateTime.Compare(dtpNgay1.Value, kq.NgayMua.Value) < 0 && DateTime.Compare(kq.NgayMua.Value, dtpNgay2.Value)<0)
                    {
                        listKq.Add(kq);
                    }
                }    
            }
            if (listKq.Count == 0) return;
            FillDataDGV(listKq);

        }
    }
}
