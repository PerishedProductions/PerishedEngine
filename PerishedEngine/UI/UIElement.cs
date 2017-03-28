using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PerishedEngine.UI
{
    public enum ColorTheme { Dark, Light, None }
    public enum UILayer { Front, Middle, Bottom }

    public class UIElement
    {

        public UILayer layer;

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
