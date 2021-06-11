using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Models
{
    abstract class ICell
    {
        public ICell[] children;
        public int number { get; set; }
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public bool isPermanent { get; set; }
        public bool IsHelper { get; set; }
        public bool IsValid { get; set; }

        public ICell(int number)
        {
            this.number = number;
        }

        public ICell getCell(int x, int y)
        {
            foreach (ICell cell in this.children)
            {
                if (cell.xCoord == x && cell.yCoord == y)
                {
                    return cell;
                }
            }
            return null;
        }

        public abstract bool numberFits(int number);

        public bool hasCell(int x, int y)
        {
            foreach (ICell cell in this.children)
            {
                if (cell.xCoord == x && cell.yCoord == y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool addCell(ICell cell)
        {
            for (int i = 0; i < this.children.Length; i++)
            {
                if (this.children[i] == null)
                {
                    this.children[i] = cell;
                    return true;
                }
            }

            return false;
        }
    }
}
