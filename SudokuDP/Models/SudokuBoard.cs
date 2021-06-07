using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class SudokuBoard : ISudokuBoard
    {
        private ICell[] cells;

        public ICell[] Cells { get => cells; set => cells = value; }

        public SudokuBoard(int cellsAmount)
        {
            this.cells = new ICell[cellsAmount];
        }
    }
}
