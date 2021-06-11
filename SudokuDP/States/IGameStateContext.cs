using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.States
{
    public interface IGameStateContext
    {
        public string CurrentState { get; set; }

        void SetState(IGameState newState);

        void SetCurrentState(string key);
    }
}
