using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    static class Constants
    {
        public const uint ROW = 1;
        public const uint COLUMN = 2;

    }

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
            mapFormat[Constants.ROW] = nbRowMap;
            mapFormat[Constants.COLUMN] = nbColMap;
            beginCoord[Constants.ROW] = beginCoordMap[Constants.ROW];
            beginCoord[Constants.COLUMN] = beginCoordMap[Constants.COLUMN];
            endCoord[Constants.ROW] = endCoordMap[Constants.ROW];
            endCoord[Constants.COLUMN] = endCoordMap[Constants.COLUMN];


            uint[] dataCoord = { endCoord[Constants.ROW], endCoord[Constants.COLUMN], 0 };
            mainQueue.Enqueue(dataCoord);
        }

        public Queue pathFind()
        {
            //initMapping( nbRowMap, nbColMap, beginCoordMap, endCoordMap);
            return mainQueue;
        }

    }
}
