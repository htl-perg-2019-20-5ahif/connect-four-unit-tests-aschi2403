using System;

namespace ConnectFour.Logic
{
    public class Board
    {
        /// <summary>
        /// [Column, Row]
        /// </summary>
        private readonly byte[,] GameBoard = new byte[7,6];

        internal int Player = 0;

        public void AddStone(byte column)
        {
            if (column > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            for (int row = 0; row < 6; row++)
            {
                var cell = GameBoard[column, row];

                if (cell == 0)
                {
                    Player = (Player + 1) % 2;
                    GameBoard[column, row] = (byte)(Player + 1);
                    return;
                }
            }

            throw new InvalidOperationException("Column is full");
        }

        public bool CheckIfPlayerWon()
        {
            for(var i = 0; i < GameBoard.GetLongLength(0); i++)
            {
                var similarCount = 1;
                var lastColor = 0;

                for(var y = 0; i < 7; i++)
                {
                    if(lastColor == GameBoard[i,y] && GameBoard[i,y] == Player)
                    {
                        similarCount++;
                        if (similarCount == 4)
                            return true;
                    }
                    else
                    {
                        similarCount = 1;
                    }
                    lastColor = GameBoard[i, y];
                }
            }

            return false;
        }

        public bool CheckIfBoardIsFull()
        {
            var emptyFields = 0;
            for (var i = 0; i < GameBoard.GetLongLength(0); i++)
            {
                for (var y = 0; i < 7; i++)
                {
                    if (GameBoard[i,y] == 0)
                    {
                        emptyFields++;
                    }
                }
            }

            return emptyFields == 0;
        }
    }
}
