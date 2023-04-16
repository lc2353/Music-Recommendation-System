using System.Windows;

namespace GetPlaylistInfo.MVVM.View.Recommendations
{
    /// <summary>
    /// Interaction logic for GetNewRecos.xaml
    /// </summary>
    public partial class GetNewRecos : Window
    {
        public GetNewRecos()
        {
            InitializeComponent();
            GetPlaylistLink p1 = new();
            Main.NavigationService.Navigate(p1);

        }


        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure? This will lose any recommendations already made.", "Return to Dashboard", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Dashboard dashboard = new();
                dashboard.Show();
                this.Close();
            }
        }
    }
}
