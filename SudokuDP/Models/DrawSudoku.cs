using System;
using static System.Console;

namespace SudokuDP.Models
{
    class DrawSudoku
    {
        public ISudokuBoard board;

        public DrawSudoku(ISudokuBoard board)
        {
            this.board = board;
        }

        public void SetColor(ICell cell, int xCoord, int yCoord)
        {
            if (cell.isPermanent)
            {
                ForegroundColor = ConsoleColor.Red;
                BackgroundColor = ConsoleColor.Yellow;
            }

            if (cell.IsHelper)
            {
                ForegroundColor = ConsoleColor.Red;
                BackgroundColor = ConsoleColor.Yellow;
            }

            if (cell.xCoord == xCoord && cell.yCoord == yCoord)
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
        }

        public void ResetColor()
        {
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
        }
    }
}
