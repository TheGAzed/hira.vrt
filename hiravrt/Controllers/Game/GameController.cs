using hiravrt.Models.Game;
using System.Diagnostics;

namespace hiravrt.Controllers.Game
{
    public class GameController
    {
        public LookUp LookUp { get; } = new LookUp();
        public EitherOrModel EitherOrModel { get; }

        public GameController()
        {
            EitherOrModel = new EitherOrModel(LookUp);
        }

        public string EitherOr() => "/eitheror";
        public string PickFour() => "/pickfour";

        public void UpdateModel(GameModel model, string syllable)
        {
            model.NextMove(syllable);
        }
    }
}
