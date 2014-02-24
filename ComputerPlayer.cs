using System;

namespace TicTacToe
{
    public class ComputerPlayer:IUser
    {
        private int Size;

        public ComputerPlayer(int number, int size)
        {
            Size = size;
            Number = number;
        }

        public string ReadRow()
        {
            var value = new Random().Next(Size) + 1;
            Console.WriteLine(value);
            return value.ToString();
        }

        public string ReadColumn()
        {
            var value = new Random().Next(Size) + 1;
            Console.WriteLine(value);
            return value.ToString();
        }

        public int Number { get; private set; }
    }
}

