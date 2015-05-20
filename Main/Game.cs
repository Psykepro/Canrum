using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    static class Game
    {
        private static List<Player> Players = new List<Player>();

        static Game()
        {
            StartScreen();
            InitGame();
            Tick();


        }


        public static void StartScreen()
        {
            
        }


        public static void InitGame()
        {
            Console.Write("Number of players: ");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Players.Add(new Player());
            }
        }

        public static void Tick()
        {
            bool win = false;

            while (win == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    foreach (var player in Players)
                    {
                        Console.WriteLine(player.Name + "'s turn.");
                        Console.WriteLine(player.Name + "meets" player.Boss[0].Name);
                        player.StartCodeCompiler();

                    }
                }
            }
        }


        
    }
}
