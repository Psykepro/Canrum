using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Main
{
    static class Game
    {
        private static List<Player> Players = new List<Player>();

        public static void StartGame()
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
            Console.Write("Number of players: ");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Enter player name: ");
                Players.Add(new Player(Console.ReadLine()));
            }
        }

        private static void Tick()
        {
            if (Players.Count > 1)
            {
                goto MultiplayerMode;
            }

        SingleplayerMode:

            var player = Players[0];

            for (int level = 1; level <= 5; level++)
            {
                Boss boss = player.GetCurrentBoss();
                if (boss.Name != "Nakov")
                {
                    Console.WriteLine("{0} suddenly steps in front of you, blocking your way.", boss.Name);
                    Console.WriteLine(
                        "{0}: The way is shut, stranger! If you want passage you must complete the following task.",
                        boss.Name);
                    Console.WriteLine("{0}: If you succeed, I'll grant you passage and the knowledge of {1}.\n", boss.Name,
                        boss.Award);

                    bool? completedSuccessfully = player.CompleteMission();
                    if (completedSuccessfully == null)
                    {
                        //Compilation failed
                        throw new NotImplementedException();
                    }
                    else if (completedSuccessfully == true)
                    {
                        Console.WriteLine("{0}: Well done, lad! Here's your promised award! Go on!", boss.Name);
                        Console.WriteLine("You now possess the knowledge of {0}", boss.Award);
                        player.Awards.Add(boss.Award);
                    }
                    else
                    {
                        Console.WriteLine(
                            "{0}: Your answer is incorrect! I'll let you go further, but do you consider yourself worthy?",
                            boss.Name);
                    }
                }
                else
                {
                    Console.WriteLine(
                        "As you step carefully along the road, a dreadful, hideous creature arises from the shadows.");
                    Console.WriteLine("The air grows ripe with the stench of death and misery.");
                    Console.WriteLine("Your heart starts beating wildly, pumping blood into your head.");
                    Console.WriteLine("You know it's him. There's no turning back now.");
                    Console.WriteLine("{0}: So... You think you've got what it takes. Let's find out.", boss.Name);

                    bool? completedSuccessfully = player.CompleteMission();
                    if (completedSuccessfully == null)
                    {
                        //Compilation failed
                        throw new NotImplementedException();
                    }
                    else if (completedSuccessfully == true)
                    {
                        Console.WriteLine("{0}: Congratulations! You win!", boss.Name);
                    }
                    else
                    {
                        Console.WriteLine(
                            "{0}: Go away, maggot! Come back when you consider yourself worthy of speaking with me!",
                            boss.Name);
                    }
                }
            }
            goto Finish;

        MultiplayerMode:

            for (int i = 0; i < 5; i++)
            {
                foreach (var pl in Players)
                {
                    pl.PointsModifier = pl.DoublePoints ? 4 : 2;

                    Boss boss = pl.GetCurrentBoss();

                    Console.WriteLine(pl.Name + "'s turn.");
                    Console.WriteLine(pl.Name + " meets " + boss.Name);

                    bool? completedSuccessfully = pl.CompleteMission();
                    if (completedSuccessfully == null)
                    {
                        //Compilation failed
                        throw new NotImplementedException();
                    }
                    else if (completedSuccessfully == true)
                    {
                        pl.DoublePoints = false;
                        pl.Points += 5 * pl.PointsModifier;
                        if (i < 4)
                        {
                            pl.Awards.Add(boss.Award);
                        }
                    }
                    else
                    {
                        if (i == 4)
                        {
                            Console.WriteLine(boss.Name + " says: You have one more chance to prove your worth!");
                        }
                        else
                        {
                            Console.WriteLine(boss.Name + " says: again for half points or next for double?");
                            if (Console.ReadLine() == "again")
                            {
                                pl.PointsModifier = 1;
                                pl.DoublePoints = false;
                            }
                            else
                            {
                                pl.DoublePoints = true;
                                break;
                            }
                        }

                        completedSuccessfully = pl.CompleteMission();
                        if (completedSuccessfully == null)
                        {
                            //Compilation failed
                            throw new NotImplementedException();
                        }
                        else if (completedSuccessfully == true)
                        {
                                pl.Points += 5 * pl.PointsModifier;
                                if (i < 4)
                                {
                                    pl.Awards.Add(boss.Award);
                                }
                            }
                            else
                            {
                                break;
                            }
                    }
                }
            }
            CheckWin(Players);

            Finish:;
        }

        private static void CheckWin(List<Player> players)
        {
            List<string> names = new List<string>();
            names.Add(players[0].Name);
            double score = players[0].Points;
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].Points > score)
                {
                    names.Clear();
                    names.Add(players[i].Name);
                    score = players[i].Points;
                }
                else if (players[i].Points == score)
                {
                    names.Add(players[i].Name);
                }
            }

            if (names.Count > 1)
            {
                Console.WriteLine("{1} are tied for 1st place with {0} points.", score, string.Join(" and ", names));
            }
            else
            {
                Console.WriteLine("{1} wins with {0} points.", score, names.First());
            }
        }
        
    }
}
