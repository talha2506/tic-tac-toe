using System;

namespace TicTacToe
{
    public class Game
    {
        private const int Size = 3;

        private int[,] m_Spielfeld = new int[Size, Size];

        public Game()
        {

        }

        private void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    m_Spielfeld[i, j] = 0;
                }
            }
        }

        private string GetValue(int row, int column)
        {
            string x;
            switch (m_Spielfeld[row, column])
            {
                case 1:
                    x = "X";
                    break;
                case (Size + 1):
                    x = "O";
                    break;
                default:
                    x = " ";
                    break;
            }
            return x;
        }

        private void Display()
        {
            for (int i = 0; i < Size; i++)
            {
                if (i > 0)
                    Console.WriteLine("---|---|---");
                for (int j = 0; j < Size; j++)
                {
                    if (j > 0)
                        Console.Write("|");

                    Console.Write(" {0} ", GetValue(i, j));

                }
                Console.WriteLine();
            }
        }

        private bool Input(int playerNumber)
        {
            Console.WriteLine("Spieler {0}", playerNumber);
            Console.Write("Zeile (1-{0}): ", Size);
            var rowString = Console.ReadLine();
            Console.Write("Spalte (1-{0}): ", Size);
            var columnString = Console.ReadLine();
            int row;
            bool ok;
            ok = int.TryParse(rowString, out row);
            int column;
            ok &= int.TryParse(columnString, out column);
            if (ok)
            {
                if (row < 1 || row > 3 || column < 1 || column > 3)
                    ok = false;
            }
            if (!ok)
            {
                Console.WriteLine("Sie haben einen illegalen Wert eingegeben!");
                return Input(playerNumber);
            }
            row--;
            column--;
            if (m_Spielfeld[row, column] != 0)
            {
                Console.WriteLine("Bitte treffen sie eine andere Auswahl!\nDieses Feld ist schon belegt!");
                return Input(playerNumber);
            }
            if (playerNumber == 1)
                m_Spielfeld[row, column] = playerNumber;
            else
                m_Spielfeld[row, column] = 4;
            return !Playerwins(playerNumber);
        }

        private bool Playerwins(int playerNumber)
        {
            //check rows
            int sum = 0;
            for (int row = 0; row < Size; row++)
            {
                sum = 0;               
                for (int column = 0; column < Size; column++) 
                {
                    sum = sum + m_Spielfeld[row, column];
                }
                if (sum == Size || sum == Size * (Size + 1))
                    return OutputPlayerwins(playerNumber);
            }

            //check columns
            for (int column = 0; column < Size; column++) 
            {
                sum = 0;
                for (int row = 0; row < Size; row++) 
                {
                    sum = sum + m_Spielfeld[row, column];
                }
                if (sum == Size || sum == Size * (Size + 1))
                    return OutputPlayerwins(playerNumber);
            }

            //check diagonal from top left to bottom right
            sum = 0;
            for (int rowcolumn = 0; rowcolumn < Size; rowcolumn++) 
            {
                sum = sum + m_Spielfeld[rowcolumn, rowcolumn];
            }
            if (sum == Size || sum == Size * (Size + 1))
                return OutputPlayerwins(playerNumber);

            //check diagonal from top right to bottom left
            sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum = sum + m_Spielfeld[i, Size - 1 - i];
            }
            if (sum == Size || sum == Size * (Size + 1))
                return OutputPlayerwins(playerNumber);
            return false;
        }

        private  bool OutputPlayerwins(int playerNumber)
        {
            Console.WriteLine("\n\nSpieler {0} hat gewonnen!!!\nHerzlichen Glückwunsch!\n", playerNumber);
            return true;
        }

        public void Play()
        {
            Initialize();
            bool continuegame = true;
            for (int i = 0; continuegame && i < Size * Size; i++)
            {
                Display();
                continuegame = Input((i%2) + 1);
            }
            if (continuegame)
                Console.WriteLine("Unentschieden!!!");
        }
    }
}
