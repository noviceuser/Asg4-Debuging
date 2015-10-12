using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownAndAnchorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise starting total variables for wins and losses
            int totalWins = 0;
            int totalLosses = 0;

            while (true)
            {
                int winCount = 0;
                int loseCount = 0;
                for (int i = 0; i < 100; i++)
                {
                    //Create a player and give him initial balance and write it to console
                    Dice d1 = new Dice();
                    Dice d2 = new Dice();
                    Dice d3 = new Dice();
                    //Create a new game and give it the 3 dice
                    Game g = new Game(d1, d2, d3);                    
                    //Create a new player and bet amount
                    Player p = new Player("Fred", 100);
                    Console.Write("Start Game {0}: ", i);
                    Console.WriteLine("{0} starts with balance {1}", p.Name, p.Balance);

                    //Initialise turn counter
                    int turn = 0;

                    //initialise bet amount
                    int bet = 5;

                    //initalise player limit
                    p.Limit = 0;
                    int winnings = 0;
                    while (p.balanceExceedsLimitBy(bet) && p.Balance < 200)
                    {

                        try
                        {
                            Console.WriteLine();
                            //Player pics a face and write to console
                            DiceValue pick = Dice.RandomValue;
                            Console.WriteLine("Player {0} Picked {1}", p.Name, pick);
                            
                            //play a game
                            IList<DiceValue>cdv = g.CurrentDiceValues;
                            winnings = g.playRound(p, pick, bet);


                            Console.WriteLine("Rolled {0} {1} {2}", cdv[0], cdv[1], cdv[2]);
                            if (winnings > 0)
                            {
                                Console.WriteLine("{0} won {1} balance now {2}", p.Name, winnings, p.Balance);
                                winCount++;
                            }
                            else
                            {
                                Console.WriteLine("{0} lost {1} balance now {2}", p.Name, bet, p.Balance);
                                loseCount++;
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}\n\n", e.Message);
                        }
                        winnings = 0;
                        turn++;
                    } //while

                    Console.Write("{1} turns later.\nEnd Game {0}: ", turn, i);
                    Console.WriteLine("{0} now has balance {1}\n", p.Name, p.Balance);
                } //for

                Console.WriteLine("Win count = {0}, Lose Count = {1}, {2:0.00}", winCount, loseCount, (float) winCount/(winCount+loseCount));
                totalWins += winCount;
                totalLosses += loseCount;

                string ans = Console.ReadLine();
                if (ans.Equals("q")) break;
            } //while true
            Console.WriteLine("Overall win rate = {0}%", (float)(totalWins * 100) / (totalWins + totalLosses));
            Console.ReadLine();
        } 
    }
}
