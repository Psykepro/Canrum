using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Main
{
    static class Canrum
    {
        static void Main(string[] args)
        {

            /*Console.Write("Number of players: ");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());
            Player[] players = new Player[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Name of player {0}:", i+1);
                string name = Console.ReadLine();
                players[i] = new Player(name);
            }

            players[0].StartCodeCompiler();*/
            /*string[] output;
            CodeManager.GetOutputFromCompiled(null, new[] {"Marto"}, out output);
            Console.WriteLine(output[0]);
            Console.ReadKey();*/

            Game.StartGame();
            //string[] output;
            //CodeManager.GetOutputFromCompiled(null, new[]{"hi"}, out output);

        }

        
    }
}
