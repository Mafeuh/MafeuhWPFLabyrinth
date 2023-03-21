using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafeuhLabyWPF
{
    public class CellGrid
    {
        public List<Cell> Cells { get; set; }
        public Cell EndCell { get; set; }
        public Cell StartCell { get; set; }
        public CellGrid() { }
        public CellGrid(List<Cell> cells)
        {
            Cells = cells;
        }
        public CellGrid(int x, int y)
        {
            Cells = new List<Cell>();
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    Cells.Add(new Cell(i, j, this));
                }
            }
        }
    }
}
