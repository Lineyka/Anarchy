﻿using UnityEngine;
using static Anarchy.UI.GUI;

namespace Anarchy.UI
{
    public class GameModesPanel : GUIPanel
    {
        private const int MiscPage = 2;
        private const int PvPPage = 1;
        private const int TitansPage = 0;
        private const int RacingPage = 3;

        private SmartRect left;
        private Rect pageRect;
        private SmartRect rect;
        private SmartRect right;
        private string[] modeSelection;

        public GameModesPanel() : base(nameof(GameModesPanel), -1)
        {
            animator = new Animation.CenterAnimation(this, Helper.GetScreenMiddle(Style.WindowWidth, Style.WindowHeight));
        }

        protected override void DrawMainPart()
        {
            rect.Reset();
            Box(BoxPosition, locale["title"]);
            float offset = new AutoScaleFloat(120f);
            rect.MoveOffsetX(offset);
            rect.width -= offset;
            pageSelection = SelectionGrid(rect, pageSelection, modeSelection, modeSelection.Length);
            rect.ResetX();
            rect.MoveToEndY(BoxPosition, Style.Height);
            rect.MoveToEndX(BoxPosition, Style.LabelOffset);
            rect.width = Style.LabelOffset;
            if (Button(rect, locale["btnClose"]))
            {
                Disable();
            }
        }

        [GUIPage(MiscPage)]
        private void MiscModes()
        {
            left.Reset();
            GameModes.MaxWave.Draw(left, locale);
            left.MoveY();
            GameModes.EndlessRespawn.Draw(left, locale);
            left.MoveY();
            LabelCenter(left, locale["motd"], true);
            TextField(left, GameModes.MOTD, string.Empty, 0f, true);

            right.Reset();
            GameModes.KickEren.Draw(right, locale);
            right.MoveY();
            GameModes.MinimapDisable.Draw(right, locale);
            right.MoveY();
            GameModes.NoGuest.Draw(right, locale);
            right.MoveY();
            GameModes.AntiRevive.Draw(right, locale);
            right.MoveY();
            GameModes.AllowHorses.Draw(right, locale);
            right.MoveY();
            GameModes.AFKKill.Draw(right, locale);
        }

        protected override void OnPanelDisable()
        {
            rect = null;
            left = null;
            right = null;
            GameModes.Save();
        }

        protected override void OnPanelEnable()
        {
            rect = Helper.GetSmartRects(BoxPosition, 1)[0];
            pageRect = new Rect(BoxPosition.x, BoxPosition.y + ((Style.Height + Style.VerticalMargin) * 2f), BoxPosition.width, BoxPosition.height - ((Style.VerticalMargin + Style.Height) * 2f));
            SmartRect[] rects = Helper.GetSmartRects(pageRect, 2);
            left = rects[0];
            right = rects[1];
            modeSelection = locale.GetArray("selections");
        }

        [GUIPage(PvPPage)]
        private void PVPModes()
        {
            left.Reset();
            GameModes.BombMode.Draw(left, locale);
            left.MoveY();
            GameModes.BladePVP.Draw(left, locale);
            left.MoveY();
            GameModes.TeamMode.Draw(left, locale);
            left.MoveY();
            GameModes.PointMode.Draw(left, locale);
            left.MoveY();
            GameModes.FriendlyMode.Draw(left, locale);

            right.Reset();
            GameModes.InfectionMode.Draw(right, locale);
            right.MoveY();
            GameModes.NoAHSSReload.Draw(right, locale);
            right.MoveY();
            GameModes.CannonsKillHumans.Draw(right, locale);
        }

        [GUIPage(RacingPage)]
        private void RacingModes()
        {
            left.Reset();
            GameModes.ASORacing.Draw(left, locale);
            left.MoveY();
            GameModes.RacingRestartTime.Draw(right, locale);

            right.Reset();
            GameModes.RacingStartTime.Draw(right, locale);
            right.MoveY();
            GameModes.RacingFinishersRestart.Draw(right, locale);
            right.MoveY();
            GameModes.RacingTimeLimit.Draw(left, locale);
        }

        [GUIPage(TitansPage)]
        private void TitanModes()
        {
            left.Reset();
            GameModes.CustomAmount.Draw(left, locale);
            left.MoveY();
            GameModes.TitansWaveAmount.Draw(left, locale);
            left.MoveY();
            GameModes.SpawnRate.Draw(left, locale);
            left.MoveY();
            GameModes.SizeMode.Draw(left, locale);

            right.Reset();
            GameModes.HealthMode.Draw(right, locale);
            right.MoveY();
            GameModes.DamageMode.Draw(right, locale);
            right.MoveY();
            GameModes.ExplodeMode.Draw(right, locale);
            right.MoveY();
            GameModes.PunkOverride.Draw(right, locale);
            right.MoveY();
            GameModes.NoRocks.Draw(right, locale);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Disable();
                return;
            }
        }

        public override void OnUpdateScaling()
        {
            animator = new Animation.CenterAnimation(this, Helper.GetScreenMiddle(Style.WindowWidth, Style.WindowHeight));
        }
    }
}
