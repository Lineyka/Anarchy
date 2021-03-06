﻿namespace GameLogic
{
    internal class KillTitanLogic : GameLogic
    {
        public KillTitanLogic() : base()
        {

        }

        public KillTitanLogic(GameLogic logic) : this()
        {
            CopyFrom(logic);
        }

        public override void OnSomeOneIsDead(int id)
        {
            if (!Round.IsWinning && !Round.IsLosing)
            {
                FengGameManagerMKII.FGM.StartCoroutine(Anarchy.GameModes.CheckGameEnd());
            }
        }

        public override void OnTitanDown(string name, bool isLeaving)
        {
            if (CheckIsTitanAllDie())
            {
                GameWin();
                IN_GAME_MAIN_CAMERA.MainCamera.gameOver = true;
            }
        }

        protected override void UpdateLabels()
        {
            base.UpdateLabels();
            if (!Multiplayer)
            {
                Optimization.Labels.TopLeft = Lang.Format("singleState", FengGameManagerMKII.FGM.SingleKills.ToString(), FengGameManagerMKII.FGM.SingleMax.ToString(), FengGameManagerMKII.FGM.SingleTotal.ToString());
            }
        }
    }
}
