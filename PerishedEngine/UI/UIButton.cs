using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Graphics;
using PerishedEngine.Managers;
using System;

namespace PerishedEngine.UI
{
    public class UIButton : UIElement
    {

        private UIText text;
        private Rectangle size;
        private NineSlicedSprite sprite;
        private NineSlicedSprite spriteHover;
        public string textureName;

        public bool Selected { get; set; } = false;

        public ColorTheme windowTheme = ColorTheme.Dark;

        public UIButton(String text, Rectangle size, UIScreen canvas)
        {
            this.size = size;
            this.text = (UIText)canvas.CreateUIElement(new UIText(size, text, Alignment.Center), UILayer.Front);
        }

        public UIButton(String text, Rectangle size, ColorTheme theme, UIScreen canvas)
        {
            this.size = size;
            this.text = (UIText)canvas.CreateUIElement(new UIText(size, text, Alignment.Center), UILayer.Front);
            this.windowTheme = theme;
        }

        public event Action onButtonClicked;

        public void OnButtonClicked()
        {
            if (onButtonClicked != null)
            {
                onButtonClicked.Invoke();
            }
        }

        public override void Initialize()
        {
            switch (windowTheme)
            {
                case ColorTheme.Dark:
                    textureName = "Button";
                    break;
                case ColorTheme.Light:
                    textureName = "LightButton";
                    break;
            }
        }

        public override void LoadContent()
        {
            sprite = new NineSlicedSprite(textureName, size);
            sprite.LoadContent();
            spriteHover = new NineSlicedSprite("LightButton", size);
            spriteHover.LoadContent();
            text.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Selected = false;

            if (size.Contains(InputManager.Instance.getMousePos()))
            {
                Selected = true;
                if (InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    OnButtonClicked();
                }
                if (InputManager.Instance.mouseIsDown(MouseButton.Left))
                {
                    Selected = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Selected)
            {
                sprite.Draw(spriteBatch);
            }
            else
            {
                spriteHover.Draw(spriteBatch);
            }
        }
    }
}
