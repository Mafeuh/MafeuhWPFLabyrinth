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
        public virtual bool HasBorderWalls { get; set; }
        public string AlgorithmName { get; set; }
        public List<Rectangle> Walls { get; set; } = new List<Rectangle>();
        public WallGenerationAlgorithm(string algorithmName)
        {
            AlgorithmName = algorithmName;
        }
        public virtual void Generate()
        {
            Walls.Clear();
        }
        public override string ToString()
        {
            return AlgorithmName;
        }

        public List<Rectangle> GetNeighbors((int x, int y) pos)
        {
            var instance = MainWindow.Instance;
            var width = instance.CurrentSimulation.CurrentWidth;
            var height = instance.CurrentSimulation.CurrentHeight;

            List<Rectangle> result = new List<Rectangle>();
            if (pos.x - 1 >= 0) result.Add(instance.GetCellFromGrid(pos.x - 1, pos.y));
            if (pos.x + 1 < width) result.Add(instance.GetCellFromGrid(pos.x + 1, pos.y));
            if (pos.y - 1 >= 0) result.Add(instance.GetCellFromGrid(pos.x, pos.y - 1));
            if (pos.y + 1 < height) result.Add(instance.GetCellFromGrid(pos.x, pos.y + 1));

            return result;
        }
        public List<(int x, int y)> GetNeighborsPositions((int x, int y) pos)
        {
            var instance = MainWindow.Instance;
            var width = instance.CurrentSimulation.CurrentWidth;
            var height = instance.CurrentSimulation.CurrentHeight;

            List<(int x, int y)> result = new List<(int x, int y)>();
            if (pos.x - 1 >= 0) result.Add((pos.x - 1, pos.y));
            if (pos.x + 1 < width) result.Add((pos.x + 1, pos.y));
            if (pos.y - 1 >= 0) result.Add((pos.x, pos.y - 1));
            if (pos.y + 1 < height) result.Add((pos.x, pos.y + 1));

            return result;
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
            base.Generate();
            foreach(StackPanel col in MainWindow.Instance.SimulationGrid.Children)
            {
                int x = MainWindow.Instance.SimulationGrid.Children.IndexOf(col);
                foreach(Rectangle cell in col.Children)
                {
                    int y = col.Children.IndexOf(cell);

                    if(rnd.NextDouble() < WallDensity)
                    {
                        Walls.Add(cell);
                        cell.Fill = new SolidColorBrush(CellTypeM.CellTypeGetColor(CellType.Wall));
                    } else
                    {
                        cell.Fill = new SolidColorBrush(CellTypeM.CellTypeGetColor(CellType.Path));
                    }
                }
            }
        }
    }
    class RandPrim : WallGenerationAlgorithm
    {
        public static RandPrim Instance = new RandPrim();
        public List<(int x, int y)> walls = new List<(int x, int y)>();
        public RandPrim() : base("Rand Prim")
        {
            Instance = this;
        }
        public override void Generate()
        {
            base.Generate();

            
        }
        private void Generate((int x, int y) pos)
        {
            if (pos.x < 0 || pos.y < 0 || pos.x >= MainWindow.Instance.CurrentSimulation.CurrentWidth || pos.y >= MainWindow.Instance.CurrentSimulation.CurrentHeight) return;

            Rectangle r = MainWindow.Instance.GetCellFromGrid(pos.x, pos.y);

            foreach(var neighbor in GetNeighborsPositions((pos.x, pos.y)))
            {
                if (!walls.Contains(neighbor)) walls.Add(neighbor);
            }
        }
    }
}
