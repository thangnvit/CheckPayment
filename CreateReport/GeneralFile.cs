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
    public class GeneralFile
    {
        private String addPath;
        private String sourcePath;
        private Workbook addWorkBook;
        private Workbook sourceWorkBook;
        private Worksheet addSheet;
        private Worksheet sourceSheet;


        public GeneralFile(String addPath, String sourcePath)
        {
            this.addPath = addPath;
            this.sourcePath = sourcePath;
            addWorkBook = new Workbook(addPath);
            sourceWorkBook = new Workbook(sourcePath);
            addSheet = addWorkBook.Worksheets[0];
            sourceSheet = sourceWorkBook.Worksheets[0];

        }

        public void insertData(String AmOrPm)
        {
            DataTable dt = exportDataTable(AmOrPm);

            int maxRow = sourceSheet.Cells.MaxDataRow + 2;
            String tongCodFormula = "=SUM(" + "G" + (maxRow + 1) + ":" + "G" + (maxRow + dt.Rows.Count) + ")";
            String tongCuocFormula = "=SUM(" + "K" + (maxRow + 1) + ":" + "K" + (maxRow + dt.Rows.Count) + ")";

            sourceSheet.Cells.ImportDataTable(dt, true, "A" + (maxRow));

            sourceSheet.Cells["H" + (maxRow + 1)].Formula = tongCodFormula;
            sourceSheet.Cells["L" + (maxRow + 1)].Formula = tongCuocFormula;
            sourceSheet.Cells.Merge(maxRow, CellsHelper.ColumnNameToIndex("H"), dt.Rows.Count, 1);
            sourceSheet.Cells.Merge(maxRow, CellsHelper.ColumnNameToIndex("L"), dt.Rows.Count, 1);
            Units.setColorCell("H" + (maxRow + 1), sourceSheet, Color.OliveDrab);
            Units.setColorCell("L" + (maxRow + 1), sourceSheet, Color.OliveDrab);

            sourceSheet.Cells.ClearContents(maxRow - 1, 0, maxRow - 1, sourceSheet.Cells.MaxColumn);
            Units.setColorRow(maxRow - 1, sourceSheet, Color.DarkSalmon);


        }

        public DataTable exportDataTable(String AmOrPm)
        {
            String Am = null;
            String Pm = null;
            if (AmOrPm.Equals("Sáng"))
            {
                Am = "Sáng";
                Pm = null;
            }
            else if (AmOrPm.Equals("Chiều"))
            {
                Am = null;
                Pm = "Chiều"; 
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Stt", typeof(int));
            dt.Columns.Add("SoHieu");
            dt.Columns.Add("TenNguoiNhan-DiaChi");
            dt.Columns.Add("TrongLuong", typeof(int));
            dt.Columns.Add("NoiDung");
            dt.Columns.Add(" ");
            dt.Columns.Add("GiaTriTienCOD", typeof(int));
            dt.Columns.Add("TongCOD", typeof(int));
            dt.Columns.Add("CuocKhongGomCod", typeof(int));
            dt.Columns.Add("CuocCodVN", typeof(int));
            dt.Columns.Add("CuocTong", typeof(int));
            dt.Columns.Add("TongCuoc", typeof(int));
            dt.Columns.Add("ngay", typeof(int));
            dt.Columns.Add("thang", typeof(int));
            dt.Columns.Add("nam", typeof(int));
            dt.Columns.Add("sang");
            dt.Columns.Add("chieu");
            int row = 1;
            int stt = 1;

            DateTime date = getDateReport();

            while (row <= addSheet.Cells.MaxRow - 2)
            {
                if (addSheet.Cells["E" + row].Value != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["Stt"] = stt;
                    dr["SoHieu"] = addSheet.Cells["E" + row].Value;
                    dr["TenNguoiNhan-DiaChi"] = addSheet.Cells["I" + row].Value;
                    dr["TrongLuong"] = addSheet.Cells["N" + row].Value;
                    dr["NoiDung"] = addSheet.Cells["R" + row].Value;
                    dr[" "] = "COD";
                    dr["GiaTriTienCOD"] = addSheet.Cells["W" + row].Value;
                    dr["CuocCodVN"] = addSheet.Cells["Y" + row].Value;
                    dr["CuocTong"] = addSheet.Cells["AC" + row].Value;
                    dr["CuocKhongGomCod"] = addSheet.Cells["AC" + row].IntValue - addSheet.Cells["Y" + row].IntValue;
                    dr["ngay"] = date.Day;
                    dr["thang"] = date.Month;
                    dr["nam"] = date.Year;
                    dr["sang"] = Am;
                    dr["chieu"] = Pm;
                    dt.Rows.Add(dr);
                    stt++;
                }
                row++;
            }
            return dt;
        }

        private String getDateString()
        {
            int row = 1;
            while (row <= addSheet.Cells.MaxRow)
            {
                if (addSheet.Cells["T" + row].Value != null)
                    return addSheet.Cells["T" + row].Value.ToString();
                row++;
            }

            return null;
        }

        public DateTime getDateReport()
        {
            List<int> list = new List<int>();
            String filterDate = getDateString();

            String[] split = filterDate.Split(' ');
            foreach (string elem in split)
            {
                try
                {
                    list.Add(Int32.Parse(elem.Trim()));
                }
                catch (FormatException)
                {
                    continue;
                }
            }

            DateTime date = new DateTime(list.ElementAt(2), list.ElementAt(1), list.ElementAt(0));

            return date;
        }

        public void Save(String savePath)
        {
            sourceWorkBook.Worksheets.RemoveAt("Evaluation Warning");
            sourceWorkBook.Save(savePath);
        }

    }
}
