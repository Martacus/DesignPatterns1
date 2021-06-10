using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.States
{
    public interface IGameStateContext
    {
        void SetState(IGameState newState);

        void ReportLog(string key);
    }
}
