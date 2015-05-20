using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Main
{
    static class Canrum
    {
        static void Main(string[] args)
        {

            Console.Write("Number of players: ");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());
            Player[] players = new Player[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = new Player();
            }

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("It seems {0}.", e.Message);
                throw;
            }
            players[0].StartCodeCompiler();
            
        }

        
    }
}
