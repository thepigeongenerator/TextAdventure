using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class HelpCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public HelpCommand(World _world, Player _player) : base("help")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// provides the player with help in the current context
        /// </summary>
        public override void Run()
        {
            Tile playerTile = world.GetPlayerTile(); //gets the player's current tile

            if (playerTile.Type == TileType.axe || playerTile.Type == TileType.food) //if the player is on an axe or food
            {
                Console.WriteLine("use \"take\" to take the item.");
            }

            if (player.HasAxe == false) //if the player has an axe
            {
                Console.WriteLine("use \"look\" to see what is around you and use \"go [north|east|south|west]\" to move around. You need to find a way to get food.");
            }
            else if (playerTile.Type == TileType.tree) //checks if the player is currently on a tree tile
            {
                Console.WriteLine("use \"use axe\" to chop down the tree to get 1 wood.");
            }
            else if (player.Wood < 4 && player.HasBoat == false) //if the player has less than 4 wood and no boat
            {
                Console.WriteLine("find some trees to use the axe on.");
            }
            else if (player.Wood >= 4) //if the player has more or exactly 4 wood
            {
                Console.WriteLine("use \"make boat\" to make a boat to get over water.");
            }

            if (player.HasBoat && player.IsHungry && player.HasFood == false) //checks if the player is hungry, has a boat and has no food
            {
                Console.WriteLine("look if there is some food in the water.");
            }
            else if (player.HasFood || playerTile.Type == TileType.food) //checks if the player has food or if the player is at a food tile
            {
                Console.WriteLine("use \"eat\" to eat the food.");
            }
            else if (player.IsHungry == false) //if the player isn't hungry
            {
                Console.WriteLine("go back up the mountain to go back to civilization.");
            }
        }
    }
}
