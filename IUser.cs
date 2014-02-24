using System;

namespace TicTacToe
{
    public interface IUser
    {
        string ReadRow();
        string ReadColumn();

        int Number { get; }
    }
}

