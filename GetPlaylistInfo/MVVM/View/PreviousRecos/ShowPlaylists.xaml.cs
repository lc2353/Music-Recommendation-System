using GetPlaylistInfo.MVVM.Model;
using GetPlaylistInfo.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetPlaylistInfo.MVVM.View.PreviousRecos
{
    public partial class ShowPlaylists : Page
    {
        public bool Success { get; set; }

        public ShowPlaylists()
        {
            Success = false;
            try
            {
                FetchFromTable.GetPlaylistsFromTable();
                Success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
           
           
        }

        private void ListPlaylists_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Success)
            {
                var playlist = ListPlaylists.SelectedItem;
                int id = ((GetPlaylistInfo.MVVM.Model.TblPlaylists)playlist).PlaylistId;
                try
                {

                    bool success1 = FetchFromTable.GetSongsFromPlaylist(id);
                    if (success1)
                    {
                        try
                        {
                            FetchFromTable.GetSongsInfo(FetchFromTable.SongsIds);
                            ShowSongs p2 = new();
                            this.NavigationService.Navigate(p2);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else MessageBox.Show("ERROR");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
