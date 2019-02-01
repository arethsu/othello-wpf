using System;
using System.Xml.Linq;
using System.Windows;
using System.IO;

namespace OthelloLinqLayer
{
	public class OthelloSaver
	{
		public OthelloSaver()
		{
			
		}

		public bool getTurn(string xmlfile)
		{
			XDocument readDoc;
			try
			{
				readDoc = XDocument.Load(xmlfile);
			}
			catch (FileNotFoundException e)
			{
				return true;
			}
			XElement read = readDoc.Element("root");
			return read.Element("turn").Value == "true";
		}

		public Othello.Board getBoard(string xmlfile)
		{
			int i = 0;
			int j = 0;
			Othello.Board board = new Othello.Board();
			XDocument readDoc;
			try
			{
				readDoc = XDocument.Load(xmlfile);
			}
			catch(FileNotFoundException e)
			{
				return new Othello.Board();
			}
			XElement read = readDoc.Element("root");
			foreach (XElement row in read.Elements("row"))
			{
				j = 0;
				foreach (XElement tile in row.Elements())
				{

					board.matrix[i, j] = tile.Attribute("color").Value != "0" ? insertCheck(tile.Attribute("color").Value) : null;
					//MessageBox.Show(string.Format("{0}, {1}", i, j));
					j++;
				}
				//return board;
				i++;
				//return board;
			}
			return board;
		}

		private Othello.Tile insertCheck(string color)
		{
			return new Othello.Tile(color == "B");
		}

		public void save(Othello.Board board, bool turnB)
		{
			XDocument test = new XDocument();
			test.Declaration = new XDeclaration("1.0", "utf-8", "true");
			XElement root = new XElement("root");
			XElement turn = new XElement("turn");
			turn.SetAttributeValue("blackTurn", turnB);
			root.Add(turn);

			for (int i = 0; i < 8; i++)
			{
				XElement row = new XElement("row");
				for (int j = 0; j < 8; j++)
				{
					XElement tile = new XElement("tile");
					tile.SetAttributeValue("color", checkColor(board, i, j));
					row.Add(tile);
				}
				root.Add(row);
			}
			test.Add(root);
			test.Save("test.xml");
			
		}

		private char checkColor(Othello.Board board, int i, int j)
		{
			if (board.matrix[i, j] is Othello.Tile)
				return board.matrix[i, j].isBlack ? 'B' : 'W';
			return '0';
		}

	}
}

