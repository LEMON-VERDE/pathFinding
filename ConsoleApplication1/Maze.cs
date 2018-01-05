using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Maze
    {
        public const int DEFAULT_MAZE_SIZE = 30;
        public const int BLOCKED = -1;
        public const int NOMINAL = 1;
        public const int FREE = 0;
        public const char PATH_SYMBOL = 'X';
        public const char START_SYMBOL = 'S';
        public const char OBJECTIVE_SYMBOL = 'O';
        public const char BLOCKED_SYMBOL = '#';
        public const char TRAVERSIBLE_SYMBOL = ' ';

        int[,] grid;
        public Coordinates startPosition;
        public Coordinates endPosition;


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
                        textGrid[colOffset + x] = TRAVERSIBLE_SYMBOL;
                    else
                        textGrid[colOffset + x] = BLOCKED_SYMBOL;
                }

                textGrid[colOffset + (x++)] = '\r';
                textGrid[colOffset + x] = '\n';
            }

            int startX = startPosition.x + 1;
            int startY = startPosition.y + 1;
            textGrid[startY * xSize + startX] = START_SYMBOL;
            int endX = endPosition.x + 1;
            int endY = endPosition.y + 1;
            textGrid[endY * xSize + endX] = OBJECTIVE_SYMBOL;

            return new string(textGrid);
        }

        public static Maze loadMazeFile(string path)
        {
            var reader = new StreamReader(path);

            LinkedList<string[]> lineList = new LinkedList<string[]>();

            int maxLineLength = 0;

            while(!reader.EndOfStream)
            {
                string[] lineString = reader.ReadLine().Split(',');

                if (lineString.Length > maxLineLength)
                    maxLineLength = lineString.Length;

                lineList.AddLast(lineString);
            }

            Maze loadedMaze = new Maze(maxLineLength, lineList.Count);

            for(int j = 0; j < lineList.Count; ++j)
            {
                string[] currentLine = lineList.ElementAt(j);

                for (int i = 0; i < currentLine.Length; ++i)
                {
                    if (currentLine[i].Contains("_"))
                        loadedMaze.grid[i,j] = 1;
                    else if (currentLine[i].ToLower().Contains("x"))
                        loadedMaze.grid[i,j] = -1;
                    else
                        loadedMaze.grid[i, j] = 0;

                    if (currentLine[i].ToLower().Contains("s"))
                        loadedMaze.startPosition = new Coordinates(i, j);
                    if (currentLine[i].ToLower().Contains("o"))
                        loadedMaze.endPosition = new Coordinates(i, j);
                }
            }

            return loadedMaze;
        }

        public string solutionDisplay(Path solution)
        {
            char[] mazeString = this.ToString().ToCharArray();

            foreach (Coordinates node in solution)
            {
                if (node.Equals(this.endPosition) || node.Equals(this.startPosition))
                    continue;

                mazeString[(node.y * (grid.GetLength(0) + 4)) + 1 + node.x] = PATH_SYMBOL;
            }

            return new string(mazeString);
        }
    }
}
