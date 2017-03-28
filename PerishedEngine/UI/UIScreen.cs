﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PerishedEngine.UI
{
    public class UIScreen
    {
        public string name;
        public List<UIElement> frontLayer = new List<UIElement>();
        public List<UIElement> middleLayer = new List<UIElement>();
        public List<UIElement> bottomLayer = new List<UIElement>();

        public virtual void Initialize()
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Initialize();
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Initialize();
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Initialize();
            }
        }

        public virtual void LoadContent()
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].LoadContent();
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].LoadContent();
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].LoadContent();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Update(gameTime);
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Update(gameTime);
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Draw(spriteBatch);
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Draw(spriteBatch);
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Draw(spriteBatch);
            }
        }

        public UIElement CreateUIElement(UIElement element, UILayer layer)
        {
            switch (layer)
            {
                case UILayer.Front:
                    frontLayer.Add(element);
                    break;
                case UILayer.Middle:
                    middleLayer.Add(element);
                    break;
                case UILayer.Bottom:
                    bottomLayer.Add(element);
                    break;
            }

            element.Initialize();
            element.LoadContent();
            return element;
        }
    }
}
