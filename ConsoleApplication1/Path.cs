using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Path : LinkedList<Coordinates>
    {
        public Coordinates startingPoint;

        public Path(Coordinates startingCoord) : base()
        {
            startingPoint = new Coordinates(startingCoord); // Copying the Coordinates

            this.Clear();
            this.AddFirst(startingCoord);
        }

        public bool isContinuous()
        {
            Enumerator iterator = GetEnumerator();

            Coordinates lastElement = startingPoint;

            while (iterator.MoveNext())
            {
                if (!lastElement.touches(iterator.Current))
                    return false;
            }

            return true;
        }
    }
}
