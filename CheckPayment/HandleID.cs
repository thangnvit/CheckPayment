using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Drawing;
namespace CheckPayment
{
    public class HandleID
    {
        private Worksheet sourceSheet;
        private Worksheet checkSheet;

        public HandleID(Worksheet sourceSheet, Worksheet checkSheet)
        {
            this.sourceSheet = sourceSheet;
            this.checkSheet = checkSheet;
        }

        public void SetColorAndTick(Dictionary<int, int> MapRowIndex, Color color, int columnTick)
        {
            Style styleDefault = sourceSheet.Cells.Columns[CellsHelper.ColumnNameToIndex("H")].Style;
            List<int> listRowIndex = MapRowIndex.Keys.ToList();
            foreach (int row in listRowIndex)
            {
                setColorRow(row - 1, sourceSheet, color);
                EditColumn.EditCoulumn(sourceSheet, CellsHelper.CellIndexToName(row - 1, columnTick), "X");
            }

            setDefaultColorColumn(CellsHelper.ColumnNameToIndex("H"), sourceSheet, styleDefault);
            setDefaultColorColumn(CellsHelper.ColumnNameToIndex("L"), sourceSheet, styleDefault);
            setColorRow(0, sourceSheet, Color.White);

        }



        static void setColorRow(int row, Worksheet sheet, Color color)
        {
            Cells cell = sheet.Cells;

            Style style = cell.Rows[row].Style;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = color;

            StyleFlag styleFlag = new StyleFlag();
            styleFlag.CellShading = true;

            cell.ApplyRowStyle(row, style, styleFlag);
        }

        static void setDefaultColorColumn(int column, Worksheet sheet, Style styleDefault)
        {
            Cells cell = sheet.Cells;

            Style style = styleDefault;
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = Color.OliveDrab;

            StyleFlag styleFlag = new StyleFlag();
            styleFlag.CellShading = true;

            cell.ApplyColumnStyle(column, style, styleFlag);
        }
    }


}
