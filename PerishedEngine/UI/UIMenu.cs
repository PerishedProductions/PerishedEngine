using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PerishedEngine.Managers;
using System.Collections.Generic;

namespace PerishedEngine.UI
{
    public class UIMenu
    {

        public List<UIButton> menuButtons = new List<UIButton>();
        public int menuIndex = 0;

        public virtual void Initialize()
        {
            for (int i = 0; i < menuButtons.Count; i++)
            {
                menuButtons[i].Initialize();
            }
        }

        public virtual void LoadContent()
        {
            for (int i = 0; i < menuButtons.Count; i++)
            {
                menuButtons[i].LoadContent();
            }
        }

        public virtual void Update(GameTime gameTime)
        {

            if (menuButtons.Count != 0)
            {
                if (InputManager.Instance.isPressed(Keys.Up) || InputManager.Instance.controllerIsPressed(Buttons.DPadUp))
                {
                    if (menuIndex == 0)
                        menuIndex = menuButtons.Count - 1;
                    else
                        menuIndex--;
                }

                if (InputManager.Instance.isPressed(Keys.Down) || InputManager.Instance.controllerIsPressed(Buttons.DPadDown))
                {
                    if (menuIndex == menuButtons.Count - 1)
                        menuIndex = 0;
                    else
                        menuIndex++;
                }

                if (InputManager.Instance.isPressed(Keys.Enter) || InputManager.Instance.controllerIsPressed(Buttons.A))
                {
                    menuButtons[menuIndex].OnButtonClicked();
                }

                menuButtons[menuIndex].Selected = true;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
