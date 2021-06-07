using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    abstract class ICell
    {
        public ICell[] children;
        public int number { get; set; }
        
        public ICell(int number)
        {
            this.number = number;
        }

        public abstract bool numberFits(int number);
    }
}
