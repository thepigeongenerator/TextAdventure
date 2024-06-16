using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class UseCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public UseCommand(World _world, Player _player) : base("use", "axe")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// uses the axe
        /// </summary>
        public override void Run()
        {
            Tile playerTile = world.GetPlayerTile(); //gets the player's current tile
            if (playerTile.Type == TileType.tree && player.HasAxe) //if the player has an axe and is at a tree
            {
                playerTile.CastTile(TileType.grass); //turns the tree to grass
                player.Wood += 1; //adds 1 to how much wood the player has

                Console.WriteLine($"you chopped down the tree, you now have {player.Wood} wood.");
            }
            else
            {
                Console.WriteLine("You don't know where to use the axe.");
            }
        }
    }
}
