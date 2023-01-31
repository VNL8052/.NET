using DoAn.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DataTier
{
    class TaiKhoanKH_DT
    {
        public KhachHang LayTaiKhoanKH(string tenDangNhap, string matKhau)
        {
            using (var dbContext = new AppQLKH())
            {
                return dbContext.KhachHang.Where(p => p.TaiKhoan == tenDangNhap && p.MatKhau == matKhau).FirstOrDefault();
            }
        }
    }
}
