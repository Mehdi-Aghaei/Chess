using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardLib
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] TheGrid { get; set; }
        public Board(int size)
        {
            // initial size of array
            Size = size;
            // create a new 2d array of type cell
            TheGrid = new Cell[Size, Size];
            // fill the 2d array with new cells, each unique with x and y cordination
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);

                }

            }
        }
        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //step 1 - clear all prev moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].LeaglNextMove = false;
                    TheGrid[i, j].CurrentlyOccupied = false;
                }

            }
            // step 2 - find all legal movies and mark the cell as "legal"
            switch (chessPiece)
            {
                case "Knight":
                    TheGrid[currentCell.ColumnNumber + 2, currentCell.RowNumber + 1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber + 2, currentCell.RowNumber - 1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 2, currentCell.RowNumber + 1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 2, currentCell.RowNumber - 1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber + 1, currentCell.RowNumber - 2].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber + 1, currentCell.RowNumber + 2].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 1, currentCell.RowNumber - 2].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 1, currentCell.RowNumber + 2].LeaglNextMove = true;
                    break;
                case "King":
                    if (IsSafe(currentCell.ColumnNumber + 1, currentCell.RowNumber + 1)) 
                    { 
                        TheGrid[currentCell.ColumnNumber + 1, currentCell.RowNumber + 1].LeaglNextMove = true; 
                    }
                    if (IsSafe(currentCell.ColumnNumber + 1, currentCell.RowNumber - 1))
                    {
                        TheGrid[currentCell.ColumnNumber + 1, currentCell.RowNumber - 1].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber - 1, currentCell.RowNumber + 1))
                    {
                        TheGrid[currentCell.ColumnNumber -1, currentCell.RowNumber + 1].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber - 1, currentCell.RowNumber - 1))
                    {
                        TheGrid[currentCell.ColumnNumber - 1, currentCell.RowNumber - 1].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber, currentCell.RowNumber + 1))
                    {
                        TheGrid[currentCell.ColumnNumber, currentCell.RowNumber + 1].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber , currentCell.RowNumber - 1))
                    {
                        TheGrid[currentCell.ColumnNumber, currentCell.RowNumber - 1].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber+1, currentCell.RowNumber))
                    {
                        TheGrid[currentCell.ColumnNumber+1, currentCell.RowNumber].LeaglNextMove = true;
                    }
                    if (IsSafe(currentCell.ColumnNumber-1, currentCell.RowNumber ))
                    {
                        TheGrid[currentCell.ColumnNumber-1, currentCell.RowNumber ].LeaglNextMove = true;
                    }
                    break;
                case "Rook":
                    TheGrid[currentCell.ColumnNumber , currentCell.RowNumber +1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber , currentCell.RowNumber +2 ].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber , currentCell.RowNumber + 3].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber , currentCell.RowNumber + 4].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber+1, currentCell.RowNumber ].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber+2, currentCell.RowNumber ].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber+3, currentCell.RowNumber ].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber + 4, currentCell.RowNumber ].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 1, currentCell.RowNumber].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 2, currentCell.RowNumber].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 3, currentCell.RowNumber].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber , currentCell.RowNumber-1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber, currentCell.RowNumber - 2].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber, currentCell.RowNumber - 3].LeaglNextMove = true;
                    break;
                case "Bishop":
                    TheGrid[currentCell.ColumnNumber - 1, currentCell.RowNumber + 1].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 2, currentCell.RowNumber + 2].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber - 3, currentCell.RowNumber + 3].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber, currentCell.RowNumber + 4].LeaglNextMove = true;
                    TheGrid[currentCell.ColumnNumber + 1, currentCell.RowNumber + 1].LeaglNextMove = true;
                    break;
                case "Queen":
                    TheGrid[currentCell.ColumnNumber, currentCell.RowNumber+7].LeaglNextMove = true;
                    break;
                default:
                    break;

            }
            TheGrid[currentCell.ColumnNumber, currentCell.RowNumber].CurrentlyOccupied=true;
        }

        private bool IsSafe(int v1, int v2)
        {
            try
            {
                if(v1 < TheGrid.GetLength(0) && v2 < TheGrid.GetLength(1) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException
                throw new ArgumentOutOfRangeException("index parameter is out of range.", e);
            }
        }
    }
}
 