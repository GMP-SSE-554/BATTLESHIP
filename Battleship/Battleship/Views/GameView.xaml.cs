using Windows.UI.Xaml.Controls;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameView"/> class.
        /// This contains the main Battleship game.
        /// </summary>
        public GameView()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
            CurrentBoardView.Navigate(typeof(BoardView));
            CurrentScoreboardView.Navigate(typeof(ScoreboardView));
        }
    }
}
