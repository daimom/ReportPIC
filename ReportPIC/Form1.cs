using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportPIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 欲連結外部圖片必須設定該屬性
            reportViewer1.LocalReport.EnableExternalImages = true;
            // 設定 Report 內的 @PhoroPath 參數資料
            ReportParameter PhotoPath = new ReportParameter("par1", @"D:\aa.png");
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PhotoPath });
            // 更新 ReportViewer            
            this.reportViewer1.RefreshReport();



    
            var viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Report1.rdlc";
            viewer.LocalReport.EnableExternalImages = true;            
            viewer.LocalReport.SetParameters(new ReportParameter[] { PhotoPath });
            using (viewer)
            {
                byte[] bbytes;
                bbytes = viewer.LocalReport.Render("Image", "<DeviceInfo><OutputFormat>PNG</OutputFormat></DeviceInfo>");
                File.WriteAllBytes("d:\\test.png", bbytes);
            }


        }
    }
}