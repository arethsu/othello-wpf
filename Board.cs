
namespace Othello
{
	public class Board
	{
		public Tile[,] matrix = new Tile[8, 8];

		public Board()
		{
			ResetBoard();
		}

		public void ResetBoard()
		{
			matrix = new Tile[8, 8];
			matrix[3, 3] = new Tile(true);
			matrix[4, 3] = new Tile(false);
			matrix[3, 4] = new Tile(false);
			matrix[4, 4] = new Tile(true);
		}

		public void Print()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (matrix[i, j] is Tile)
					{
						if (matrix[i, j].isBlack)
						{
							System.Console.Write("B ");
						}
						else
						{
							System.Console.Write("W ");
						}
					}
					else
					{
						System.Console.Write(". ");
					}
				}
				System.Console.WriteLine(" ");
			}
		}
	}
}
