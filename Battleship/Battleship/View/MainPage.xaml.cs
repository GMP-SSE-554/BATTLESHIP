﻿using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Battleship
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ListBoxItem prevSelected;

        /// <summary>
        /// Creates an instance of the MainPage. This view contains the hamburger menu.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            PerformAdditionalViewInitialization();
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
            SetContent(Home);
        }

        /// <summary>
        /// Opens Hamburger Menu when the HamburgerButton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            LeftHandMenu.IsPaneOpen = !LeftHandMenu.IsPaneOpen;
        }

        /// <summary>
        /// Performs navigation when the menu's selected index is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftHandMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected && !prevSelected.Equals(Home))
            {
                SetContent(Home);
            }
            else if (Instructions.IsSelected && !prevSelected.Equals(Instructions))
            {
                SetContent(Instructions);
            }
        }

        /// <summary>
        /// Sets the split view content to the specified page.
        /// </summary>
        /// <param name="selectedItem"></param>
        private void SetContent(ListBoxItem selectedItem)
        {
            var view = selectedItem.Equals(Home) ? typeof(GameView) : typeof(HelpView);
            CurrentView.Navigate(view);
            PageLocation.Text = selectedItem.Name;
            prevSelected = selectedItem;
        }
    }
}