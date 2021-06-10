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

        public virtual void RegisterInput(ConsoleKey key)
        {
            throw new NotImplementedException();
        }
    }
}
