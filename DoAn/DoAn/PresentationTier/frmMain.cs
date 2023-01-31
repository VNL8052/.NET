using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.PresentationTier
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmDangNhapNV frm1 = new frmDangNhapNV();
            frm1.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmDangNhapKH frm2 = new frmDangNhapKH();
            frm2.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
        /////////////////////////////////////////////////////////
        //                                                     //
        //                       _oo0oo_                       //
        //                      o8888888o                      //
        //                      88" . "88                      //
        //                      (| -_- |)                      //
        //                      0\  =  /0                      //
        //                    ___/`---'\___                    //
        //                  .' \\|     |// '.                  //
        //                 / \\|||  :  |||// \                 //
        //                / _||||| -:- |||||- \                //
        //               |   | \\\  -  /// |   |               //
        //               | \_|  ''\---/''  |_/ |               //
        //               \  .-\__  '-'  ___/-. /               //
        //             ___'. .'  /--.--\  `. .'___             //
        //          ."" '<  `.___\_<|>_/___.' >' "".           //
        //         | | :  `- \`.;`\ _ /`;.`/ - ` : | |         //
        //         \  \ `_.   \_ __\ /__ _/   .-` /  /         //
        //     =====`-.____`.___ \_____/___.-`___.-'=====      //
        //                       `=---='                       //
        //                                                     //
        //                                                     //
        //     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~     //
        //                                                     //
        //  KHÔNG BUG!        KHÔNG CRASH!        TỐT NGHIỆP!  //
        //                                                     //
        //                    A DI ĐÀ PHẬT!                    //
        //                                                     //
        /////////////////////////////////////////////////////////
    }
}
