using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfSeaBattle;
using System.Threading; //! can't find Game without it

namespace WpfAppSeaBattle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game smbdsGame;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaceRowsAndColumns(fieldGridLeft);
            PlaceRowsAndColumns(fieldGridRight);

            PlaceButtons(fieldGridLeft, true);
            PlaceButtons(fieldGridRight, false);

            StartNewGame();
        }

        void StartNewGame() 
        {
            smbdsGame = new Game();
            DrawBothFields();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            smbdsGame = new Game();

            DrawBothFields();
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            int x = Grid.GetRow((UIElement)sender);
            int y = Grid.GetColumn((UIElement)sender);
            if (smbdsGame.CheckIfMoveIsTransmittedAndMarkTheCell(x, y, smbdsGame.computerField))
            {
                //computer's turn
                DrawBothFields();
                do
                {
                    //CheckWonLost();
                    smbdsGame.ComputersMove(smbdsGame.playerField);
                    //Thread.Sleep(1000);
                    DrawBothFields();
                    if (smbdsGame.CheckSmbdWonLost() == 0)
                    {
                        CheckWonLost();
                        break;
                    }
                } while (!smbdsGame.CheckIfMoveIsTransmittedAndMarkTheCell(smbdsGame.x, smbdsGame.y, smbdsGame.playerField));
            } 
            DrawBothFields();
            CheckWonLost();
        }

        void DrawBothFields() 
        {
            PaintButtons(fieldGridLeft, smbdsGame.playerField, true);
            PaintButtons(fieldGridRight, smbdsGame.computerField, false);
        }

        void PaintButtons(Grid gridWithButtons, Game.CellType[,] field, bool playerField) 
        {
            foreach (UIElement btn in gridWithButtons.Children)
            {
                if (btn is Button)
                {
                    switch (field[Grid.GetRow(btn), Grid.GetColumn(btn)])
                    {
                        case Game.CellType.Empty:
                            {
                                ((Button)btn).Content = "";
                                ((Button)btn).Background = Brushes.Gainsboro;
                                break;
                            }
                        case Game.CellType.Dot:
                            {
                                ((Button)btn).Background = Brushes.Gainsboro;
                                ((Button)btn).Content = new Ellipse() { Height = 5, Width = 5, Fill=Brushes.Black};
                                break;
                            }
                        case Game.CellType.Ship:
                            {
                                ((Button)btn).Content = "";
                                if (playerField)
                                    ((Button)btn).Background = Brushes.DarkGray;
                                else 
                                    ((Button)btn).Background = Brushes.Gainsboro;
                                break;
                            }
                        case Game.CellType.Damaged:
                            {
                                ((Button)btn).Content = "";
                                ((Button)btn).Background = Brushes.LightSkyBlue;
                                break;
                            }
                        case Game.CellType.Destroyed:
                            {
                                ((Button)btn).Content = "";
                                ((Button)btn).Background = Brushes.MidnightBlue;
                                break;
                            }
                    }
                }
            }
        }

        void PlaceRowsAndColumns(Grid currentGrid) 
        {
            for (int i = 0; i < Game.fieldSize; i++)
            {
                currentGrid.RowDefinitions.Add(new RowDefinition());
                currentGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        void PlaceButtons(Grid gridToPlaceOn, bool playerField) 
        {
            for (int x = 0; x < Game.fieldSize; x++)
            {
                for (int y = 0; y < Game.fieldSize; y++)
                {
                    Button btn = new Button();
                    if (!playerField) //do not forget to uncomment this
                        btn.Click += new RoutedEventHandler(btn_Click);

                    this.SizeToContent = SizeToContent.WidthAndHeight;
                    
                    btn.Height = 30;
                    btn.Width = 30;
                    Grid.SetColumn(btn, y);
                    Grid.SetRow(btn, x);
                    gridToPlaceOn.Children.Add(btn);
                }
            }
        }

        void CheckWonLost() 
        {
            switch (smbdsGame.CheckSmbdWonLost()) 
            {
                case 0: 
                    {
                        MessageBox.Show("Nooooooooooooooooooooooo"); 
                        StartNewGame(); 
                        break; 
                    }
                case 1: 
                    {
                        MessageBox.Show("Hooray!"); 
                        StartNewGame(); 
                        break; 
                    }
            }
        }

    }
}
