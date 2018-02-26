using System.Collections.Generic;

namespace Battleship.Models
{
    public abstract class Player
    {
        public List<Ship> PlayerShips = new List<Ship>();
        
        public Ship ShipBeingPlaced
        {
            get { return PlayerShips.Find(s => s.IsBeingPlaced); }
        }
    }
}
