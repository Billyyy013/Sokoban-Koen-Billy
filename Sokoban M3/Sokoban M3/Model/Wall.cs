namespace Sokoban_M3.Model
{
    class Wall : Tile
    {
        public override char Symbol { get; set; }
        public Wall()
        {
            Symbol = '█';
        }

        //You can't put an Entity on a Wall as such this methode will return false when used
        public override bool PutEntityOnThisField(Maze maze, Tile previous, Tile next)
        {
            return false;
        }
    }
}
