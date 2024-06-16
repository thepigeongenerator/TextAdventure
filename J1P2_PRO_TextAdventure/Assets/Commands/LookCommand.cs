using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class LookCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public LookCommand(World _world, Player _player) : base("look")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// writes what the surrounding tiles have
        /// </summary>
        public override void Run()
        {
            //gets the players current position
            int x = player.GetPosition().x;
            int y = player.GetPosition().y;

            //looks at the surrounding tiles
            LookAt(x, y + 1, "north");
            LookAt(x + 1, y, "east");
            LookAt(x, y - 1, "south");
            LookAt(x - 1, y, "west");
        }

        /// <summary>
        /// writes the message for the tile at <paramref name="_x"/> <paramref name="_y"/>
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_direction">the cardinal direction the tile is in compared to the player</param>
        private void LookAt(int _x, int _y, string _direction)
        {
            Tile tile = world.GetTile(_x, _y); //gets the tile at the position
            Console.WriteLine(GetMessage(tile, _direction)); //writes the message
        }

        /// <summary>
        /// gets the message for what you see when looking at a tile
        /// </summary>
        /// <param name="_tile">the tile that you are looking at</param>
        /// <param name="_direction">the cardinal direction what this tile is in</param>
        /// <returns>the message</returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetMessage(Tile _tile, string _direction)
        {
            return $"{_direction} you see " + _tile.Type switch
            {
                TileType.shrubbery => "a shrubbery.",
                TileType.grass => "a patch of grass.",
                TileType.water => "a lake.",
                TileType.tree => "a tree.",
                TileType.axe => "a patch of grass with something hidden inside.",
                TileType.food => "a patch of grass with something hidden inside.",
                TileType.mountain => "the mountain.",
                TileType.start => "where you landed.",
                _ => throw new NotImplementedException($"unknown tile type {nameof(_tile.Type)}")
            };
        }
    }
}
