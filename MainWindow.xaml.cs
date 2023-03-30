using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/**
 * A FAIRE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 * - Modifier l'interface pour ajouter la sélection de l'algo de solvage
 * 
 * 
 * 
 * 
 * 
 */

namespace MafeuhLabyWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        public static MainWindow Instance { get; set; }
        public Simulation CurrentSimulation { get; set; }
        public Settings Settings => CurrentSimulation.Settings;
        public Rectangle GetStartRectangle => GetCellFromGrid(CurrentSimulation.StartPosition.X, CurrentSimulation.StartPosition.Y);
        public Rectangle GetEndRectangle => GetCellFromGrid(CurrentSimulation.EndPosition.X, CurrentSimulation.EndPosition.Y);

        public List<Rectangle> GetCrossNeighbors(int x, int y)
        {

            return new List<Rectangle>();
        }
        public MainWindow()
        {
            InitializeComponent();
            CurrentSimulation = new Simulation();
            DataContext = this;

            btnPauseSolv.IsEnabled = false;
            btnStopSolv.IsEnabled = false;
            showGrid.IsEnabled = true;

            foreach (var item in WallGenerationAlgorithm.WGAList) algoList.Items.Add(item);

            Instance = this;

        }
        private Rectangle CreateCell(int amount, CellType type)
        {
            int side = Convert.ToInt32(SimulationGrid.ActualWidth / amount);
            Rectangle cell = new Rectangle()
            {
                Stroke = new SolidColorBrush(showGrid.IsEnabled ? Colors.Black : Colors.Transparent),
                Width = side,
                Height = side
            };
            
            //Génération du style du rectangle
            cell.Fill = new SolidColorBrush(CellTypeM.CellTypeGetColor(type));
            var margin = cell.Margin;
            margin.Top = -1;
            cell.Margin = margin;

            //Ajout d'une détection d'événement MouseClick
            cell.MouseRightButtonDown += new MouseButtonEventHandler(Rectangle_OnRightClick);
            cell.MouseLeftButtonDown += new MouseButtonEventHandler(Rectangle_OnLeftClick);


            return cell;
        }
        private void Rectangle_OnLeftClick(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)sender;
            
            //Récupération des coordonnées X et Y du rectangle
            int x = SimulationGrid.Children.IndexOf((StackPanel)rect.Parent);
            int y = ((StackPanel)rect.Parent).Children.IndexOf(rect);

            if(CurrentSimulation.StartPosition.X > -1 && CurrentSimulation.StartPosition.Y > -1)
            {
                if(x == CurrentSimulation.StartPosition.X && y == CurrentSimulation.StartPosition.Y)
                {
                    CurrentSimulation.StartPosition = (-1, -1);
                    GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.White);
                } else
                {
                    //TEMP Remplacer par détection automatique de couleur en fonction de si c'est un mur ou pas
                    GetCellFromGrid(CurrentSimulation.StartPosition.X, CurrentSimulation.StartPosition.Y).Fill = new SolidColorBrush(Colors.White);
                    //END TEMP
                    
                    GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.Green);
                    CurrentSimulation.StartPosition = (x, y);
                }
            } else
            {
                GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.Green);
                CurrentSimulation.StartPosition = (x, y);
            }
        }
        private void Rectangle_OnRightClick(object sender, MouseButtonEventArgs e)
        {
            var rect = (Rectangle)sender;

            //Récupération des coordonnées X et Y du rectangle
            int x = SimulationGrid.Children.IndexOf((StackPanel)rect.Parent);
            int y = ((StackPanel)rect.Parent).Children.IndexOf(rect);

            if (CurrentSimulation.EndPosition.X > -1 && CurrentSimulation.EndPosition.Y > -1)
            {
                if (x == CurrentSimulation.EndPosition.X && y == CurrentSimulation.EndPosition.Y)
                {
                    CurrentSimulation.EndPosition = (-1, -1);
                    GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.White);
                }
                else
                {
                    //TEMP Remplacer par détection automatique de couleur en fonction de si c'est un mur ou pas
                    GetCellFromGrid(CurrentSimulation.EndPosition.X, CurrentSimulation.EndPosition.Y).Fill = new SolidColorBrush(Colors.White);
                    //END TEMP

                    GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.Red);
                    CurrentSimulation.EndPosition = (x, y);
                }
            }
            else
            {
                GetCellFromGrid(x, y).Fill = new SolidColorBrush(Colors.Red);
                CurrentSimulation.EndPosition = (x, y);
            }
        }

        private void generateNewGrid_Click(object sender, RoutedEventArgs e)
        {
            if(
                int.TryParse(inputWidth.Text, out int newWidth) && 
                int.TryParse(inputHeight.Text, out int newHeight) && newWidth > 1 && newHeight > 1)
            {
                CurrentSimulation.CellGrid = new CellGrid(newWidth, newHeight);

                SimulationGrid.Children.Clear();
                SimulationGrid.ColumnDefinitions.Clear();
                SimulationGrid.RowDefinitions.Clear();

                int sizeInPixels = Convert.ToInt32(Math.Min(
                    (GridGroupBox.ActualHeight - 10) / newHeight, 
                    (GridGroupBox.ActualWidth - 10) / newWidth
                ));
                for(int i = 0; i < newWidth; i++) SimulationGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(sizeInPixels),
                });
                for (int i = 0; i < newHeight; i++) SimulationGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(sizeInPixels)
                });

                for(int i = 0; i < newWidth; i++)
                {
                    for(int j = 0; j < newHeight; j++)
                    {
                        Rectangle rect = new Rectangle()
                        {
                            Fill = new SolidColorBrush(CellTypeM.CellTypeGetColor(CellType.Path))
                        };
                        Grid.SetColumn(rect, i);
                        Grid.SetRow(rect, j);
                        SimulationGrid.Children.Add(rect);
                    }
                }

                SimulationGrid.Height = newHeight * sizeInPixels;
                SimulationGrid.Width = newWidth * sizeInPixels;

                CurrentSimulation.CellGrid.ChangeCellType(1, 1, CellType.End);
                CurrentSimulation.CellGrid.ChangeCellType(2, 2, CellType.Start);
            } else
            {
                MessageBox.Show("Entiers supérieurs à 1 uniquement !");
            }
        }
        public Rectangle GetCellFromGrid(int x, int y)
        {
            var grid = SimulationGrid;

            return grid.Children.Cast<Rectangle>().First(c => Grid.GetRow(c) == y && Grid.GetColumn(c) == x);
        }
        private void btnStartSolv_Click(object sender, RoutedEventArgs e)
        {
            btnPauseSolv.IsEnabled = true;
            btnStopSolv.IsEnabled = true;
            btnStartSolv.IsEnabled = false;
        }

        private void btnStopSolv_Click(object sender, RoutedEventArgs e)
        {
            btnPauseSolv.IsEnabled = false;
            btnStopSolv.IsEnabled = false;
            btnStartSolv.IsEnabled = true;
        }

        private void algoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = algoList.SelectedItem;
            if(select is RandomWalls rw)
            {
                CurrentSimulation.Algorithm = rw;

                var settings = new RandomWallsSettings();
                settings.ShowDialog();
            } else if(select is RandPrim rp)
            {
                CurrentSimulation.Algorithm = rp;
            }
        }

        private void btnCreateWalls_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentSimulation.Algorithm != null)
            {
                CurrentSimulation.Algorithm.Generate();
            } else
            {
                MessageBox.Show("Please select an algorithm in the list");
            }
        }
    }

    public class TimedEvent
    {
        public DateTime ExecutionTime { get; set; }
        public Action Action { get; set; }
        public TimedEvent(DateTime executionTime, Action action)
        {
            ExecutionTime = executionTime;
            Action = action;
        }
        public TimedEvent(int delayInS, Action action)
        {
            ExecutionTime = DateTime.Now.AddSeconds(delayInS);
            Action = action;
        }
    }
}
