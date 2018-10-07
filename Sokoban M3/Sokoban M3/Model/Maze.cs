namespace Sokoban_M3.Model
{
    class Maze
    {
        public int AmountOfChests { get; set; }
        public int AmountOfChestsOnDestination { get; set; }

        public Tile CurrentForkLift { get; set; }
        public Tile First { get; set; }
        public Tile CurrentWorker { get; set; }

        public Maze()
        {
        }

       
    }
}
