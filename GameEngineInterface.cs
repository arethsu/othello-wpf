
namespace Othello
{
	public interface GameEngineInterface
	{
		void PrintBoard();
        Board getBoard();
		Board PlaceTile(int x, int y);
	}
}
