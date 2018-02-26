using Battleship.Constants;
using Battleship.ViewModels;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BoardView : Page
    {
        BoardViewModel ViewModel { get; } = new BoardViewModel((App.Current as App).BoardService);

        /// <summary>
        /// Initializes a new instance of the <see cref="GameView"/> class.
        /// This contains the main Battleship game.
        /// </summary>
        public BoardView()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
            DataContext = ViewModel;
            SetupBoard();
        }

        /// <summary>
        /// Sets up the battleship board with tiles and performs addtional bindings.
        /// </summary>
        void SetupBoard()
        {
            for (var i = 0; i < NumericalConstants.BOARD_ROWS; i++)
            {
                for (var j = 0; j < NumericalConstants.BOARD_COLUMNS; j++)
                {
                    // Creating tile container for command functionality.
                    var tile = new Button();
                    tile.SetValue(Grid.RowProperty, i);
                    tile.SetValue(Grid.ColumnProperty, j);
                    tile.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tile.VerticalAlignment = VerticalAlignment.Stretch;
                    tile.BorderThickness = new Thickness { Left = 1, Top = 1, Right = 1, Bottom = 1 };

                    // Binding tile properties.
                    var tileSource = ViewModel.HumanTiles.Where(e => e.Row.Equals(i) && e.Column.Equals(j)).First();
                    tile.SetBinding(Button.DataContextProperty, new Binding { Source = tileSource });
                    tile.SetBinding(Button.BackgroundProperty, new Binding { Path = new PropertyPath(nameof(tileSource.FillColor)) });
                    tile.SetBinding(Button.BorderBrushProperty, new Binding { Path = new PropertyPath(nameof(tileSource.BorderColor)) });
                    tile.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath(nameof(tileSource.OnClick)) });
                    // Adding tile to parent view.
                    Board.Children.Add(tile);
                }
            }
        }
    }
}
