using System;
using ChessBoardLib;
namespace ChessConsoleApp
{
    class Program
    {
        static Board my_board = new Board(8);
        static void Main(string[] args)
        {
            // Show Empty Chess Board
            PrintBoard(my_board);
            // ask the user an x and y cordinate where we will place a piece
            Cell currentCell = SetCurrentCell();
            currentCell.CurrentlyOccupied = true;
            // calculate all legal moves for the piece
            my_board.MarkNextLegalMoves(currentCell, "King");
            // print the  chess board, Use and X for occupied square Use a + for legal move, use . for empty cell
            PrintBoard(my_board);
        }

        private static Cell SetCurrentCell()
        {
            // get x and y form user
            Console.WriteLine("Enter current row number ");
            int currentRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter current column number");
            int currentCol = int.Parse(Console.ReadLine());
            //my_board.TheGrid[currentRow, currentCol].CurrentlyOccupied = true;
            return my_board.TheGrid[currentRow, currentCol];
        }

        private static void PrintBoard(Board my_board)
        {
            // print the chess board to console Use x for the piece location , + foe legal moves, . for empty square
            for (int i = 0; i < my_board.Size; i++)
            {
                for (int j = 0; j < my_board.Size; j++)
                {
                    Cell c = my_board.TheGrid[i, j];
                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    else if (c.LeaglNextMove == true)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("===========================");
        }
    }
}
