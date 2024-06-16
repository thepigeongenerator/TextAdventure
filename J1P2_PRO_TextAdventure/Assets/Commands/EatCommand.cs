using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class EatCommand : Command //inherits from Command class
    {
        private readonly World world;
        private readonly Player player;


        public EatCommand(World _world, Player _player) : base("eat")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// checks if the player has or is standing on beans. Removes the beans and makes the player no longer hungry
        /// </summary>
        public override void Run()
        {
            string successMessage = "You ate the delicious beans, you feel recharged!"; //defines the success message
            Tile playerTile = world.GetPlayerTile(); //gets the player tile

            if (player.HasFood) //if player has food
            {
                player.HasFood = false;
                player.IsHungry = false;
                Console.WriteLine(successMessage);
            }
            else if (playerTile.Type == TileType.food) //if player is on food tile
            {
                playerTile.CastTile(TileType.grass);
                player.IsHungry = false;
                Console.WriteLine(successMessage);
            }
            else //otherwise
            {
                Console.WriteLine("You see nothing for you to eat.");
            }
        }
    }
}
