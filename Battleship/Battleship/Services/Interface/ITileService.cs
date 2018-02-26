using Battleship.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services
{
    public interface ITileService
    {
        void PlaceShip(Board board, Ship ship);

        bool ShipWillIntersect(Board board, Ship ship);
    }
}
