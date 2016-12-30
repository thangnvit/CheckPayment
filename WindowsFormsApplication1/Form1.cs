using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using CheckPayment;
using CreateReport;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("D:\\Thông kê báo cáo"))
                Directory.CreateDirectory("D:\\Thông kê báo cáo");
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog flie = new OpenFileDialog();
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                try
                {
                    new Main(path, path).Run();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("File Đã Xử Lý");
                }

                var exel = new Excel.Application();
                exel.Visible = true;
                Excel.Workbooks book = exel.Workbooks;
                Excel.Workbook shet = book.Open(path);
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {

        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdTongHop = new OpenFileDialog();
            if (ofdTongHop.ShowDialog() == DialogResult.OK)
            {
                String formatDate = "yyyy-MM-dd";
                String pathFolder = "D:\\Thông kê báo cáo";
                String path = ofdTongHop.FileName;
                DirectoryInfo dir = new DirectoryInfo(pathFolder);
                FileInfo[] listFile = dir.GetFiles();

                GeneralFile generaFile = new GeneralFile(path, "template.xlsx");
                DateTime dateReport = generaFile.getDateReport();

                if (File.Exists(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xls"))
                {
                    generaFile = new GeneralFile(path, pathFolder + "\\" + dateReport.ToString(formatDate) + ".xls");
                }
                else if (File.Exists(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx"))
                {
                    generaFile = new GeneralFile(path, pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx");
                }
                else if(listFile.Length > 0)
                {
                    DateTime lastCreateTime = getFileLastCreateTime(dir);
                    generaFile = new GeneralFile(path, pathFolder + "\\" + lastCreateTime.ToString(formatDate) + ".xlsx");
                }
                generaFile.insertData(cmbAmOrPm.Text);

                generaFile.Save(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx");
                MessageBox.Show("      Đã Thêm File", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdThanhToan = new OpenFileDialog();
            if (ofdThanhToan.ShowDialog() == DialogResult.OK)
            {
                String formatDate = "yyyy-MM-dd";
                String pathFolder = "D:\\Thông kê báo cáo";
                String path = ofdThanhToan.FileName;

                PaymentFile paymentFile = new PaymentFile(path, "template.xlsx");
                DateTime dateReport = paymentFile.getDateReport();

                if (File.Exists(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xls"))
                {
                    paymentFile = new PaymentFile(path, pathFolder + "\\" + dateReport.ToString(formatDate) + ".xls");
                }
                else if (File.Exists(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx"))
                {
                    paymentFile = new PaymentFile(path, pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx");
                }

                paymentFile.insertData();

                paymentFile.Save(pathFolder + "\\" + dateReport.ToString(formatDate) + ".xlsx");

                MessageBox.Show("      Đã Thêm File", "Thông Báo", MessageBoxButtons.OK);

            }
        }
        public DateTime getFileLastCreateTime(DirectoryInfo dir)
        {
            List<FileInfo> listFile = dir.GetFiles().ToList();
            List<DateTime> dates = listFile.ConvertAll<DateTime>(delegate(FileInfo i) { return DateTime.Parse(i.ToString().Remove(i.ToString().IndexOf('.'))); });
            List<DateTime> newList = dates.OrderBy(x => x.TimeOfDay).ToList();

            return newList[newList.Count-1];
        }
    }
}
