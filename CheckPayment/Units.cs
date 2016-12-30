using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Data;
using System.Drawing;
namespace CheckPayment
{

    class Units
    {
        public Units()
        {
        }

        public static Dictionary<int, int> getMapRowIndex(Worksheet sourceSheet, Worksheet checkSheet)
        {
            Dictionary<int, int> MapRowIndex = new Dictionary<int, int>();

            FindOptions find = new FindOptions();
            find.LookInType = LookInType.Values;
            find.LookAtType = LookAtType.EntireContent;

            Cell cell;
            int rowSource, columnSource;
            int rowCheck = 2;
            String cellNameCheck;

            while (rowCheck <= (checkSheet.Cells.MaxDataRow + 1))
            {
                cellNameCheck = "B" + rowCheck;
                if ((cell = sourceSheet.Cells.Find(checkSheet.Cells[cellNameCheck].Value, null, find)) != null)
                {
                    CellsHelper.CellNameToIndex(cell.Name, out rowSource, out columnSource);
                    MapRowIndex.Add(rowSource + 1, rowCheck);
                }

                rowCheck++;
            }

            return MapRowIndex;
        }

        public static void deleteFalseId(Dictionary<int, int> MapRowIndex, Worksheet checkSheet)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(Int32));
            dt.Columns.Add("Mã Vận Đơn", typeof(String));
            dt.Columns.Add("Số tiền", typeof(Int32));
            dt.Columns.Add("Tổng Tiền", typeof(Int32));
            int stt = 1;
            for (int i = 2; i < checkSheet.Cells.MaxDataRow - 1; i++)
            {
                if (!MapRowIndex.ContainsValue(i))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = stt;
                    dr[1] = checkSheet.Cells["B" + i].StringValue;
                    dr[2] = checkSheet.Cells["C" + i].IntValue;
                    dt.Rows.Add(dr);
                    stt++;
                }
            }
            checkSheet.Cells.DeleteColumns(CellsHelper.ColumnNameToIndex("A"), 4, true);
            checkSheet.Cells.ImportDataTable(dt, true, "A1");

            String tongCodFormula = "=SUM(" + "C" + 2 + ":" + "C" + (checkSheet.Cells.MaxDataRow + 1) + ")";
            checkSheet.Cells["D2"].Formula = tongCodFormula;
            Units.setColorCell("D2", checkSheet, Color.Pink);

            checkSheet.AutoFitColumns();
        }


        public static void setColorCell(String cellName, Worksheet sheet, Color color)
        {
            Style style = sheet.Cells[cellName].GetStyle();
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = color;

            sheet.Cells[cellName].SetStyle(style);
        }
    }
}
