namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class World
    {
        private readonly Tile[,] world; //2D array for the world
        private readonly Player player;

        public Player Player { get { return player; } }


        public World() //constructor for world
        {
            int[] playerPos;
            WorldBuilder worldBuilder = new();

            world = worldBuilder.GenTiles(); //generates the tiles and stores them in world
            playerPos = worldBuilder.StartPos; //gets the position of the start tile

            player = new Player(playerPos[0], playerPos[1]); //assigns a new Player object
        }

        /// <summary>
        /// gets what tile the player is currently at
        /// </summary>
        /// <returns>the players tile</returns>
        public Tile GetPlayerTile()
        {
            (int x, int y) = player.GetPosition();

            return GetTile(x, y);
        }

        /// <summary>
        /// gets a tile at a curtain position
        /// </summary>
        /// <param name="_x">the x position of the tile</param>
        /// <param name="_y">the y position of the tile</param>
        /// <returns>the tile at position <paramref name="_x"/>, <paramref name="_y"/></returns>
        public Tile GetTile(int _x, int _y) => world[_x, _y];

#warning if the test was succesful, change how this works
        /// <summary>
        /// gets the amount of tiles in the x and y axis
        /// </summary>
        /// <returns>the world's size</returns>
        public int GetSize() => world.GetLength(0); //gets the length of an axis in the array
    }
}
