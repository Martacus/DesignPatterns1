using SudokuDP.States;
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
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public ISudokuBoard solvedBoard { get; set; }

        public void drawBoard(string CurrentState);
        public bool solve();
        public bool valid(ICell cell, int number);
        public void check();
    }
}
