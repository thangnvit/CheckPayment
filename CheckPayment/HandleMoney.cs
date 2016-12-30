using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Drawing;
namespace CheckPayment
{
    public class HandleMoney
    {
        private Worksheet sourceSheet;
        private Worksheet checkSheet;

        public HandleMoney(Worksheet sourceSheet, Worksheet checkSheet)
        {
            this.sourceSheet = sourceSheet;
            this.checkSheet = checkSheet;
        }

        public void setNode(Dictionary<int, int> MapRowIndex, int columnWirte)
        {
            List<int> RowIndexSource = MapRowIndex.Keys.ToList();
            List<int> RowIndexCheck = MapRowIndex.Values.ToList();

            for (int i = 0; i < RowIndexSource.Count; i++)
            {
                int moneySource = sourceSheet.Cells["G" + RowIndexSource[i]].IntValue;
                int moneyCheck = checkSheet.Cells["C" + RowIndexCheck[i]].IntValue;
                if (moneySource > moneyCheck)
                {
                    EditColumn.EditCoulumn(sourceSheet, CellsHelper.CellIndexToName(RowIndexSource[i] - 1, columnWirte), "Còn nợ " + (moneySource - moneyCheck));
                }
            }
        }
    }
}
