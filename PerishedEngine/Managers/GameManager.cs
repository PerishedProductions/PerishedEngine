using Microsoft.Xna.Framework;

namespace PerishedEngine.Managers
{
    public class GameManager
    {

        public static GameManager Instance { get; } = new GameManager();

        private GameManager() { }

        public bool Paused = false;
        public Game Game;



    }
}
