using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    interface ISudokuBoard
    {
        public ICell[] Cells { get; set; }
        public ICell[] Rows { get; set; }
        public ICell[] Columns { get; set; }
    }
}
