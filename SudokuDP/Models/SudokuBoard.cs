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

        public SudokuBoard(int cellsAmount, int size)
        {
            this.Cells = new ICell[cellsAmount];
            this.Rows = new ICell[size * 2];
            this.Columns = new ICell[size];
        }

       
    }
}
