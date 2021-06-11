using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class Cell : ICell
    {
        public Cell(int number, int x, int y): base(number)
        {
            this.xCoord = x;
            this.yCoord = y;
        }

        public override bool numberFits(int x, int y)
        {
            return true;
        }
    }
}
