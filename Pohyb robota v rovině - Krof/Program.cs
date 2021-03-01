using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pohyb_robota_v_rovině___Krof
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Pohyb();
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        Console.Write(maze[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        //P = průchod; N = zeď; Z = začátek; K = konec; R = robot
        static char[,] maze = new char[7, 9]
        {
            { 'Z', 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
            { 'P', 'N', 'N', 'N', 'N', 'N', 'P', 'P', 'P'},
            { 'N', 'P', 'P', 'P', 'P', 'P', 'P', 'N', 'N'},
            { 'P', 'P', 'P', 'P', 'N', 'P', 'P', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'P', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'P', 'P', 'P', 'P'},
            { 'P', 'P', 'K', 'P', 'P', 'P', 'P', 'P', 'P'},
        };

        //souřadnice začátku
        static int zradek = 0;
        static int zsloupec = 0;

        //souřadnice robota
        static int rradek = 0;
        static int rsloupec = 0;

        //souřadnice posledního místa
        static int poslradek;
        static int poslsloupec;

        //mezisouřadnice
        static int meziradek;
        static int mezisloupec;

        static void Pohyb()
        {
            maze[rradek, rsloupec] = 'P';

            if (rsloupec + 1 != poslsloupec && rsloupec + 1 < maze.GetLength(1) && (maze[rradek, rsloupec + 1] == 'P' || maze[rradek, rsloupec + 1] == 'K'))
            {
                poslsloupec = rsloupec;
                poslradek = rradek;
                rsloupec++;
            }

            else if (rradek + 1 != poslradek && rradek + 1 < maze.GetLength(0) && (maze[rradek + 1, rsloupec] == 'P' || maze[rradek + 1, rsloupec] == 'K'))
            {
                poslradek = rradek;
                poslsloupec = rsloupec;
                rradek++;
            }

            else if (rsloupec - 1 != poslsloupec && rsloupec - 1 < maze.GetLength(1) && (maze[rradek, rsloupec - 1] == 'P' || maze[rradek, rsloupec - 1] == 'K'))
            {
                poslsloupec = rsloupec;
                poslradek = rradek;
                rsloupec--;
            }

            else if (rradek - 1 != poslradek && rradek - 1 < maze.GetLength(0) && (maze[rradek - 1, rsloupec] == 'P' || maze[rradek - 1, rsloupec] == 'K'))
            {
                poslradek = rradek;
                poslsloupec = rsloupec;
                rradek--;
            }

            else
            {
                meziradek = rradek;
                mezisloupec = rsloupec;

                rradek = poslradek;
                rsloupec = poslsloupec;

                poslradek = meziradek;
                poslsloupec = mezisloupec;
            }

            if (maze[rradek, rsloupec] == 'K')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Robot je v cíli.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            maze[zradek, zsloupec] = 'Z';
            maze[rradek, rsloupec] = 'R';
        }
    }
}
