using J1P2_PRO_TextAdventure.GameScripts; //uses the scripts from that namespace

namespace J1P2_PRO_TextAdventure //sets the namespace (location)
{
    internal class Program //defines an internal class which can only be accessed in it's own assembly
    {
        public static void Main(string[] _args) //defines a method
        {
            Game game = new(); //initializes a new game object
            game.Start(); //starts the game
        }
    }
}
