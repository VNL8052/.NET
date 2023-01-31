using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class HoaDonDTO
    {
        private int stt;

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        private int maHD;

        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private DateTime ngayMua;

        public DateTime NgayMua
        {
            get { return ngayMua; }
            set { ngayMua = value; }
        }
        private decimal tongTien;

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
    }
}
