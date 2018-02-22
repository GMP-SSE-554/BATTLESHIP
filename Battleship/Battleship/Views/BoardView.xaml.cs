using Battleship.ViewModels;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BoardView : Page
    {
        BoardViewModel ViewModel { get; } = new BoardViewModel((App.Current as App).BoardService);

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardView"/> class.
        /// This contains the board of the battlship game.
        /// </summary>
        public BoardView()
        {
            InitializeComponent();
            SetupBoard();
        }

        /// <summary>
        /// Sets up the battleship board with tiles and performs addtional bindings.
        /// </summary>
        void SetupBoard()
        {
            for (var i = 0; i < ViewModel.NumRows; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
                for (var j = 0; j < ViewModel.NumColumns; j++)
                {
                    if (i == 0) Board.ColumnDefinitions.Add(new ColumnDefinition());
                    var rect = new Rectangle { StrokeThickness = 1 };
                    rect.SetValue(Grid.RowProperty, i);
                    rect.SetValue(Grid.ColumnProperty, j);
                    rect.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
                    rect.SetValue(VerticalAlignmentProperty, VerticalAlignment.Stretch);

                    var tileSource = ViewModel.Tiles.Where(e => e.Row.Equals(i) && e.Column.Equals(j)).First();
                    Binding fillColorBinding = new Binding { Source = tileSource.FillColor };
                    Binding borderColorBinding = new Binding { Source = tileSource.BorderColor };
                    rect.SetBinding(Shape.FillProperty, fillColorBinding);
                    rect.SetBinding(Shape.StrokeProperty, borderColorBinding);
                    Board.Children.Add(rect);
                }
            }
        }
    }
}
