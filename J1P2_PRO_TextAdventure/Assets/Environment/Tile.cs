namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Tile
    {
        private TileType type; //the tile's type

        public TileType Type { get => type; }


        public Tile(TileType _type)
        {
            type = _type; //sets the tile's type
        }

        /// <summary>
        /// checks if the player is allowed to enter the tile
        /// </summary>
        /// <param name="_player">the player to check</param>
        /// <returns><see langword="true"/> if the player is allowed to enter, otherwise <see langword="false"/></returns>
        public bool CanEnter(Player _player)
        {
            return type switch
            {
                TileType.water => _player.HasBoat,
                TileType.mountain => !_player.IsHungry,
                TileType.shrubbery => false,
                _ => true,
            };
        }

        /// <summary>
        /// casts this tile's type to another
        /// </summary>
        /// <param name="_castTo">the type to be casted to</param>
        public void CastTile(TileType _castTo)
        {
            type = _castTo; //changes the type
        }

        /// <summary>
        /// conditional <see cref="type"/> cast <br/>
        /// casts the tile only if <see cref="type"/> matches <paramref name="_allowedCast"/>
        /// </summary>
        /// <param name="_castTo">the type to be casted to</param>
        /// <param name="_allowedCast">the type that <see cref="type"/> needs to match to cast</param>
        public void CastTile(TileType _castTo, TileType _allowedCast) //overloading the method with different parameters
        {
            if (type == _allowedCast) //checks if the type matches the allowed cast type
            {
                type = _castTo; //changes the type
            }
        }
    }
}
