using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Coordinates : IEquatable<Coordinates>
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
            : this(model.x, model.y)
        {
        }

        public bool touches(Coordinates other)
        {
            int xDist = this.x - other.x;
            int yDist = this.y - other.y;

            return xDist >= -1 && xDist <= 1 && yDist >= -1 && yDist <= 1;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates other)
        {
            return other != null &&
                   x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
    }
}
