using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Coordinates
    {
        public int x;
        public int y;

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
    }
}
