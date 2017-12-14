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

            public bool equals(int x, int y)
            {
                return this.x == x && this.y == y;
            }

            public bool equals(Coordinates position)
            {
                return equals(position.x, position.y);
            }
        }

        public const int DEFAULT_MAZE_SIZE = 30;

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
            endPosition = new Coordinates(width - 1, height - 1);
        }

        public Maze(int width, int height, Coordinates start, Coordinates end)
        {
            if (width < 0 || height < 0)
                throw new Exception("No negative matrix size allowed");

            grid = new int[width, height];
            startPosition = start;
            endPosition = end;
        }

        public Maze(): this(DEFAULT_MAZE_SIZE, DEFAULT_MAZE_SIZE)
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
            if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight())
                return false;

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

        public override string ToString()
        {
            int xSize = grid.GetLength(0) + 4;
            int ySize = grid.GetLength(1) + 2;
            char[] textGrid = new char[xSize * ySize];

            int carrRetrunIndex = xSize - 2;

            for (int y = 0; y < ySize; ++y)
            {
                int colOffset = y * xSize;

                int x;

                for (x = 0; x < carrRetrunIndex; ++x)
                {
                    if (isTraversible(x - 1, y - 1))
                        textGrid[colOffset + x] = ' ';
                    else
                        textGrid[colOffset + x] = '#';
                }

                textGrid[colOffset + (x++)] = '\r';
                textGrid[colOffset + x] = '\n';
            }

            int startX = startPosition.x + 1;
            int startY = startPosition.y + 1;
            textGrid[startY * xSize + startX] = 'S';
            int endX = endPosition.x + 1;
            int endY = endPosition.y + 1;
            textGrid[endY * xSize + endX] = 'O';

            return new string(textGrid);
        }
    }
}
