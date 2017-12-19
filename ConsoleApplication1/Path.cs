using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Path
    {
        Coordinates startingPoint;
        LinkedList<Coordinates> pointList;

        public Path(Coordinates startingCoord)
        {
            pointList = new LinkedList<Coordinates>();
            startingPoint = new Coordinates(startingCoord); // Copying the Coordinates

            pointList.Clear();
        }
    }
}
