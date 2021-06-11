using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class Row : ICell
    {
        public Row(int rowSize): base(0)
        {
            this.children = new ICell[rowSize];
        }

        public override bool numberFits(int number)
        {
            bool found = false;
            foreach(ICell cell in this.children)
            {
                if(cell.number == number)
                {
                    found = true;
                }
            }

            return !found;
        }
    }
}
