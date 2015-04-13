
namespace PyramidPanic
{
    public class Scores
    {
        // Fields
        private static int lives = 3;
        private static bool gameOver = false;
        private static int minimalPointsForNextLevel = 300;
        private static int points = 0;
        private static bool openDoors = false;

        // Properties
        public static int Lives
        {
            get { return lives; }
            set 
            { 
                  lives = value;
                  if (lives == 0)
                  {
                      gameOver = true;
                  }
            }
        }

        public static int Points
        {
            get { return points; }
            set 
            { 
                  points = value;
                  if (points < 0)
                  {
                      gameOver = true;
                  }
                  if (points > minimalPointsForNextLevel)
                  {
                      openDoors = true;
                  }
            }
        }

        public static bool GameOver
        {
            get { return gameOver; }
        }

        public static int MinimalPointsForNextLevel
        {
            set { minimalPointsForNextLevel = value; }
            get { return minimalPointsForNextLevel; }
        }

        public static bool OpenDoors
        {
            get { return openDoors; }
            set { openDoors = value; }
        }
    }
}
