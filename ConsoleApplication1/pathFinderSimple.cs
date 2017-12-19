using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{

    class pathFinderSimple : pathFinder
    {
        public const int NUMBER_OF_POTENTIAL_DIRECTION = 8;

        //Initialize queues used for iteration in pathfinding the shortest path
        public Queue mainQueue = new Queue();
        public Queue tempQueue = new Queue();
        Coordinates currentCoord;

        public override Path solve(Maze maze)
        {
            //Start the mapping of the whole maze
            int[] dataCoord = { maze.endPosition.x, maze.endPosition.y, 0 };
            mainQueue.Enqueue(dataCoord);
            char[,] map = new char[maze.getHeight(), maze.getWidth()];
            currentCoord = new Coordinates(maze.endPosition.x, maze.endPosition.y);

            //    //Continue mapping of the whole maze
            //    for (int i = 0; i < NUMBER_OF_POTENTIAL_DIRECTION; i++){
            //        if(currentCoord.x == 0)

            //    }
            //    //maze[][]


            //Build and return shortest path
            Path path = new Path(maze.startPosition);
            //Build...
            return path;
            //}

            //public bool checkUpperLeft(Maze maze)
            //{
            //    if (maze.valueAt(currentCoord.x+1))
            //    {

            //    }
            //    else
            //    {

            //    }
            //}
            //public bool checkUpper(Maze maze)
            //{

            //}
            //public bool checkUpperRight(Maze maze)
            //{

            //}
            //public bool checkLeft(Maze maze)
            //{

            //}
            //public bool checkRight(Maze maze)
            //{

            //}
            //public bool checkUnderLeft(Maze maze)
            //{

            //}
            //public bool checkUnder(Maze maze)
            //{

            //}
            //public bool checkUnderRight(Maze maze)
            //{

            //}
        }
    }
}
