using System.Windows;
using System.Windows.Controls;

namespace GetPlaylistInfo.MVVM.View.Recommendations
{
    public partial class GetPlaylistLink : Page
    {
        public static string PlaylistUrl { get; set; }
        public GetPlaylistLink()
        {
            InitializeComponent();
        }

        private void BtnGetRecos_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlaylistLink.Text == "")
            {
                MessageBox.Show("Please enter a playlist url", "Enter a URL", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                PlaylistUrl = txtPlaylistLink.Text;

                ShowRecommendations p2 = new();
                this.NavigationService.Navigate(p2);

            }

            // gonna have to catch to see if the playlist url gives info if not then say it either doesnt work or something went wrong try again

        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            PlaylistHelp.Visibility = Visibility.Hidden;
        }

        private void BtnUrlHelp_Click(object sender, RoutedEventArgs e)
        {
            PlaylistHelp.Visibility = Visibility.Visible;

        }


    }
}
