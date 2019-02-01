using System;
namespace Othello
{
    public class Tile
    {
        public bool isBlack;

        public Tile(bool black)
        {
            isBlack = black;
        }

        public void Flip()
        {
            isBlack = !isBlack;
        }
    }
}