using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MafeuhLabyWPF
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWall { get; set; }
        public bool IsVisited { get; set; }
        public bool IsHeader { get; set; }
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
    }



    public enum CellType
    {
        Wall,
        Path,
        End,
        Start
    }
}
