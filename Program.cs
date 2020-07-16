using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BattleTracker
{
    class Program
    {
        static List<string> players = new List<string>();
        static List<string> winners = new List<string>();
        public void register_player()
        {
            Console.Clear();
            Console.WriteLine("Testing application layer");
            Console.WriteLine("How many players to register?");
            try
            {
                int numberPlayer = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= numberPlayer; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Player {0} name", i);
                    string playerName = Console.ReadLine();
                    players.Add(playerName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Option please press any key to try again:");
                Console.ReadKey();
                console_menu();
            }

            Console.WriteLine("Successfully registered:\n");
            foreach( string name in players)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n\nPress any key to return to menu:");
            Console.ReadKey();
            console_menu();
        }

        public void show_registered_players()
        {
            /*  NEEDS: to display how many players to target based on players.Count%2==0  || HERE and on console_menu() */


            // This method displays the number of playes registered currently
            Console.Clear();
            if (players.Count == 0)
            {
                Console.WriteLine("\nNo players have been registered, please select option 1 from menu to register players");
                Console.WriteLine("\n\nPress any key to return to menu:");
                Console.ReadKey();
                console_menu();
            }
            else
            {
                Console.WriteLine("\nNumber of players registered is: {0} ", players.Count);
                Console.WriteLine("\n\nPress any key to return to menu:");
                Console.ReadKey();
                console_menu();
            } 

        }

        public void begin_matching_players()
        {
            //  Checking if enough players are registred to begin the matching process
            if(players.Count%2 ==0 & players.Count >2)
            {
                Console.WriteLine("Matching can begin");
                sorting_algorithm();    //  At random matching algorithm for 1st round || Need to track winners and cycle untill 1 winer is declared
                console_menu();                                     /* Looping back just to continue testing || REMOVE FOR FINAL DEPLOY */
            }
            else if(players.Count == 2)
            {
                Console.WriteLine("Player {0} will face against Player {1}", players.ElementAt(0), players.ElementAt(1));
            }
            else
            {
                Console.WriteLine("Not enough players registred to begin matchups");
            }
            Console.ReadKey();
            console_menu();
        }

        public void sorting_algorithm()
        {
            Random random = new Random();
            int maxNumber = players.Count;

            List<int> available = new List<int>(maxNumber);
            List<string> backplayers = players.ToList();

            for (int i = 0; i < maxNumber; i++) available.Add(i);
            while (available.Count > 0 & backplayers.Count > 0)
            {
                int index = random.Next(available.Count);
                Console.Write("\nPlayer {0} will face against ", backplayers.ElementAt(index));
                available.RemoveAt(index);
                backplayers.RemoveAt(index);

                Console.ReadKey();

                index = random.Next(available.Count);
                Console.Write("Player {0}\n", backplayers.ElementAt(index));
                available.RemoveAt(index);
                backplayers.RemoveAt(index);

                Console.ReadKey();
            }

            Console.WriteLine("\n\n\t\tEnd of available numbers");
            Console.ReadKey();
        }

        public void console_menu()
        {
            Console.Clear();
            /*  NEEDS: to display how many players to target based on players.Count%2==0  || HERE and on show_registered_players()  */

            Program pr = new Program();

            if (players.Count % 2 == 0 & players.Count > 0)
                Console.WriteLine("\t\tENOUGH PLAYERS TO BEGIN MATCHUPS: Please select option 3 to begin\n");
            
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1) Register Players\t\t\t2) Show number of registered players\n3) Start Matches\t\t\t4) Close");

            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    pr.register_player();
                    break;
                case 2:
                    pr.show_registered_players();
                    break;
                case 3:
                    pr.begin_matching_players();
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option: Press Any key to return to menu");
                    pr.console_menu();
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program pr = new Program();

            //pr.tester();
            pr.console_menu();

            Console.ReadKey();
        }

        public void tester()
        {
            Random random = new Random();

            players.Add("Jennifer");
            players.Add("Fernando");
            players.Add("Gabriel");
            players.Add("Julio");
            players.Add("Francisco");
            players.Add("Oscar");
            players.Add("Daniel");
            players.Add("Adrian");

            sorting_algorithm();

        }
    }
}
