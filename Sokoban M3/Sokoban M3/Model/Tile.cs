namespace Sokoban_M3.Model
{
    abstract class Tile
    {
        protected char _symbol;
        abstract public char Symbol { get; set; }

        public Tile Above { get; set;}
        public Tile Below { get; set;}
        public Tile Left { get; set;}
        public Tile Right { get; set;}

        public Entity Entity { get; set; }
        public abstract bool PutEntityOnThisField(Maze maze, Tile previous, Tile next);
    }
}
