using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Drawing;
namespace CreateReport
{
    class Units
    {
        public Units()
        {
        }

        public static void setColorRow(int row, Worksheet sheet, Color color)
        {
            Cells cell = sheet.Cells;

            Style style = cell.Rows[row].Style;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = color;

            StyleFlag styleFlag = new StyleFlag();
            styleFlag.CellShading = true;

            cell.ApplyRowStyle(row, style, styleFlag);
        }

        public static void setDefaultColorColumn(int column, Worksheet sheet, Style styleDefault)
        {
            Cells cell = sheet.Cells;

            Style style = styleDefault;

            StyleFlag styleFlag = new StyleFlag();
            styleFlag.CellShading = true;

            cell.ApplyColumnStyle(column, style, styleFlag);
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
