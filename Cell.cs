using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MafeuhLabyWPF
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWall { get; set; }
        public bool IsVisited { get; set; }
        public bool IsHeader { get; set; }
        public CellType Type { get; set; } = CellType.Path;
        private CellGrid parentGrid;
        public Cell(int x, int y, CellGrid parentGrid) : this(x, y)
        {
            this.parentGrid = parentGrid;
        }
        private Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void SetType(CellType type)
        {
            Type = type;
        }
    }



    public enum CellType
    {
        Wall,
        Path,
        End,
        Start
    }
    public class CellTypeM
    {
        public static Color CellTypeGetColor(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Wall:
                    return Colors.Gray;
                case CellType.Path:
                    return Colors.White;
                case CellType.End:
                    return Colors.Red;
                case CellType.Start:
                    return Colors.Green;
            }
            return Colors.Transparent;
        }
    }
}
