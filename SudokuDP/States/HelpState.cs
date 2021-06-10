using System;

namespace SudokuDP.States
{
    public class HelpState : BaseGameState
    {

        public HelpState(IGameStateContext context) : base(context)
        {
          
        }

        public override void RegisterInput(ConsoleKey key)
        {
            Context.ReportLog("HelpState");

            if (key == ConsoleKey.Spacebar)
            {
                Context.SetState(new PlayState(Context));
            }
        }
    }
}