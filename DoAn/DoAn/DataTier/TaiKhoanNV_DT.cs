using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DataContext;

namespace DoAn.DataTier
{
    class TaiKhoanNV_DT
    {
        public NhanVien LayTaiKhoan(string tenDangNhap, string matKhau)
        {
            using (var dbContext = new AppQLKH())
            {
                return dbContext.NhanVien.Where(s => s.TaiKhoan == tenDangNhap && s.MatKhau == matKhau).FirstOrDefault();
            }
        }
    }
}
