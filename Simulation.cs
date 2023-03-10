using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MafeuhLabyWPF
{
    public class Simulation
    {
        public (int X, int Y) EndPosition = (0, 0);
        public (int X, int Y) StartPosition = (2, 2);
        public int NextWidth { get; set; } = 20;
        public int NextHeight { get; set; } = 30;
        public WallGenerationAlgorithm Algorithm { get; set; }
        public Simulation()
        {

        }

        public void GenerateNextGrid()
        {

        }
        public void NotifyPropertyChanged(string propertyName)
        {

        }
    }
}
