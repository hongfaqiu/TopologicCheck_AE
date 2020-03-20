using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using System.Text.RegularExpressions;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;

namespace MapControlApplication1
{
    public partial class Export : Form
    {
        //使用IHookHelper接口复制
        private IActiveView pActiveView = null;
        public Export(IHookHelper hookHelper)
        {
            InitializeComponent();
            pActiveView = hookHelper.ActiveView;
            //初始化长宽文本框为当前地图视图的长宽
            IEnvelope pEnvelope = pActiveView.Extent;
            int width, length;
            width = (int)pEnvelope.Width * 10;
            length = (int)pEnvelope.Height * 10;
            txtWidth.Text = Convert.ToString(width);
            txtLength.Text = Convert.ToString(length);
        }

        private void tbExport_Click(object sender, EventArgs e)
        {
            ExportMapExtent();
        }

        public void ExportMapExtent()
        {
            //调用系统文件保存窗体
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG格式(*.jpg)|*.jpg|EPS格式(*.eps)|*.eps|EMF格式(*.emf)|*.emf|BMP格式(*.bmp)|*.bmp|PDF格式(*.pdf)|*.pdf|TIFF格式(*.tif)|*.tif|PNG格式(*.png)|*.png|SVG格式(*.svg)|*.svg|AI格式(*.ai)|*.ai|所有格式(*.*)|*.*";
            sfd.ShowDialog();
            IExport pExport = null;
            switch (sfd.Filter.ToString().Trim().Substring(0, 3))
            {
                case "jpg":
                    pExport = new ExportJPEGClass();
                    break;
                case "bmp":
                    pExport = new ExportBMPClass();
                    break;
                case "gif":
                    pExport = new ExportGIFClass();
                    break;
                case "tif":
                    pExport = new ExportTIFFClass();
                    break;
                case "png":
                    pExport = new ExportPNGClass();
                    break;
                case "emf":
                    pExport = new ExportEMFClass();
                    break;
                case "pdf":
                    pExport = new ExportPDFClass();
                    break;
                case ".ai":
                    pExport = new ExportAIClass();
                    break;
                case "svg":
                    pExport = new ExportSVGClass();
                    break;
                default:
                    pExport = new ExportJPEGClass();
                    break;
            }
            pExport.ExportFileName = sfd.FileName;
            int lResolution = Convert.ToInt32(txtResolution.Value);
            //传入当前视图的图像
            IEnvelope pEnvelope = pActiveView.Extent;
            //设置导出参数（分辨率）           
            pExport.Resolution = lResolution;
            //设置导出图片的大小
            tagRECT exportRect = new tagRECT();
            exportRect.left = exportRect.top = 0;
            exportRect.right = Convert.ToInt32(txtWidth.Text);
            exportRect.bottom = Convert.ToInt32(txtLength.Text);
            IEnvelope pDriverBounds = new EnvelopeClass();
            pDriverBounds.PutCoords(exportRect.left, exportRect.top, exportRect.right, exportRect.bottom);
            //将图片大小设置为地图图像的外边框
            pExport.PixelBounds = pDriverBounds;
            //可用于取消操作，默认设置为无
            ITrackCancel pCancel = new TrackCancelClass();
            pActiveView.Output(pExport.StartExporting(), lResolution, ref exportRect, pEnvelope, pCancel);
            pExport.FinishExporting();
            MessageBox.Show("打印图片保存成功!", "保存", MessageBoxButtons.OK);
            this.Close();
        }
        
    }
}
