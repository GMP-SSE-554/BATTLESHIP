using Battleship.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HelpView : Page
    {
        InstructionViewModel ViewModel { get; } = new InstructionViewModel((App.Current as App).HelpService);

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpView"/> class.
        /// This contains instructions on how to play.
        /// </summary>
        public HelpView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
