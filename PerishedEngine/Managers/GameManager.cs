using Microsoft.Xna.Framework;

namespace PerishedEngine.Managers
{
    public class GameManager
    {

        public static GameManager Instance { get; } = new GameManager();

        private GameManager() { }

        public bool Paused = false;
        public Game game { get; set; }

        public int getWindowWidth()
        {
            return game.Window.ClientBounds.Width;
        }

    }
}
