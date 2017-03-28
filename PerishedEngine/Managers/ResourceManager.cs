using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PerishedEngine.Managers
{
    public class ResourceManager
    {
        private static ResourceManager instance;

        private ResourceManager() { }

        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }
                return instance;
            }
        }

        public Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();

        public ContentManager Content;

        private bool loaded = false;

        /// <summary>
        /// Loads all the content (Sprites, fonts etc...)
        /// </summary>
        /// <param name="Content">The Content manager we want to load from</param>
        public virtual void LoadAllContent(ContentManager Content)
        {
            this.Content = Content;
            if (!loaded)
            {
                Sprites.Add("Panel", Content.Load<Texture2D>("Sprites/UI/Panel"));
                Sprites.Add("Button", Content.Load<Texture2D>("Sprites/UI/Button"));
                Sprites.Add("LightButton", Content.Load<Texture2D>("Sprites/UI/LightButton"));
                Sprites.Add("SliderKnob", Content.Load<Texture2D>("Sprites/UI/sliderKnob"));

                Fonts.Add("FontHuge", Content.Load<SpriteFont>("Fonts/FontHuge"));
                Fonts.Add("FontBig", Content.Load<SpriteFont>("Fonts/FontBig"));
                Fonts.Add("FontMedium", Content.Load<SpriteFont>("Fonts/FontMedium"));
                Fonts.Add("FontSmall", Content.Load<SpriteFont>("Fonts/FontSmall"));
                loaded = true;
            }
        }

    }
}
