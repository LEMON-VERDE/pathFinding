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
        //Initialize queues use for iteration in pathfinding the shortest path
        public Queue mainQueue = new Queue();
        public Queue tempQueue = new Queue();
        public int[] endCoord = { 0, 0 };
        public int[] beginCoord = { 0, 0 };
        public int[] mapFormat = { 0, 0 };

        public void initMapping(int nbRowMap, int nbColMap, int[] beginCoordMap, int[] endCoordMap)
        {
            mapFormat[1] = nbRowMap;
            mapFormat[2] = nbColMap;
            beginCoord[1] = beginCoordMap[1];
            beginCoord[2] = beginCoordMap[2];
            endCoord[1] = endCoordMap[1];
            endCoord[2] = endCoordMap[2];


            int[] dataCoord = { endCoord[1], endCoord[1], 0 };
            mainQueue.Enqueue(dataCoord);
        }

        public Queue pathFind()
        {

            return mainQueue;
        }

    }
}
