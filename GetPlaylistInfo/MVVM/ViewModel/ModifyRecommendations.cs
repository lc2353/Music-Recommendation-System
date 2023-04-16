using GetPlaylistInfo.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GetPlaylistInfo.MVVM.ViewModel
{
    public class ModifyRecommendations
    {
        public static Collection<RecoTrack> OriginalRecommendations { get; set; }
        public static Collection<RecoTrack> UserRecommendations { get; set; }
        public static int Val { get; set; }

        public ModifyRecommendations()
        {

            UserRecommendations = new Collection<RecoTrack>();

            _ = new GetPlaylistSongInfo();
            if (GetPlaylistSongInfo.Total < 100)
            {
                if (GetPlaylistSongInfo.Total != 0)
                {
                    Initialize();
                }
            }
            else

            {
                //somehow go back to the playlist link

            }

        }

        static void Initialize()
        {
            GetSpotifyRecommendations GetRecos = new();
            OriginalRecommendations = GetRecos.GetTheSpotifyRecommendations();

            for (int i = 0; i < 15; i++)
            {
                UserRecommendations.Add(OriginalRecommendations[i]);
            }
            Val = 15;
        }

        public static void DeleteTrack(string songId)
        {
            var dupes = UserRecommendations.ToList().Where(x => x.Id == songId).ToList();

            if(Val < OriginalRecommendations.Count)
            {
                foreach (var item in dupes)
                {
                    UserRecommendations.Remove(item);
                }
                UpdateList();

            }
            else
            {
                MessageBox.Show("Sorry, you have run out of recommendations! Please restart the process to get new recommendations.","No more",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        static void UpdateList()
        {
            UserRecommendations.Add(OriginalRecommendations[Val]);
            Val++;

        }


    }
}
