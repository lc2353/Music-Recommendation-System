using GetPlaylistInfo.MVVM.ViewModel;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace GetPlaylistInfo.MVVM.View.Recommendations
{
    /// <summary>
    /// Interaction logic for ShowRecommendations.xaml
    /// </summary>
    public partial class ShowRecommendations : Page
    {
        public ShowRecommendations()
        {
            InitializeComponent();
            if (GetPlaylistSongInfo.Total > 100 | GetPlaylistSongInfo.Total == 0)
            {
                //Go back to dashboard and get rid of this page/window but the logic isn't logicing
            }

        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)

        {
            var song = List1.SelectedItem;
            string name = ((GetPlaylistInfo.MVVM.Model.RecoTrack)song).Name;
            string artist = ((GetPlaylistInfo.MVVM.Model.RecoTrack)song).Artists[0].Name;
            string songToDelete = ((GetPlaylistInfo.MVVM.Model.RecoTrack)song).Id;


            MessageBoxResult result = MessageBox.Show("Delete '" + name + "' by " + artist + "?", "Delete Recommendation?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ModifyRecommendations.DeleteTrack(songToDelete);
                ICollectionView view = CollectionViewSource.GetDefaultView(ModifyRecommendations.UserRecommendations);
                view.Refresh();
            }

        }

        private void BtnSaveRecos_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Save to acoount?", "Save Recommendations", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _ = new FormatRecoData();
                    FormatRecoData.FormatData();
                    string[] uniqueIds = GetSongsIds();
                    FormatRecoData.InsertSongs(FormatRecoData.ToPlaylist);

                    int uniquePlaylistId = FormatRecoData.CreateUnqiuePlaylist();
                    FormatRecoData.AddPlaylistSongs(uniqueIds, uniquePlaylistId);

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Help: ", ex);
                }

            }

        }

        static string[] GetSongsIds()
        {
            string[] songsIds = new string[FormatRecoData.ToPlaylist.Count];
            int count = 0;
            foreach (var song in FormatRecoData.ToPlaylist)
            {
                songsIds[count] += song.SongsId;
                count++;
            }
            return songsIds;
        }
    }
}
