using System;

namespace TicTacToe
{
    class MainClass
    {
        private const int BoardSize = 3;
        //groesse des Spielfeldes definieren.
        public static void Main(string[] args)
        {
            bool ok = false;
            string anzahlSpieler = string.Empty;
            while (!ok)
            {
                Console.WriteLine("Bitte geben sie die Anzahl menschlicher Spieler ein! (1-2)");
                anzahlSpieler = Console.ReadLine();
                if (anzahlSpieler != "1" && anzahlSpieler != "2")
                    Console.WriteLine("Sie haben eine Illegale Zahl eingegeben!");
                else
                    ok = true;
            }

            IUser[] players = new IUser[2];
            players[0] = new HumanPlayer(1);

            if (anzahlSpieler == "2")
            {
                players[1] = new HumanPlayer(2);
            }
            else
            {
                players[1] = new ComputerPlayer(2, BoardSize);
            }

            var game = new Game(BoardSize);
            game.Play(players);
        }
    }
}