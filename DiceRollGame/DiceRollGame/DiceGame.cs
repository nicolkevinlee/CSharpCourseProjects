using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
    class DiceGame
    {

        private const int MaxTries = 3;

        private int _curTries = 0;
        private Die _die;

        public DiceGame() {

            _die = new Die();
        }

        public GameResult StartGame()
        {
            int guessInput;


            _die.RollDie();

            Console.WriteLine($"Dice rolled. Guess what number it shows in {MaxTries} tries.");

            do
            {
                guessInput = Validator.GetInput();
                
                if (guessInput == _die.NumberOnTop)
                {
                    return GameResult.Victory;
                }
                else
                {
                    Console.WriteLine("Wrong Number.");
                    _curTries++;
                }

            } while (_curTries < MaxTries);

            return GameResult.Loss;
        }

        public static void PrintResult(GameResult result)
        {
            var message = result == GameResult.Victory ? "You Win!" : "You Lose.";
            Console.WriteLine(message);
        }
        
    }
}
