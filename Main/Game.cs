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


        private static void StartScreen()
        {
            
        }


        private static void InitGame()
        {
            Console.WriteLine("Number of players: ");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Enter player name:");
                Players.Add(new Player(Console.ReadLine()));
            }
        }

        private static void Tick()
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (var player in Players)
                {
                    player.PointsModifier = player.DoublePoints ? 4 : 2;
                        
                    Console.WriteLine(player.Name + "'s turn.");
                    Console.WriteLine(player.Name + "meets" + player.Bosses[i].Name);
                    Reader.PrintMission(player.Bosses[i].Mission);

                    if (player.MissionSuccess(player.Bosses[i].Mission))
                    {
                        if ((Players.Count == 1) && (i == 4))
                        {
                            Console.WriteLine("You win!");
                            break;
                        }
                        player.DoublePoints = false;
                        player.Points += 5 * player.PointsModifier;
                        if (i < 4)
                        {
                            player.Awards.Add(player.Bosses[i].Award);
                        }
                    }
                    else
                    {

                        Console.WriteLine(player.Bosses[i].Name + " says: again for half points or next for double?");
                        if (Console.ReadLine() == "again")
                        {
                            player.PointsModifier = 1;
                            player.DoublePoints = false;
                            if (player.MissionSuccess(player.Bosses[i].Mission))
                            {
                                player.Points += 5 * player.PointsModifier;
                                if (i < 4)
                                {
                                    player.Awards.Add(player.Bosses[i].Award);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            player.DoublePoints = true;
                            break;
                        }
                    }
                }
            }


        }

        private static void CheckWin(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                
            }
        }
        
    }
}
