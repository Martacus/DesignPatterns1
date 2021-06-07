using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    interface ISudokuBoard
    {
        public ICell[] Cells { get; set; }
    }
}
