using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.States
{
    public interface IGameState
    {
        void RegisterInput(ConsoleKey key);
    }
}
