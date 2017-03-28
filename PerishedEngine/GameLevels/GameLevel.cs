﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Managers;

namespace PerishedEngine.GameLevels
{
    public class GameLevel
    {
        public virtual void Initialize()
        {

        }

        public virtual void InitializeCam(Viewport viewport) { }

        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}