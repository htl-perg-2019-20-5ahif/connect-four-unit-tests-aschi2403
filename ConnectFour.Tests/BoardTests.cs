using ConnectFour.Logic;
using System;
using Xunit;

namespace ConnectFour.Tests
{
    public class BoardTests
    {
        [Fact]
        public void AddWithInvalidColumnIndex()
        {
            var b = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => b.AddStone(7));
        }

        [Fact]
        public void PlayerChangesWhenAddingStone()
        {
            var b = new Board();

            var oldPlayer = b.Player;
            b.AddStone(0);

            // Verify that player has changed
            Assert.NotEqual(oldPlayer, b.Player);
        }

        [Fact]
        public void AddingTooManyStonesToARow()
        {
            var b = new Board();

            for(var i=0; i<6; i++)
            {
                b.AddStone(0);
            }

            var oldPlayer = b.Player;
            Assert.Throws<InvalidOperationException>(() => b.AddStone(0));
            Assert.Equal(oldPlayer, b.Player);
        }

        [Fact]
        public void PlayerWinnsHorizontally()
        {
            var board = new Board();

            for (byte i = 0; i < 7; i++)
            {
                board.AddStone(i);
            }

            var result = board.CheckIfPlayerWon();
            Assert.True(result);
        }

        [Fact]
        public void GameEndsWhenBoardIsFull()
        {
            var board = new Board();
            for (var i = 0; i < 6; i++)
            {
                for(byte j = 0; j < 7; j++)
                {
                    board.AddStone(j);
                }
            }

            var result = board.CheckIfBoardIsFull();
            Assert.True(result);
        }
    }
}
