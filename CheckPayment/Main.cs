using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Drawing;
namespace CheckPayment
{


    public class Main
    {
        private String sourcePath;
        private String savePath;
        private Worksheet sourceSheet;
        private Worksheet checkSheet;
        Workbook workBook;
        public Main(String sourcePath, String savePath)
        {
            this.sourcePath = sourcePath;
            this.savePath = savePath;
            workBook = new Workbook(sourcePath);
            sourceSheet = workBook.Worksheets[0];
            checkSheet = workBook.Worksheets[1];
        }

        public void Run()
        {
            String nameColumn1 = "ĐÃ THANH TOÁN";
            String nameColumn2 = "GHI CHÚ";

            addColumn(nameColumn1);
            addColumn(nameColumn2);

            Dictionary<int, int> MapRowIndex = Units.getMapRowIndex(sourceSheet, checkSheet);


            new HandleID(sourceSheet, checkSheet).SetColorAndTick(MapRowIndex, Color.Yellow, sourceSheet.Cells.MaxDataColumn - 1);

            new HandleMoney(sourceSheet, checkSheet).setNode(MapRowIndex, sourceSheet.Cells.MaxDataColumn);

            Units.deleteFalseId(MapRowIndex, checkSheet);

            Save();

        }

        private void Save()
        {
            workBook.Worksheets.RemoveAt("Evaluation Warning");
            workBook.Save(savePath);
        }

        private void addColumn(String nameColumn)
        {
            FindOptions find = new FindOptions();
            find.LookInType = LookInType.Values;
            find.LookAtType = LookAtType.EntireContent;

            if (sourceSheet.Cells.Find(nameColumn, null, find) == null)
            {
                sourceSheet.Cells.InsertColumn(sourceSheet.Cells.MaxColumn + 1);
                sourceSheet.Cells[CellsHelper.ColumnIndexToName(sourceSheet.Cells.MaxColumn) + 2].PutValue(nameColumn);
                
            }
        }
    }
}
