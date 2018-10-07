namespace Sokoban_M3.Model
{
    class EmptyTile : Tile
    {
        public override char Symbol { get; set; }
        public EmptyTile()
        {
            Symbol = ' ';
        }

        //You can't put an Entity on an EmptyTile as such this methode will return false when used
        public override bool PutEntityOnThisField(Maze maze, Tile previous, Tile next)
        {
            return false;
        }
    }
}
