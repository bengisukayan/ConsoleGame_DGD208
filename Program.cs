using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;


namespace BigBadCat //My Wumpus World implementation
{
    internal class Program
    {
        public static int score = 6000; //our initial score

        public static char[,,] maps = { { //our predefined maps
                { 'V', 'E', '0', 'V' }, 
                { '0', '0', '0', '0' }, 
                { '0', 'C', '0', '0' }, 
                { 'P', '0', 'V', '0' }
                    },
                                         { 
                { 'V', '0', '0', 'V' }, 
                { '0', 'P', 'C', '0' }, 
                { '0', '0', '0', '0' }, 
                { '0', 'V', '0', 'E' }
                    },
                                         { 
                { 'V', '0', '0', 'E' }, 
                { '0', 'V', 'E', 'C' }, 
                { '0', '0', '0', '0' }, 
                { '0', 'V', '0', 'P' }
                    },
                                         { 
                { 'V', '0', 'V', '0' }, 
                { 'P', '0', '0', 'E' }, 
                { '0', '0', 'C', '0' }, 
                { '0', 'V', '0', '0' }
                    }
                };

        static void Main(string[] args)
        {
            Game game = new Game(); //game instance
            game.InitGame(); //initialize
            ScoreTimer(); //start the score keeping thread
            game.GameLoop(); //start the game loop
        }

        static async Task ScoreTimer() //async method for score keeping
        {
            await Task.Run(() => //Running the task with await
            {
                while (Game.gameOn)
                {
                    Task.Delay(1000).Wait(); //every second
                    score -= 100; //decrease score with time
                    if (score <= 0)
                        break; //break loop when time is over (1 min)
                }
            });
            Game.gameOn = false; //stop the game loop
            Console.Clear();
            Console.WriteLine("Time out!");
        }
        public class Game
        {
            public static bool gameOn = true;
            private string _buffer = "";
            private Map _map = new Map();

            public void InitGame()
            {
                Console.WriteLine("Welcome to BigBadCat game! You are searching this evil big cat's lair for legendary Golden Claw.\nTry not to wake the cat or step on asidic vomit!"); //printing instructions
                Console.WriteLine("Type 'w, a, s, d' to move and 'exit' to terminate. Use 'help' if you forget the commands.");
                Console.WriteLine("Please wait...");
                Thread.Sleep(6000); //wait for 6 seconds
                _map.renderMap(); //print map
            }
            public void GameLoop() //game loop
            {
                while (Game.gameOn)
                {
                    _buffer = Console.ReadLine(); //read console
                    switch (_buffer.ToLower())
                    {
                        case "w":
                            _map.move('w'); //walk up
                            break;
                        case "a":
                            _map.move('a'); //walk left
                            break;
                        case "s":
                            _map.move('s'); //walk down
                            break;
                        case "d":
                            _map.move('d'); //walk right
                            break;
                        case "exit":
                            Console.WriteLine("BuhBye!"); //terminate
                            Thread.Sleep(3000);
                            return;
                        case "help":
                            Console.WriteLine("Type 'w, a, s, d' to move and 'exit' to terminate."); //see commands
                            break;
                        default:
                            Console.WriteLine("I don't understand. Please type 'help' to see commands."); //invalid command
                            break;
                    }
                }
            }

            public static void GameOver(char tile)
            {
                Console.Clear(); //clearing terminal

                switch (tile) //compare for specific game over message
                {
                    case 'E': //case exit, winning condition
                        Console.WriteLine("Good job! You are rich now, you've found the Golden Claw!");
                        Console.WriteLine($"Your Score is: {score}");
                        break;
                    case 'C': //case waking up the cat
                        Console.WriteLine("Game over! You woke the Big Bad Cat!");
                        break;
                    case 'V': //case stepping on vomit
                        Console.WriteLine("Game over! You stepped on a very hazardous vomit!");
                        break;
                }
                Thread.Sleep(3000); //waiting 3 seconds
                Game.gameOn = false; //stopping the game loop
            }
        }  
    }
}