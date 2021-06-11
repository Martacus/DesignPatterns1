using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class Cluster : ICell
    {
        public Cluster(int columnSize) : base(0)
        {
            this.children = new ICell[columnSize];
        }

        public override bool numberFits(int x, int y)
        {
            var checkCell = getCell(x, y);
            List<ICell> foundCells = new List<ICell>();
            foreach (ICell cell in this.children)
            {
                if (cell.number == checkCell.number)
                {
                    foundCells.Add(cell);
                }
            }

            if (foundCells.Count > 1)
            {
                return false;
            }

            return true;
        }
    }
}
