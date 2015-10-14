using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownAndAnchorGame
{
    public class Game
    {
        private readonly List<Dice> dice;
        private readonly List<DiceValue> values;

        public IList<DiceValue> CurrentDiceValues
        {
            get { return values.AsReadOnly(); }
        }


        public Game(Dice die1, Dice die2, Dice die3)
        {
            dice = new List<Dice>();
            values = new List<DiceValue>();
            dice.Add(die1);
            dice.Add(die2);
            dice.Add(die3);

            foreach (var die in dice)
            {
                values.Add(die.CurrentValue);
            }
        }

        public int playRound(Player player, DiceValue pick, int bet)
        {
            if (player == null) throw new ArgumentException("Player cannot be null");
            if (player == null) throw new ArgumentException("Pick cannot be null");
            if (bet < 0) throw new ArgumentException("Bet cannot be negative");


            player.takeBet(bet);

            // start with zero matches
            int matches = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                //dice[i].roll();
                if (dice[i].CurrentValue == pick)
                    { 
                        matches += 1;
                    }
                values[i] = dice[i].CurrentValue;
            }



            int winnings = 0;

            if (matches > 0)
            {
                //winnings = (matches * bet);  //Error in this line
                winnings = (matches * bet) + bet;
                player.receiveWinnings(winnings);
            }
            else
            {
                winnings = -5;
            }
            Console.WriteLine("there were {0} matches", matches);
            return winnings;
        }
    }
}
