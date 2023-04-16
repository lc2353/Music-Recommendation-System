using GetPlaylistInfo.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Interaction logic for ShowSongs.xaml
    /// </summary>
    public partial class ShowSongs : Page
    {
        public ShowSongs()
        {
            InitializeComponent();
        }

        private void BtnExportRecos_Click(object sender, RoutedEventArgs e)
        {
            string guidName = Guid.NewGuid().ToString();
            string extension = ".csv";
            string link = (@"C:\Users\lcrab\Downloads\NEA\" + guidName + extension);

            string toFile;
            try
            {
                using StreamWriter writeToFile = new(link);
                writeToFile.WriteLine("Name;Artist;Album;Album_Release_Date;Track Id;Duration_In_Ms;Popularity");
                foreach (var track in FetchFromTable.PlaylistSongs)
                {
                    toFile = $"{track.Name};{track.Artist};{track.Album};{track.Album_Release_Date};{track.SongsId};{track.DurationMs};{track.Popularity}";
                    writeToFile.WriteLine(toFile);
                }
                MessageBox.Show("Success!, Saved in file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("An error occured, please try again");
            }
           
        }
    }
}
