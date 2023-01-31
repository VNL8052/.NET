using Microsoft.Reporting.WinForms;
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
    public partial class frmReportKH : Form
    {
        AppQLKH dbContext;
        public frmReportKH()
        {
            InitializeComponent();
            dbContext = new AppQLKH();
        }

        private void frmReportKH_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "KhachHang.rdlc";
            var reportDataSource = new ReportDataSource("KhachHangDataSet", dbContext.KhachHang.ToList()); //đúng tên dataset trong thiết kế
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport(); //chạy report
        }
    }
}
