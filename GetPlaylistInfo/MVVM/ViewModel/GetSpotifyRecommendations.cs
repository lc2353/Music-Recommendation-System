using GetPlaylistInfo.MVVM.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetPlaylistInfo.MVVM.ViewModel
{
    public class GetSpotifyRecommendations
    {
        RecommendationFeatures Features = new();
        public ObservableCollection<RecoTrack> SpotifyRecommendations { get; set; }
        public Collection<RecoTrack> Recommendations { get; set; }

        public Collection<RecoTrack> GetTheSpotifyRecommendations()
        {
            #region accesstoken
            string token = Authorize.tokenn;
            #endregion

            SpotifyRecommendations = new ObservableCollection<RecoTrack>();



            GetIdealValues getIdeal = new();
            GetIdealValues.CheckValues();
            getIdeal.GetValues();
            Features = getIdeal.RecommendationFeature;

            Features.Limit = 10;

            string[] seedTracks = SplitIds();
            foreach (var seeds in seedTracks)
            {
                FetchRecos(token, seeds);

            }
            FormatRecos();
            return Recommendations;
        }

        static string[] SplitIds()
        {
            string[] ids = (string[])GetPlaylistSongInfo.TrackIds.ToArray(typeof(string));
            bool full = true;
            int remainder = 0;
            int groups = ids.Length / 5;
            if (ids.Length % 5 != 0)
            {
                groups++;
                remainder = ids.Length % 5;
                full = false;
            }


            Random rnd = new();
            string[] randomIds = ids.OrderBy(x => rnd.Next()).ToArray();

            string[] seedTracks = new string[groups];
            int inc = 0;
            for (int i = 0; i < groups - 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    seedTracks[i] += randomIds[j + inc];
                    if (j != 4) seedTracks[i] += ',';
                }
                inc += 5;
            }
            if (full)
            {
                for (int j = 0; j < 5; j++)
                {
                    seedTracks[groups - 1] += randomIds[j + inc];
                    if (j != 4) seedTracks[groups - 1] += ',';
                }
            }
            else
            {
                for (int j = 0; j < remainder; j++)
                {
                    seedTracks[groups - 1] += randomIds[j + inc];
                    if (j != remainder - 1) seedTracks[groups - 1] += ',';
                }
            }

            return seedTracks;
        }

        void FetchRecos(string accessToken, string seeds)
        {
            Features.Seed_tracks = seeds;


            var client = new RestClient
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer")
            };

            string requestLink = "https://api.spotify.com/v1/recommendations";
            var request = new RestRequest(requestLink, Method.Get);
            request.AddQueryParameter("seed_tracks", Features.Seed_tracks);
            request.AddQueryParameter("limit", Features.Limit);

            if (GetIdealValues.Values[0]) request.AddQueryParameter("target_acousticness", Features.Target_acousticness);
            if (GetIdealValues.Values[1]) request.AddQueryParameter("target_danceability", Features.Target_danceability);
            request.AddQueryParameter("target_duration_ms", Features.Target_duration_ms);
            if (GetIdealValues.Values[2]) request.AddQueryParameter("target_energy", Features.Target_energy);
            if (GetIdealValues.Values[3]) request.AddQueryParameter("target_instrumentalness", Features.Target_instrumentalness);
            request.AddQueryParameter("target_key", Features.Target_key);
            if (GetIdealValues.Values[4]) request.AddQueryParameter("target_liveness", Features.Target_liveness);
            if (GetIdealValues.Values[5]) request.AddQueryParameter("target_loudness", Features.Target_loudness);
            request.AddQueryParameter("target_popularity", Features.Target_popularity);
            request.AddQueryParameter("target_tempo", Features.Target_tempo);
            request.AddQueryParameter("target_time_signature", Features.Target_time_signature);
            if (GetIdealValues.Values[6]) request.AddQueryParameter("target_valence", Features.Target_valence);


            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var data = JsonConvert.DeserializeObject<GetRecommendations>(response.Content!);

            for (int i = 0; i < Features.Limit; i++)
            {
                var song = data.Tracks[i];
                SpotifyRecommendations.Add(song);
            }

        }

        void FormatRecos()
        {
            string[] ids = (string[])GetPlaylistSongInfo.TrackIds.ToArray(typeof(string));

            Recommendations = new Collection<RecoTrack>(SpotifyRecommendations
           .DistinctBy(x => x.Id)
           .ToList());

            for (int i = 0; i < GetPlaylistSongInfo.Total; i++)
            {
                string playlistId = ids[i];
                FindDupes(playlistId);
            }
        }

        void FindDupes(string playlistId)
        {
            var dupes = Recommendations.ToList().Where(x => x.Id == playlistId).ToList();

            foreach (var item in dupes)
            {
                Recommendations.Remove(item);
            }
        }

    }
}
