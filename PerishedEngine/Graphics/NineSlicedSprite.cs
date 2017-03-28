using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Managers;

namespace PerishedEngine.Graphics
{
    public class NineSlicedSprite
    {

        private int TopPadding = 5;
        private int LeftPadding = 5;
        private int BottomPadding = 5;
        private int RightPadding = 5;
        private string textureName;
        private Texture2D sprite;

        public Rectangle size;

        public NineSlicedSprite(string textureName, Rectangle size)
        {
            this.textureName = textureName;
            this.size = size;
        }

        public virtual void LoadContent()
        {
            if (textureName != null)
            {
                ResourceManager.Instance.Sprites.TryGetValue(textureName, out sprite);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var sourcePathces = CreatePatches(sprite.Bounds);
            var destinationPatches = CreatePatches(size);

            for (var i = 0; i < sourcePathces.Length; i++)
            {
                GraphicsManager.Instance.DrawUISprite(sprite, destinationPatches[i], sourcePathces[i], Color.White);
            }
        }

        private Rectangle[] CreatePatches(Rectangle rectangle)
        {
            var x = rectangle.X;
            var y = rectangle.Y;
            var w = rectangle.Width;
            var h = rectangle.Height;
            var middleWidth = w - LeftPadding - RightPadding;
            var middleHeight = h - TopPadding - BottomPadding;
            var bottomY = y + h - BottomPadding;
            var rightX = x + w - RightPadding;
            var leftX = x + LeftPadding;
            var topY = y + TopPadding;
            var patches = new[]
            {
                new Rectangle(x,      y,        LeftPadding,  TopPadding),      // top left
                new Rectangle(leftX,  y,        middleWidth,  TopPadding),      // top middle
                new Rectangle(rightX, y,        RightPadding, TopPadding),      // top right
                new Rectangle(x,      topY,     LeftPadding,  middleHeight),    // left middle
                new Rectangle(leftX,  topY,     middleWidth,  middleHeight),    // middle
                new Rectangle(rightX, topY,     RightPadding, middleHeight),    // right middle
                new Rectangle(x,      bottomY,  LeftPadding,  BottomPadding),   // bottom left
                new Rectangle(leftX,  bottomY,  middleWidth,  BottomPadding),   // bottom middle
                new Rectangle(rightX, bottomY,  RightPadding, BottomPadding)    // bottom right
            };
            return patches;
        }

    }
}
