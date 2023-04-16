using GetPlaylistInfo.MVVM.View.UserSetting;
using GetPlaylistInfo.MVVM.ViewModel;
using System;
using System.Data.SqlClient;
using System.Windows;


namespace GetPlaylistInfo.MVVM.View
{

    public partial class UserSettings : Window
    {
        public static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

        public UserSettings()
        {
            InitializeComponent();

        }

        private void BtnDelAcc_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete your account? This will delete all your account data as well.", "DELETE ACCOUNT", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes) DeleteAccount();


        }

        private void BtnChangePass_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new ChangePassword();
            Main.Visibility = Visibility.Visible;
            BtnHide.Visibility = Visibility.Visible;
        }

        private void BtnForgotPass_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Only the admin can change your password.", "Can't change password", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }

        private void BtnChangeFactors_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand checkAdmin = new("SELECT admin FROM users WHERE username=@username", conn);
            checkAdmin.Parameters.AddWithValue("@username", Login.Username);
            bool admin = (bool)checkAdmin.ExecuteScalar();
            conn.Close();

            if (!admin)
            {
                MessageBox.Show("You are not authorised to do this, contact your administrator", "Not authorised!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Main.Content = new ChangeFactors();
                Main.Visibility = Visibility.Visible;
                BtnHide.Visibility = Visibility.Visible;

            }
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            BtnHide.Visibility = Visibility.Hidden;
            Main.Visibility = Visibility.Hidden;
        }

        void DeleteAccount()
        {
            bool success = false;

            try
            {
                FetchFromTable.GetPlaylistsFromTable();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //delete playlistsongs
            string query1 = "DELETE FROM playlistsongs WHERE playlistsid= @playlistID";
            try
            {
                foreach (var playlist in FetchFromTable.Playlists)
                {
                    conn.Open();

                    SqlCommand deleteSongs = new(query1, conn);
                    deleteSongs.Parameters.AddWithValue("@playlistID", playlist.PlaylistId);
                    deleteSongs.ExecuteNonQuery();
                    deleteSongs.Parameters.Clear();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                success = false;
            }

            //delete playlists belogning to user
            string query2 = "DELETE FROM playlists WHERE usersID= @usersid";
            try
            {
                foreach (var playlist in FetchFromTable.Playlists)
                {
                    conn.Open();

                    SqlCommand deleteSongs = new(query2, conn);
                    deleteSongs.Parameters.AddWithValue("@usersid", Login.UserId);
                    deleteSongs.ExecuteNonQuery();
                    deleteSongs.Parameters.Clear();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                success = false;
            }

            //delete user id
            try
            {
                conn.Open();
                SqlCommand delete = new("DELETE FROM users WHERE username=@username", conn);
                delete.Parameters.AddWithValue("@username", Login.Username);
                //delete everything else
                delete.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            if (success)
            {
                MessageBox.Show("Account successfully deleted.", "Account deletion successful", MessageBoxButton.OK, MessageBoxImage.None);
                Register register = new();
                register.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
    }
}
