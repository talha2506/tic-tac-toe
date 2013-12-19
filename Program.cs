using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool ok = false;
            while (!ok)
            {
                Console.WriteLine("Bitte geben sie die Anzahl menschlicher Spieler ein! (1-2)");
                string anzahlSpieler = Console.ReadLine();
                if (anzahlSpieler != "1" && anzahlSpieler != "2")
                    Console.WriteLine("Sie haben eine Illegale Zahl eingegeben!");
                else
                    ok = true;
            }

            var game = new Game();
            game.Play();
        }
    }
}