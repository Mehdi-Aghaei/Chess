using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardLib
{
    public class Cell
    {
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        public bool CurrentlyOccupied  { get; set; }
        public bool LeaglNextMove { get; set; }
        public Cell(int rowNumber, int columnNumber)
        {
            ColumnNumber = rowNumber;
            RowNumber = columnNumber;
            
        }


    }
}
