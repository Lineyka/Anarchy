﻿using UnityEngine;

namespace Anarchy.UI.Animation
{
    public class CenterAnimation : Animation
    {
        private readonly Rect defaultRect;
        private Rect endPosition;
        private float heightKoeff;
        private Rect position;

        public float CloseSpeed { get; set; }

        public float OpenSpeed { get; set; }

        public CenterAnimation(GUIBase @base, Rect pos) : this(@base, pos, 650f, 1300f)
        {
        }

        public CenterAnimation(GUIBase @base, Rect pos, float openSpeed, float closeSpeed) : base(@base)
        {
            defaultRect = pos;
            heightKoeff = pos.height / pos.width;
            this.OpenSpeed = openSpeed;
            this.CloseSpeed = closeSpeed;
        }

        protected override bool Close()
        {
            Draw();
            float speed = Time.timeScale == 0f ? CloseSpeed / 60f : Time.deltaTime * CloseSpeed;
            position.x += speed;
            position.y += speed * heightKoeff;
            position.width -= (speed * 2f);
            position.height -= (speed * 2f) * heightKoeff;
            return position.x < endPosition.x && position.y < endPosition.y;
        }

        private void Draw()
        {
            GUI.Box(position, string.Empty);
        }

        protected override void OnStartClose()
        {
            position = Helper.GetScreenMiddle(defaultRect.width, defaultRect.height);
            endPosition = new Rect(Style.ScreenWidth / 2f, Style.ScreenHeight / 2f, 0f, 0f);
        }

        protected override void OnStartOpen()
        {
            position = new Rect(Style.ScreenWidth / 2f, Style.ScreenHeight / 2f, 0f, 0f);
            endPosition = Helper.GetScreenMiddle(defaultRect.width, defaultRect.height);
        }

        protected override bool Open()
        {
            Draw();
            float speed = Time.timeScale == 0f ? OpenSpeed / 60f : Time.deltaTime * OpenSpeed;
            position.x -= speed;
            position.y -= speed * heightKoeff;
            position.width += (speed * 2f);
            position.height += (speed * 2f) * heightKoeff;
            return position.x > endPosition.x && position.y > endPosition.y;
        }
    }
}