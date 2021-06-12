using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.States
{
    public interface IGameState
    {
        void RegisterInput(ConsoleKey key);

        void CellInput(ICell cell, char keychar);
    }
}
