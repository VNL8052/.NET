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
using DoAn.DTO;

namespace DoAn.PresentationTier
{
    public partial class frmReportNV : Form
    {
        public frmReportNV()
        {
            InitializeComponent();
        }

        private void frmReportNV_Load(object sender, EventArgs e)
        {
            AppQLKH dbContext = new AppQLKH();
            this.reportViewer1.LocalReport.ReportPath = "NhanVien.rdlc";
            var reportDataSource = new ReportDataSource("NhanVienDataSet", dbContext.NhanVien.ToList());
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear 
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
