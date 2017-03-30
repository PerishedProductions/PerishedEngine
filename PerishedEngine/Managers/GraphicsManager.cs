using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.UI;

namespace PerishedEngine.Managers
{
    public class GraphicsManager
    {

        public static GraphicsManager Instance { get; } = new GraphicsManager();

        private GraphicsManager() { }

        private SpriteBatch spriteBatch;

        public int windowWidth { get; set; }
        public int windowHeight { get; set; }

        public SpriteFont smallFont;
        public SpriteFont mediumFont;
        public SpriteFont bigFont;
        public SpriteFont hugeFont;

        public void Initialize(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void LoadContent()
        {
            ResourceManager.Instance.Fonts.TryGetValue("FontSmall", out smallFont);
            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out mediumFont);
            ResourceManager.Instance.Fonts.TryGetValue("FontBig", out bigFont);
            ResourceManager.Instance.Fonts.TryGetValue("FontHuge", out hugeFont);
        }

        public void DrawUISprite(Texture2D sprite, Vector2 position, Color color)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.Draw(sprite, position, color);
            spriteBatch.End();
        }

        public void DrawUISprite(Texture2D sprite, Rectangle rect, Color color)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.Draw(sprite, rect, color);
            spriteBatch.End();
        }

        public void DrawUISprite(Texture2D sprite, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, color);
            spriteBatch.End();
        }

        //TODO: Revise - spriteBatch.DrawString(font, text, position, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1.0f);
        public void DrawUIString(TextSize size, string text, Vector2 position, Color color)
        {
            SpriteFont font;
            switch (size)
            {
                case TextSize.Small:
                    font = smallFont;
                    break;
                case TextSize.Medium:
                    font = mediumFont;
                    break;
                case TextSize.Big:
                    font = bigFont;
                    break;
                case TextSize.Huge:
                    font = hugeFont;
                    break;
                default:
                    font = smallFont;
                    break;
            }
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.DrawString(font, text, position, color);
            spriteBatch.End();
        }

    }
}
