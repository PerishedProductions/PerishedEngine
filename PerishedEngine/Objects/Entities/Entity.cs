using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Managers;

namespace PerishedEngine.Objects
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public bool IsCollisionActive { get; set; }

        public bool Active { get; set; } = true;
        public float RotationAngle { get; set; }
        public float RotationSpeed { get; set; }
        public float Speed { get; set; }
        public Vector2 Origin { get; set; }

        public Texture2D sprite;
        protected Texture2D collisionSprite;
        protected Texture2D box;

        /// <summary>
        /// Initializes the entity by loading it's sprite and setting it's origin
        /// </summary>
        /// <param name="spriteName"></param>
        public virtual void Initialize(string spriteName)
        {
            ResourceManager.Instance.Sprites.TryGetValue(spriteName, out sprite);
            ResourceManager.Instance.Sprites.TryGetValue("Panel", out box);
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        /// <summary>
        /// Initializes the entity by loading it's sprite and setting it's origin
        /// </summary>
        /// <param name="spriteName"></param>
        public virtual void Initialize(string spriteName, string collisionSpriteName)
        {
            ResourceManager.Instance.Sprites.TryGetValue(collisionSpriteName, out collisionSprite);
            ResourceManager.Instance.Sprites.TryGetValue("Window", out box);
            Initialize(spriteName);
        }

        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the entity
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)Position.X, (int)Position.Y, sprite.Width, sprite.Height), null, Color.White, RotationAngle, Origin, SpriteEffects.None, 0);
        }
    }
}