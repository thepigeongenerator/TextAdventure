using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class TakeCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public TakeCommand(World _world, Player _player) : base("take")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// takes food or an axe
        /// </summary>
        public override void Run()
        {
            Tile currentTile = world.GetPlayerTile(); //gets the players current tile

            switch (currentTile.Type)
            {
                case TileType.axe: //if the tile is an axe
                    player.HasAxe = true;
                    currentTile.CastTile(TileType.grass); //converts the tile to grass
                    Console.WriteLine("You took the rusty axe.");
                    break;

                case TileType.food: //if the tile is food
                    player.HasFood = true;
                    currentTile.CastTile(TileType.grass);
                    Console.WriteLine("You took the can o' beans.");
                    break;

                default:
                    Console.WriteLine("You see nothing you can take.");
                    break;
            }
        }
    }
}
