using GetPlaylistInfo.MVVM.View.PreviousRecos;
using GetPlaylistInfo.MVVM.View.Recommendations;
using GetPlaylistInfo.MVVM.ViewModel;
using System;
using System.Windows;

namespace GetPlaylistInfo.MVVM.View
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            txtBlockWelcome.Text = ("Hello " + Login.Username).ToUpper();
        }

        private void BtnNewRecos_Click(object sender, RoutedEventArgs e)
        {
            GetNewRecos newRecos = new();
            newRecos.Show();
            this.Close();
        }

        private void BtnOldRecos_Click(object sender, RoutedEventArgs e)
        {
            bool present = false;
           try
            {
               present = FetchFromTable.CheckRecos();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (present)
            {
                PreviousRecommendations previous = new();
                previous.Show();
                
                this.Close();
            }
            else
            {
                MessageBox.Show("You have no recommendations saved! Please create a new set of recommendations.", "No Recommendations", MessageBoxButton.OK, MessageBoxImage.Error);
            }

          
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            UserSettings userSettings = new();
            userSettings.Show();
            this.Close();
        }
    }
}
