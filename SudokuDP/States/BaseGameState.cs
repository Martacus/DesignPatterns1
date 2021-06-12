using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.States
{
    public abstract class BaseGameState : IGameState
    {

        public BaseGameState(IGameStateContext context)
        {
            Context = context; 
        }

        public IGameStateContext Context { get; }

        public virtual void CellInput(ICell cell, char keychar)
        {
            throw new NotImplementedException();
        }

        public virtual void RegisterInput(ConsoleKey key)
        {
            throw new NotImplementedException();
        }
    }
}
