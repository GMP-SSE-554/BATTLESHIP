using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameView : Page
    {
        /// <summary>
        /// Creates an instance of the GameView. This view contains the main battleship game.
        /// </summary>
        public GameView()
        {
            InitializeComponent();
            SetupBoard();
        }

        /// <summary>
        /// Sets up the battleship board with tiles and other information (TBD).
        /// </summary>
        public void SetupBoard()
        {
            var rows = Board.RowDefinitions;
            var cols = Board.ColumnDefinitions;
            for (var i = 0; i < rows.Count; i++)
            {
                for (var j = 0; j < cols.Count; j++)
                {
                    // TODO: create binding/add listener to each rect.
                    // Maybe give name.
                    var rect = new Rectangle();
                    rect.SetValue(Grid.RowProperty, i);
                    rect.SetValue(Grid.ColumnProperty, j);
                    rect.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
                    rect.SetValue(VerticalAlignmentProperty, VerticalAlignment.Stretch);
                    rect.Stroke = new SolidColorBrush(Colors.SlateGray);
                    rect.Fill = new SolidColorBrush(Colors.FloralWhite);
                    rect.StrokeThickness = 1;
                    Board.Children.Add(rect);
                }
            }
        }
    }
}
