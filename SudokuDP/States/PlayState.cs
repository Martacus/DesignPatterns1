using System;

namespace SudokuDP.States
{
    public class PlayState : BaseGameState
    {

        public PlayState(IGameStateContext context) : base(context)
        {

        }

        public override void RegisterInput(ConsoleKey key)
        {
            Context.ReportLog("PlayState");

            if (key == ConsoleKey.Spacebar)
            {
                Context.SetState(new HelpState(Context));
            }
        }
    }
}
