// Updated by XamlIntelliSenseFileGenerator 21/03/2023 10:06:54
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3713A02CF014EA079F37DDD984A3CDFF7C9F934D0F8DC5745906FE22CEB05906"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MafeuhLabyWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MafeuhLabyWPF
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputWidth;

#line default
#line hidden


#line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputHeight;

#line default
#line hidden


#line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateNewGrid;

#line default
#line hidden


#line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errorCreation;

#line default
#line hidden


#line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showGrid;

#line default
#line hidden


#line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox algoList;

#line default
#line hidden


#line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateWalls;

#line default
#line hidden


#line 34 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartSolv;

#line default
#line hidden


#line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPauseSolv;

#line default
#line hidden


#line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStopSolv;

#line default
#line hidden


#line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox GridGroupBox;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MafeuhLabyWPF;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.inputWidth = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.inputHeight = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.generateNewGrid = ((System.Windows.Controls.Button)(target));

#line 22 "..\..\MainWindow.xaml"
                    this.generateNewGrid.Click += new System.Windows.RoutedEventHandler(this.generateNewGrid_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.errorCreation = ((System.Windows.Controls.Label)(target));
                    return;
                case 5:
                    this.showGrid = ((System.Windows.Controls.CheckBox)(target));

#line 26 "..\..\MainWindow.xaml"
                    this.showGrid.Checked += new System.Windows.RoutedEventHandler(this.showGrid_Checked);

#line default
#line hidden

#line 26 "..\..\MainWindow.xaml"
                    this.showGrid.Unchecked += new System.Windows.RoutedEventHandler(this.showGrid_Unchecked);

#line default
#line hidden
                    return;
                case 6:
                    this.algoList = ((System.Windows.Controls.ListBox)(target));

#line 30 "..\..\MainWindow.xaml"
                    this.algoList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.algoList_SelectionChanged);

#line default
#line hidden
                    return;
                case 7:
                    this.btnCreateWalls = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\MainWindow.xaml"
                    this.btnCreateWalls.Click += new System.Windows.RoutedEventHandler(this.btnCreateWalls_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btnStartSolv = ((System.Windows.Controls.Button)(target));

#line 34 "..\..\MainWindow.xaml"
                    this.btnStartSolv.Click += new System.Windows.RoutedEventHandler(this.btnStartSolv_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.btnPauseSolv = ((System.Windows.Controls.Button)(target));
                    return;
                case 10:
                    this.btnStopSolv = ((System.Windows.Controls.Button)(target));

#line 36 "..\..\MainWindow.xaml"
                    this.btnStopSolv.Click += new System.Windows.RoutedEventHandler(this.btnStopSolv_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.GridGroupBox = ((System.Windows.Controls.GroupBox)(target));
                    return;
                case 12:
                    this.SimulationGrid = ((System.Windows.Controls.Grid)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Grid SimulationGrid;
    }
}

