using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Lib;
using DoAn.DataTier;
using DoAn.DataContext;


namespace DoAn.BusinessTier
{
    class TaiKhoanNV_BT
    {
        private readonly TaiKhoanNV_DT taiKhoanNV_DT;
        public TaiKhoanNV_BT()
        {
            taiKhoanNV_DT = new TaiKhoanNV_DT();
        }
        public NhanVien LayTaiKhoanNV(string tenDangNhap, string matKhau)
        {
            //matKhau = Helpers.Encryptor.MaHoaMD5(matKhau);
            return taiKhoanNV_DT.LayTaiKhoan(tenDangNhap, matKhau);
        }
    }
}
