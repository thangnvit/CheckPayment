using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Data;
using System.Drawing;
namespace CreateReport
{
    public class PaymentFile
    {
        private String addPath;
        private String sourcePath;
        private Workbook addWorkBook;
        private Workbook sourceWorkBook;
        private Worksheet addSheet;
        private Worksheet sourceSheet;

        public PaymentFile(String addPath, String sourcePath)
        {
            this.addPath = addPath;
            this.sourcePath = sourcePath;
            addWorkBook = new Workbook(addPath);
            sourceWorkBook = new Workbook(sourcePath);
            addSheet = addWorkBook.Worksheets[0];
            sourceSheet = sourceWorkBook.Worksheets[1];
        }

        public void insertData()
        {
            DataTable dt = exportDataTable();
            int maxDataRow = sourceSheet.Cells.MaxDataRow;
            sourceSheet.Cells.ImportDataTable(dt, true, "A"+(maxDataRow+2));

            sourceSheet.Cells.DeleteRow(maxDataRow + 1);

            String tongCodFormula = "=SUM(" + "C" + 2 + ":" + "C" + (sourceSheet.Cells.MaxDataRow + 1) + ")";
            sourceSheet.Cells["D2"].Formula = tongCodFormula;
            Units.setColorCell("D2", sourceSheet, Color.Pink);
        }

        public DataTable exportDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã Vận Đơn", typeof(string));
            dt.Columns.Add("Số tiền", typeof(int));

            int row = 2;
            int stt = 1;

            while (row <= addSheet.Cells.MaxRow)
            {
                if (addSheet.Cells["C" + row].Value != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["STT"] = stt;
                    dr["Mã Vận Đơn"] = handleString(addSheet.Cells["C" + row].Value.ToString());
                    dr["Số tiền"] = addSheet.Cells["E" + row].IntValue;
                    stt++;
                    dt.Rows.Add(dr);
                }
                row++;
            }

            return dt;
        }

        public static String handleString(String inputString)
        {
            String[] split = inputString.Split('/');
            return split[0].Trim();
        }

        public String getDateString()
        {
            int row = 2;
            while (row <= addSheet.Cells.MaxDataRow)
            {
                if (addSheet.Cells["A" + row].Value != null)
                {
                    return addSheet.Cells["A" + row].StringValue;
                }
            }
            return null;
        }

        public DateTime getDateReport()
        {
            String dateString = getDateString();
            String[] split = dateString.Split(' ');
            String[] nextSplit = split[0].Split('/');
            DateTime dt = new DateTime(Int32.Parse(nextSplit[2].Trim()), Int32.Parse(nextSplit[1].Trim()), Int32.Parse(nextSplit[0].Trim()));
            return dt;
        }

        public void Save(String savePath)
        {
            sourceWorkBook.Worksheets.RemoveAt("Evaluation Warning");
            sourceWorkBook.Save(savePath);
        }
    }
}
