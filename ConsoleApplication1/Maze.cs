using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Maze
    {
        public class Coordinates
        {
            public int x;
            public int y;

            public Coordinates(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public const int BLOCKED = -1;
        public const int NOMINAL = 1;
        public const int FREE = 0;

        int[,] grid;
        Coordinates startPosition;
        Coordinates endPosition;


        public Maze(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new Exception("No negative matrix size allowed");

            grid = new int[width, height];
            startPosition = new Coordinates(0, 0);
            endPosition = new Coordinates(width, height);
        }

        public Maze()
        {

        }

        public int valueAt(int x, int y)
        {
            int value;

            value = grid[x, y];

            return value;
        }
        public int valueAt(Coordinates position)
        {
            return valueAt(position.x, position.y);
        }

        public bool isTraversible(int x, int y)
        {
            return grid[x, y] >= 0;
        }

        public bool isTraversible(Coordinates position)
        {
            return isTraversible(position.x, position.y);
        }

        public int getHeight()
        {
            return grid.GetLength(1);
        }

        public int getWidth()
        {
            return grid.GetLength(0);
        }
    }
}
