using PerishedEngine.UI;

namespace PerishedEngine.Managers
{
    public class UIManager
    {

        public static UIManager Instance { get; } = new UIManager();

        private UIManager() { }

        public UIScreen currentScreen;

        /// <summary>
        /// Changes out the current canvas for a new one
        /// </summary>
        /// <param name="screen">The screen we want to change to</param>
        public void ChangeCanvas(UIScreen screen)
        {
            currentScreen = screen;
            if (screen != null)
            {
                currentScreen.Initialize();
                currentScreen.LoadContent();
            }
        }

    }
}
