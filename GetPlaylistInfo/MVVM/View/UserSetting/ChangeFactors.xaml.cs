using GetPlaylistInfo.MVVM.ViewModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GetPlaylistInfo.MVVM.View.UserSetting
{
    // 1 - Acousticness
    // 2 - Danceability
    // 3 - Energy
    // 4 - Instrumentalness
    // 5 - Liveness
    // 6 - Loudness
    // 7 - Valence

    public partial class ChangeFactors : Page
    {
        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

        public ChangeFactors()
        {

            InitializeComponent();
            GetCurrentValues();

        }

        void GetCurrentValues()
        {
            GetIdealValues.CheckValues();
            if (GetIdealValues.Values[0]) BtnAcousticness.IsChecked = true;
            if (GetIdealValues.Values[1]) BtnDanceability.IsChecked = true;
            if (GetIdealValues.Values[2]) BtnEnergy.IsChecked = true;
            if (GetIdealValues.Values[3]) BtnInstrumentalness.IsChecked = true;
            if (GetIdealValues.Values[4]) BtnLiveness.IsChecked = true;
            if (GetIdealValues.Values[5]) BtnLoudness.IsChecked = true;
            if (GetIdealValues.Values[6]) BtnValence.IsChecked = true;

            UserSettings.conn.Close();
        }
        private void BtnConfirmChanges_Click(object sender, RoutedEventArgs e)
        {

            if (BtnAcousticness.IsChecked != GetIdealValues.Values[0])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnAcousticness.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "acousticness");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnDanceability.IsChecked != GetIdealValues.Values[1])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnDanceability.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "danceability");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnEnergy.IsChecked != GetIdealValues.Values[2])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnEnergy.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "energy");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnInstrumentalness.IsChecked != GetIdealValues.Values[3])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnInstrumentalness.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "instrumentalness");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnLiveness.IsChecked != GetIdealValues.Values[4])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnLiveness.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "liveness");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnLoudness.IsChecked != GetIdealValues.Values[5])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnLoudness.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "loudness");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            if (BtnValence.IsChecked != GetIdealValues.Values[6])
            {
                conn.Open();
                SqlCommand updateState = new("UPDATE Factors SET state = @state WHERE factor = @factor", conn);
                updateState.Parameters.AddWithValue("@state", BtnValence.IsChecked);
                updateState.Parameters.AddWithValue("@factor", "valence");
                updateState.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("The recommendation factors have successfully been updated.", "Updated Factors", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
