using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Managers;
using System.Collections.Generic;

namespace PerishedEngine.UI
{
    class UIMenuBar : UIElement
    {
        private UIPanel panel;
        private List<UIButton> uiButtons = new List<UIButton>();


        public override void Initialize()
        {
            panel = new UIPanel(new Rectangle(0, 0, GraphicsManager.Instance.windowWidth, 30), ColorTheme.Light);
            panel.Initialize();
            uiButtons.Add(new UIButton("File", new Rectangle(0, 0, 100, 30)));
            uiButtons.Add(new UIButton("Edit", new Rectangle(100, 0, 100, 30)));
            uiButtons.Add(new UIButton("Help", new Rectangle(200, 0, 100, 30)));
            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].Initialize();
            }
        }

        public override void LoadContent()
        {
            panel.LoadContent();
            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            panel.Update(gameTime);
            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            panel.Draw(spriteBatch);

            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].Draw(spriteBatch);
            }
        }

    }
}
