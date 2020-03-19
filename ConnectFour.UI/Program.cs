using ConnectFour.Logic;
using System;

namespace ConnectFour.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            
            while(!board.CheckIfBoardIsFull() && !board.CheckIfPlayerWon())
            {
                board.AddStone((byte) Console.Read());
            }
        }
    }
}
