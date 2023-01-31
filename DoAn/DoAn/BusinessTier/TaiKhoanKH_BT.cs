using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DataContext;
using DoAn.DataTier;
using DoAn.Lib;


namespace DoAn.BusinessTier
{
    class TaiKhoanKH_BT
    {
        private readonly TaiKhoanKH_DT taiKhoanKH_DT;
        public TaiKhoanKH_BT()
        {
            taiKhoanKH_DT = new TaiKhoanKH_DT();
        }
        public KhachHang LayTaiKhoanKH(string tenDangNhap, string matKhau)
        {
            //matKhau = Helpers.Encryptor.MaHoaMD5(matKhau);
            return taiKhoanKH_DT.LayTaiKhoanKH(tenDangNhap, matKhau);
        }
    }
}
