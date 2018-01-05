using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            Maze maze = Maze.loadMazeFile("../../res/easyMaze.csv");

            PathFinderAStar solver = new PathFinderAStar();

            Path solution = solver.solve(maze);

            Console.WriteLine(maze.solutionDisplay(solution));



            Console.ReadKey();
        }
    }
}
