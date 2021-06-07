using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class Cell : ICell
    {
        public Cell(int number): base(number)
        {

        }

        public override bool numberFits(int number)
        {
            return number == 0;
        }
    }
}
