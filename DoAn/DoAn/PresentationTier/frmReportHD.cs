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
using Microsoft.Reporting.WinForms;

namespace DoAn.PresentationTier
{
    public partial class frmReportHD : Form
    {
        public frmReportHD()
        {
            InitializeComponent();
        }

        private void frmReportHD_Load(object sender, EventArgs e)
        {
            AppQLKH dbContext = new AppQLKH();
            this.reportViewer1.LocalReport.ReportPath = "HoaDon.rdlc";
            var reportDataSource = new ReportDataSource("HoaDonDataSet", dbContext.HoaDon.ToList()); 
            this.reportViewer1.LocalReport.DataSources.Clear(); 
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport(); 
        }
    }
}
