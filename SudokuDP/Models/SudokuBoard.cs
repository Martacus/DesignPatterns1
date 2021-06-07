using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    class SudokuBoard : ISudokuBoard
    {

        public ICell[] Cells { get;  set; }
        public ICell[] Rows { get; set; }
        public ICell[] Columns { get; set; }

        public SudokuBoard(int cellsAmount)
        {
            this.Cells = new ICell[cellsAmount];
        }

       
    }
}
