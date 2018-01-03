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

            Console.WriteLine(maze);
            Console.ReadKey();
        }
    }
}
