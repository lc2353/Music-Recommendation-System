using GetPlaylistInfo.MVVM.View.PreviousRecos;
using GetPlaylistInfo.MVVM.ViewModel;
using System.Windows;

namespace GetPlaylistInfo.MVVM.View
{
    /// <summary>
    /// Interaction logic for PreviousRecommendations.xaml
    /// </summary>
    public partial class PreviousRecommendations : Window
    {
        public PreviousRecommendations()
        {
            InitializeComponent();
            ShowPlaylists p1 = new();
            PreviousRecos.NavigationService.Navigate(p1);

        }     

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            
                Dashboard dashboard = new();
                dashboard.Show();
                this.Hide();
            
        }
    }
}
