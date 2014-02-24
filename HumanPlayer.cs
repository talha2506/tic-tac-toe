using System;

namespace TicTacToe
{
    public class HumanPlayer:IUser
    {
        public HumanPlayer(int number)
        {
            Number = number;
        }

        public string ReadRow()
        {
            return Console.ReadLine();
        }

        public string ReadColumn()
        {
            return Console.ReadLine();
        }

        public int Number { get; private set; }
    }
}

