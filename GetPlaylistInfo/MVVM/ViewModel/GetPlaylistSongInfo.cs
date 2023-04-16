using GetPlaylistInfo.MVVM.Model;
using GetPlaylistInfo.MVVM.View.Recommendations;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace GetPlaylistInfo.MVVM.ViewModel
{
    public class GetPlaylistSongInfo
    {
        //https://developer.spotify.com/console/get-playlist-tracks/ //get the access tokens

        public ObservableCollection<Item> Songs { get; set; }
        public ObservableCollection<AudioFeature> SongAudio { get; set; }
        public static ObservableCollection<TrackInfo> SongInformation { get; set; } // the info used to make recommendatioms 

        public static ArrayList TrackIds { get; set; }
        public static int Total { get; set; }

        public GetPlaylistSongInfo()
        {
            #region accesstokens
            string accessToken = Authorize.tokenn;
            #endregion

            Songs = new ObservableCollection<Item>();
            SongAudio = new ObservableCollection<AudioFeature>();
            SongInformation = new ObservableCollection<TrackInfo>();
            TrackIds = new ArrayList();


            GetPlaylistInformation(accessToken, GetPlaylistLink.PlaylistUrl);

        }

        void GetPlaylistInformation(string accessToken, string playlistId)
        {
            var client = new RestClient
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer")
            };


            string requestLink = "https://api.spotify.com/v1/playlists/" + playlistId + "/tracks";
            var request = new RestRequest(requestLink, Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            bool success = true;

            var check = client.GetAsync(request).GetAwaiter().GetResult();
            if (Convert.ToInt16(check.StatusCode) != 200)
            {
                MessageBox.Show("An error occurred please try again.");
                success = false;
                //GO BACK TO GET PLAYLIST LINKS BUT HOW
            }

            if (success)
            {


                var response = client.GetAsync(request).GetAwaiter().GetResult();
                var data = JsonConvert.DeserializeObject<PlaylistModel>(response.Content!);
                Total = Convert.ToInt16(data.Total);

                if (Total > 100)
                {
                    MessageBox.Show("Playlist can not be longer than 100 songs, please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //GO BACK TO PLAYLIST IDS
                }
                else
                {

                    for (int i = 0; i < Total; i++)
                    {
                        var song = data.Items[i];
                        Songs.Add(song);
                        TrackIds.Add(song.Track.Id);

                    }
                    GetAudioFeaures(accessToken);
                    CombineData();
                }
                
            }
        }



        void GetAudioFeaures(string accessToken)
        {
            var client = new RestClient("https://api.spotify.com/v1/audio-features")
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer")
            };

            string[] Id = (string[])TrackIds.ToArray(typeof(string));
            string Ids = String.Join(",", Id);

            var request = new RestRequest($"?ids={Ids}", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var audio = JsonConvert.DeserializeObject<AudioFeatures>(response.Content!);



            for (int i = 0; i < Total; i++)
            {
                var song = audio.Features[i];
                SongAudio.Add(song);
            }
        }

        void CombineData()
        {
            var infoSongs = CreateSongIndex(Total);
            int index = 0;
            foreach (var trackinfo in infoSongs)
            {
                var data = Songs[index];
                var audioData = SongAudio[index];
                trackinfo.TrackId = data.Track.Id;
                trackinfo.SongName = data.Track.Name;
                trackinfo.ArtistName = data.Track.Artists[0].Name;
                trackinfo.AlbumName = data.Track.Album.Name;
                trackinfo.DurationMs = data.Track.DurationMs;
                trackinfo.Popularity = data.Track.Popularity;
                trackinfo.DurationMs = data.Track.DurationMs;

                trackinfo.Acousticness = audioData.Acousticness;
                trackinfo.Danceability = audioData.Danceability;
                trackinfo.Energy = audioData.Energy;
                trackinfo.Instrumentalness = audioData.Instrumentalness;
                trackinfo.Key = audioData.Key;
                trackinfo.Liveness = audioData.Liveness;
                trackinfo.Loudness = audioData.Loudness;
                trackinfo.Mode = audioData.Mode;
                trackinfo.Speechiness = audioData.Speechiness;
                trackinfo.Tempo = audioData.Tempo;
                trackinfo.TimeSignature = audioData.TimeSignature;
                trackinfo.Valence = audioData.Valence;


                SongInformation.Add(trackinfo);
                index++;

            }
        }

        public static IEnumerable<TrackInfo> CreateSongIndex(long count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new TrackInfo { Index = i };
            }
        }

    }
}
