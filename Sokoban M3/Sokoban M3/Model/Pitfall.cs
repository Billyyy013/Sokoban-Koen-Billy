namespace Sokoban_M3.Model
{
    class Pitfall : Tile
    {
        public override char Symbol
        {
            get
            {
                if (Entity != null)
                {
                    return Entity.Symbol;
                }
                else
                {
                    return _symbol;
                }
            }
            set { }
        }

        private int _counter { get; set; }

        public Pitfall()
        {
            _symbol = '~';
        }
        public override bool PutEntityOnThisField(Maze maze, Tile previous, Tile next)
        {
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                _counter++;
                if (_counter == 3) { _symbol = ' '; }
                if (_counter > 3) { Entity.StepOnPitFall(this); }
                return true;
            }
            else
            {
                if (next.Entity != null) { return false; }
                if (!this.Entity.Movable)
                {
                    this.Entity.Awake = true;
                    return false;
                }
                if (next.PutEntityOnThisField(maze, this, next))
                {
                    Entity = previous.Entity;
                    previous.Entity = null;
                    _counter++;
                    if (_counter == 3) { _symbol = ' '; }
                    return true;
                }
                return false;
            }
        }
    }
}
