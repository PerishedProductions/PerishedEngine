using Microsoft.Xna.Framework;

namespace PerishedEngine.Objects.Components.Physics
{

    public enum CollisionType { Static, Dynamic };

    class CollisionBox
    {

        public CollisionType collisionType = CollisionType.Static;
        private Entity parent;

        public CollisionBox(Entity parent)
        {
            this.parent = parent;
        }

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                (int)parent.Position.X - parent.sprite.Width / 2,
                (int)parent.Position.Y - parent.sprite.Height / 2,
                parent.sprite.Width,
                parent.sprite.Height);
            }
        }

        /// <summary>
        /// Checks for collision by comparing two rectangles
        /// </summary>
        /// <param name="otherEntity">The entity we want to compare rectangles with</param>
        /// <returns></returns>
        //public virtual bool CheckCollision(Entity otherEntity)
        //{
        //return this.BoundingBox.Intersects(otherEntity.BoundingBox);
        //}

        //public abstract void HandleCollision(Entity otherEntity);

    }
}
