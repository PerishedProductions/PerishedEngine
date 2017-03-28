using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Managers;

namespace PerishedEngine.UI
{
    public enum Alignment { Left, Center, Right }
    public enum TextSize { Small, Medium, Big, Huge }

    public class UIText : UIElement
    {

        public string text;
        public Vector2 position;
        private Rectangle container;
        private Alignment alignment = Alignment.Left;
        private TextSize textSize = TextSize.Medium;

        public UIText(Vector2 pos, string text)
        {
            this.position = pos;
            this.text = text;
        }

        public UIText(Rectangle container, string text, Alignment alignment)
        {
            this.text = text;
            this.alignment = alignment;
            this.container = container;
        }

        public UIText(Rectangle container, string text, Alignment alignment, TextSize textSize)
        {
            this.text = text;
            this.alignment = alignment;
            this.container = container;
            this.textSize = textSize;
        }

        public override void LoadContent()
        {
            if (container != null)
            {
                switch (alignment)
                {
                    case Alignment.Left:
                        break;
                    case Alignment.Center:
                        //TODO: revise
                        position = new Vector2(container.X + container.Width / 2 - GraphicsManager.Instance.mediumFont.MeasureString(text).X / 2, container.Y + container.Height / 2 - GraphicsManager.Instance.mediumFont.MeasureString(text).Y / 2);
                        break;
                    case Alignment.Right:
                        break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsManager.Instance.DrawUIString(textSize, text, position, Color.White);
        }

    }
}
