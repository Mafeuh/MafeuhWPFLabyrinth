using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MafeuhLabyWPF
{
    public class Simulation
    {
        public (int X, int Y) EndPosition = (0, 0);
        public (int X, int Y) StartPosition = (0, 0);
        public int NextWidth { get; set; } = 20;
        public int NextHeight { get; set; } = 30;
        public int CurrentWidth { get; set; }
        public int CurrentHeight { get; set; }
        public WallGenerationAlgorithm Algorithm { get; set; }
        public CellGrid CellGrid { get; set; }
        public Settings Settings { get; set; } = new Settings();
        
        public Simulation()
        {

        }
        public void NotifyPropertyChanged(string propertyName)
        {

        }
    }
}
