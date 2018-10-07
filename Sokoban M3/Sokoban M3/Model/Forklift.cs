namespace Sokoban_M3.Model
{
    class Forklift : Entity
    {
        public Forklift()
        {
            Symbol = '@';
            SymbolOnDestination = '@';
            Movable = false;
            Awake = true;
        }

        public override void ArrivedOnDestination(Maze maze, int value) { return; }

        public override void Move(Maze maze){ return; }

        public override void StepOnPitFall(Tile current) { return; }
    }
}
