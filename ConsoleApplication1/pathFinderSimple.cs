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
        public uint[] endCoord = { 0, 0 };
        public uint[] beginCoord = { 0, 0 };
        public uint[] mapFormat = { 0, 0 };

        public void initMapping(uint nbRowMap, uint nbColMap, uint[] beginCoordMap, uint[] endCoordMap)
        {
            mapFormat[1] = nbRowMap;
            mapFormat[2] = nbColMap;
            beginCoord[1] = beginCoordMap[1];
            beginCoord[2] = beginCoordMap[2];
            endCoord[1] = endCoordMap[1];
            endCoord[2] = endCoordMap[2];


            uint[] dataCoord = { endCoord[1], endCoord[1], 0 };
            mainQueue.Enqueue(dataCoord);
        }

        public Queue pathFind()
        {

            return mainQueue;
        }

    }
}
