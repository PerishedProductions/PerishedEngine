using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Graphics;
using System;
using System.Collections.Generic;

namespace PerishedEngine.UI
{
    public class UIPanel : UIElement
    {
        public Rectangle size;

        String textureName;
        NineSlicedSprite sprite;

        public ColorTheme windowTheme = ColorTheme.Dark;
        public bool visible = true;

        public List<UIElement> elements = new List<UIElement>();

        public UIPanel(Rectangle size)
        {
            this.size = size;
        }

        public UIPanel(Rectangle size, ColorTheme theme)
        {
            this.size = size;
            this.windowTheme = theme;
        }

        public override void Initialize()
        {
            switch (windowTheme)
            {
                case ColorTheme.Dark:
                    textureName = "Panel";
                    break;
                case ColorTheme.Light:
                    textureName = "Panel";
                    break;
                case ColorTheme.None:
                    textureName = null;
                    break;
            }
            sprite = new NineSlicedSprite(textureName, size);
            sprite.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].Update(gameTime);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {

                sprite.Draw(spriteBatch);

                //Fix text rendering wrong
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].Draw(spriteBatch);
                }
            }
        }

        public UIElement CreateUIElement(UIElement element)
        {
            elements.Add(element);
            element.Initialize();
            element.LoadContent();
            return element;
        }
    }
}
