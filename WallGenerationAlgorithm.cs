using MafeuhLabyWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MafeuhLabyWPF
{
    public abstract class WallGenerationAlgorithm
    {
        public static List<WallGenerationAlgorithm> WGAList = new List<WallGenerationAlgorithm>()
        {
            new RandPrim(),
            new RandomWalls()
        };
        protected Grid grid;
        public virtual bool HasBorderWalls { get; set; }
        public string AlgorithmName { get; set; }
        public WallGenerationAlgorithm(string algorithmName, Grid grid)
        {
            AlgorithmName = algorithmName;
            this.grid = grid;
        }
        public WallGenerationAlgorithm(string algorithmName)
        {
            AlgorithmName = algorithmName;
        }
        public abstract void Generate();
        public override string ToString()
        {
            return AlgorithmName;
        }
    }
    class RandomWalls : WallGenerationAlgorithm
    {
        private static Random rnd = new Random();
        public static RandomWalls Instance = new RandomWalls();
        public float WallDensity { get; set; } = 0.5f;
        public RandomWalls() : base("Random Walls")
        {
            Instance = this;
        }
        public override void Generate()
        {
            foreach(StackPanel col in MainWindow.Instance.simGrid.Children)
            {
                int x = MainWindow.Instance.simGrid.Children.IndexOf(col);
                foreach(Rectangle cell in col.Children)
                {
                    int y = col.Children.IndexOf(cell);

                    if(rnd.NextDouble() < WallDensity)
                    {
                        MainWindow.Instance.Walls.Add(cell);
                        cell.Fill = new SolidColorBrush(MainWindow.CellTypeGetColor(MainWindow.CellType.Wall));
                    } else
                    {
                        cell.Fill = new SolidColorBrush(MainWindow.CellTypeGetColor(MainWindow.CellType.Path));
                    }
                }
            }
        }
    }
    class RandPrim : WallGenerationAlgorithm
    {
        public static RandPrim Instance = new RandPrim();
        private List<Cell> wallList = new List<Cell>();
        public RandPrim() : base("Rand Prim")
        {
            Instance = this;
        }
        public override void Generate()
        {

        }
        public void Generate(Cell cell)
        {
            /*
            wallList.AddRange(cell.GetNeighbors.Where(n => n.IsWall));
            wallList.RemoveAll(n => n.GetNeighbors.Count(n2 => !n2.IsWall) != 1);
            if(wallList.Count > 0)
            {
                Cell nextWall = wallList[new Random().Next(wallList.Count)];
                wallList.Remove(nextWall);
                nextWall.IsWall = false;
                Game1.Instance.AddEvent(new TimedEvent(() => Generate(nextWall), 0));
            } else
            {
                grid.EndCell.IsWall = false;

                if(grid.EndCell.GetNeighbors.Count(n => !n.IsWall) == 0)
                {
                    grid.EndCell.GetNeighbors[new Random().Next(grid.EndCell.GetNeighbors.Count)].IsWall = false;
                }
            }
            */
        }
    }
}
