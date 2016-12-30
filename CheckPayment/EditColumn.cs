using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
namespace CheckPayment
{
    public class EditColumn
    {

        public EditColumn()
        {
            // TODO: Complete member initialization
        }

        public static void EditCoulumn(Worksheet sheet, String cellName, Object content)
        {
            int row,column;
            CellsHelper.CellNameToIndex(cellName, out row, out column);

            sheet.Cells[cellName].PutValue(content);
            sheet.AutoFitColumn(column);
        }
    }
}
