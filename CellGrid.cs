using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MafeuhLabyWPF
{
    public class CellGrid
    {
        public List<Cell> Cells { get; set; }
        public List<Cell> EndCells { get; set; }
        public List<Cell> StartCells { get; set; }
        private MainWindow window => MainWindow.Instance;
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
        public Cell GetCell(int x, int y)
        {
            return Cells.Where(c => c.X == x && c.Y == y).FirstOrDefault();
        }
        public void ChangeCellType(Cell cell, CellType newType)
        {
            cell.SetType(newType);

            window.GetCellFromGrid(cell.X, cell.Y).Fill = new SolidColorBrush(CellTypeM.CellTypeGetColor(cell.Type));
        }
        public void ChangeCellType(int x, int y, CellType newType)
        {
            ChangeCellType(GetCell(x, y), newType);
        }
    }
}
