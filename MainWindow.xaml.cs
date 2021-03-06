﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OthelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Othello.GameEngine gameEngine = new Othello.GameEngine();


        public MainWindow()
        {
            InitializeComponent();
            
            updateBoard();

        }

		private void CellClicker(object sender, RoutedEventArgs e)
		{
			
			Button button = (Button)sender;
			int row = Grid.GetRow(button);
			int col = Grid.GetColumn(button);

			gameEngine.PlaceTile(row, col);
			updateBoard();
		}

        private void updateBoard()
        {
			grid.Children.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

					if (gameEngine.getBoard().matrix[i, j] is Othello.Tile)
                    {
                        Ellipse el1 = new Ellipse();
                        el1.Fill = new SolidColorBrush(getColor(gameEngine.getBoard().matrix[i, j].isBlack));
                        Grid.SetRow(el1, i);
                        Grid.SetColumn(el1, j);
                        grid.Children.Add(el1);
                    }
					else
					{
						Button btn = new Button();
						Grid.SetRow(btn, i);
						Grid.SetColumn(btn, j);
						btn.Opacity = 0;
						btn.Click += CellClicker;
						grid.Children.Add(btn);
					}
					if (gameEngine.blackTurn)
					{
						turn.Text = "Black turn";
					}
					else
					{
						turn.Text = "White turn";
					}
					score.Text = string.Format("Score:\nBlack: {0}\nWhite: {1}", gameEngine.blackScore, gameEngine.whiteScore);

					
				}
            }
			if (!gameEngine.hasPossibleMove(gameEngine.blackTurn))
			{
				if (gameEngine.blackScore > gameEngine.whiteScore)
				{
					MessageBox.Show("Black won! Game will now reset.");
				}
				else
				{
					MessageBox.Show("White won! Game will now reset.");
				}
				gameEngine.resetGame();
				updateBoard();
            }
        }

        private Color getColor(bool a)
        {
			return a ? Colors.Black : Colors.White;
        }
    }
}
