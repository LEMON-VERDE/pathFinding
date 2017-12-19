using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Coordinates
    {
        public readonly int x;
        public readonly int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Copy Constructor
        public Coordinates(Coordinates model)
            :this(model.x, model.y)
        {
        }

        public bool equals(int x, int y)
        {
            return this.x == x && this.y == y;
        }

        public bool equals(Coordinates position)
        {
            return equals(position.x, position.y);
        }

        public bool touches(Coordinates other)
        {
            int xDist = this.x - other.x;
            int yDist = this.y - other.y;

            return xDist >= -1 && xDist <= 1 && yDist >= -1 && yDist <= 1;
        }
    }
}
