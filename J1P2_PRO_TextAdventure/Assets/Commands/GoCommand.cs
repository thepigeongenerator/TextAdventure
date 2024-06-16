using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class GoCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public GoCommand(World _world, Player _player) : base("go", "north", "east", "south", "west")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// moves the player based on cardinal directions. e.g. north, south, east, west
        /// </summary>
        /// <exception cref="Exception"></exception>
        public override void Run()
        {
            switch (Argument) //switch statement for argument
            {
                case "north":
                    MovePlayer(0, 1); //moves the player relative to the player's current position
                    break;

                case "east":
                    MovePlayer(1, 0);
                    break;

                case "south":
                    MovePlayer(0, -1);
                    break;

                case "west":
                    MovePlayer(-1, 0);
                    break;

                default:
                    throw new Exception($"unknown case: {Argument}");
            }
        }

        /// <summary>
        /// moves the player relative to the player
        /// </summary>
        /// <param name="_dx">the distance in the X direction the player should travel</param>
        /// <param name="_dy">the distance in the Y direction the player should travel</param>
        private void MovePlayer(int _dx, int _dy)
        {
            (int x, int y) = player.GetPosition(); //gets the player's current position
            player.Move(_dx, _dy, world); //moves the player
            Tile enteredTile;

            x += _dx;
            y += _dy;

            enteredTile = world.GetTile(x, y); //gets the entered tile
            Console.WriteLine(GetMessage(enteredTile));
        }

        /// <summary>
        /// gets the message that should be written depending on <see cref="Tile.Type"/> and <see cref="Tile.CanEnter(Player)"/>
        /// </summary>
        /// <param name="_tile"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetMessage(Tile _tile)
        {
            return _tile.Type switch
            {
                TileType.shrubbery => "You were unable to get through the shrubberies.",
                TileType.grass => "You see nothing of interest here.",
                TileType.axe => "You see a rusty axe hidden in the grass!",
                TileType.food => "You see a can of beans hidden in the grass!",
                TileType.start => "This is where you landed after your fall. Kind of.. eerie.",
                TileType.tree => "There is a small tree here.",
                TileType.water => ConditionalMessage(_tile, "You used the boat to get on the water.", "There is a lake here, you see something glistering in the distance. However, the water\n is too deep to swim safely when you are this exhausted."), //a curtain string is returned based on if the player can enter the tile
                TileType.mountain => ConditionalMessage(_tile, "You climbed up the mountain.", "This is the mountain you fell off, you are too hungry to climb. You see your RV up there, it's burnt to a crisp."),
                _ => throw new NotImplementedException($"unknown tile type {nameof(_tile.Type)}") //default case, if an unknown type
            };
        }

        /// <summary>
        /// returns a message based on if the player is allowed to enter this tile
        /// </summary>
        /// <param name="_tile">the tile to check if the player is allowed to enter</param>
        /// <param name="_successMsg">the message that is returned if the player is allowed to enter the tile</param>
        /// <param name="_failMsg">the message that is returned if the player is not allowed to enter the tile</param>
        /// <returns>if the player is allowed to enter the tile, <paramref name="_successMsg"/> is returned, otherwise <paramref name="_failMsg"/></returns>
        private string ConditionalMessage(Tile _tile, string _successMsg, string _failMsg)
        {
            if (_tile.CanEnter(player)) //checks if the player can enter the tile
            {
                return _successMsg; //returns the success message
            }

            return _failMsg; //returns the failed message
        }
    }
}
