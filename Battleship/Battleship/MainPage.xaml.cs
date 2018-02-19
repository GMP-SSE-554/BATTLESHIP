using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            PerformAdditionalViewInitialization();
            SetupBoard();
        }

        /// <summary>
        /// Perform additional view initializations. Would prefer to override 'InitializeComponent(),'
        /// but it isn't known how to do that as of yet.
        /// </summary>
        public void PerformAdditionalViewInitialization()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size
            {
                Width = 500,
                Height = 500
            });
        }

        /// <summary>
        /// Sets up the battleship board with tiles and other information.
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
                    rect.StrokeThickness = 1;
                    rect.Stroke = new SolidColorBrush(Colors.SlateGray);
                    rect.Fill = new SolidColorBrush(Colors.FloralWhite);
                    Board.Children.Add(rect);
                }
            }
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SpView.IsPaneOpen = !SpView.IsPaneOpen;
        }

        private void SideMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
