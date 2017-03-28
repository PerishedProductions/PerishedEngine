using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.Graphics;
using PerishedEngine.Managers;
using System;
using System.Diagnostics;

namespace PerishedEngine.UI
{
    class UISlider : UIElement
    {

        private float baseValue = 0;
        private float maxValue = 10;
        private float value;
        private bool canMove = false;

        private float length = 300;
        private Texture2D sliderKnob;
        private Rectangle sliderKnobCollision;

        private Vector2 position;

        public NineSlicedSprite Sprite;

        public UISlider(int baseValue, int maxValue, Vector2 position)
        {
            this.baseValue = baseValue;
            this.maxValue = maxValue;
            this.value = maxValue / 2;
            this.position = position;
        }

        public override void LoadContent()
        {
            ResourceManager.Instance.Sprites.TryGetValue("SliderKnob", out sliderKnob);
            Sprite = new NineSlicedSprite("LightButton", new Rectangle((int)position.X, (int)position.Y, (int)length, 10));
            Sprite.LoadContent();
            sliderKnobCollision = new Rectangle(Sprite.size.X + Sprite.size.Width / 2 - sliderKnob.Width / 2, Sprite.size.Y - Sprite.size.Height / 2, sliderKnob.Width, sliderKnob.Height);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateKnobPosition();

            float offset = sliderKnobCollision.X - position.X;
            float pixel = maxValue / length;
            float val = pixel * sliderKnobCollision.Center.X;
            value = (float)Math.Round((decimal)val, 0, MidpointRounding.AwayFromZero);
            Debug.WriteLine(value);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
            GraphicsManager.Instance.DrawUISprite(sliderKnob, sliderKnobCollision, Color.White);
        }

        private void UpdateKnobPosition()
        {
            if (InputManager.Instance.mouseIsPressed(MouseButton.Left) && Sprite.size.Contains(InputManager.Instance.getMousePos()))
            {
                canMove = true;
            }
            if (InputManager.Instance.mouseIsReleased(MouseButton.Left))
            {
                canMove = false;
            }

            if (canMove)
            {
                int newX = (int)InputManager.Instance.getMousePos().X;
                if (newX < position.X + Sprite.size.Width - sliderKnob.Width / 2 && newX > position.X + sliderKnob.Width / 2)
                {
                    sliderKnobCollision.X = newX - sliderKnob.Width / 2;
                }
                else if (newX > position.X + Sprite.size.Width - sliderKnob.Width)
                {
                    sliderKnobCollision.X = (int)position.X + Sprite.size.Width - sliderKnob.Width;
                }
                else if (newX > position.X + sliderKnob.Width)
                {
                    sliderKnobCollision.X = (int)position.X + sliderKnob.Width;
                }
            }
        }

    }
}
