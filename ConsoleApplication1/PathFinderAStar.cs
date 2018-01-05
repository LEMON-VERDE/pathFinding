using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PathFinderAStar : pathFinder
    {
        class ScoredCoordinates : Coordinates
        {
            public double f, g, h;

            public ScoredCoordinates cameFrom;

            public ScoredCoordinates(int x, int y): base(x,y)
            {
                this.f = 0;
                this.g = double.PositiveInfinity;
                this.cameFrom = null;
            }

            public ScoredCoordinates(Coordinates position): this(position.x, position.y)
            { 
            }

            public double heuristic_cost(Coordinates destination)
            {
                return Math.Sqrt(Math.Pow(destination.x - this.x, 2) + Math.Pow(destination.y - this.y, 2));
            }
        }

        public override Path solve(Maze maze)
        {
            LinkedList<ScoredCoordinates> closedSet = new LinkedList<ScoredCoordinates>();
            LinkedList<ScoredCoordinates> openSet = new LinkedList<ScoredCoordinates>();

            ScoredCoordinates start = new ScoredCoordinates(maze.startPosition);
            start.f = start.heuristic_cost(maze.endPosition);

            openSet.AddFirst(start);

            while (openSet.Count >= 1)
            {
                ScoredCoordinates current = openSet.First();
                foreach (ScoredCoordinates node in openSet)
                    if (node.f < current.f)
                        current = node;

                if (current.Equals(maze.endPosition))
                {
                    // Return Reconstructed path
                    Path reconstructedPath = new Path(maze.startPosition);

                    while(current != null)
                    {
                        reconstructedPath.AddAfter(reconstructedPath.First, current);
                        current = current.cameFrom;
                    }

                    return reconstructedPath;
                }

                openSet.Remove(current);
                closedSet.AddLast(current);

                foreach (ScoredCoordinates neighbor in getNeighbors(current, maze))
                {
                    if (closedSet.Contains(neighbor))
                        continue;

                    // Selecting the node in the openSet if it was already added
                    bool isNew = true;
                    ScoredCoordinates exploredNeighbor = neighbor;

                    foreach (ScoredCoordinates openSetMember in openSet)
                    {
                        if (neighbor.Equals(openSetMember))
                        {
                            exploredNeighbor = openSetMember;
                            isNew = false;
                            break;
                        }
                    }

                    if (isNew)
                        openSet.AddLast(neighbor);

                    double tentative_g = current.g + maze.valueAt(exploredNeighbor);
                    if (tentative_g >= exploredNeighbor.g)
                        continue;

                    exploredNeighbor.cameFrom = current;
                    exploredNeighbor.g = tentative_g;
                    exploredNeighbor.f = exploredNeighbor.g + exploredNeighbor.heuristic_cost(maze.endPosition);
                }

            }

            return null;
        }

        private LinkedList<ScoredCoordinates> getNeighbors(Coordinates current, Maze maze)
        {
            LinkedList<ScoredCoordinates> neighborList = new LinkedList<ScoredCoordinates>();

            ScoredCoordinates[] potNebr = new ScoredCoordinates[8];

            potNebr[0] = new ScoredCoordinates(current.x + 1, current.y);
            potNebr[1] = new ScoredCoordinates(current.x + 1, current.y + 1);
            potNebr[2] = new ScoredCoordinates(current.x, current.y + 1);
            potNebr[3] = new ScoredCoordinates(current.x - 1 , current.y + 1);
            potNebr[4] = new ScoredCoordinates(current.x - 1, current.y);
            potNebr[5] = new ScoredCoordinates(current.x - 1, current.y - 1);
            potNebr[6] = new ScoredCoordinates(current.x, current.y -1);
            potNebr[7] = new ScoredCoordinates(current.x + 1, current.y -1);

            foreach (ScoredCoordinates spot in potNebr)
                if (maze.isTraversible(spot))
                    neighborList.AddLast(spot);

            return neighborList;
        }
    }
}
