using GetPlaylistInfo.MVVM.Model;
using System;
using System.Data.SqlClient;

namespace GetPlaylistInfo.MVVM.ViewModel
{
    public class GetIdealValues
    {
        public readonly RecommendationFeatures RecommendationFeature = new();

        public static bool[] Values { get; set; }

        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

        public static void CheckValues()
        {
            Values = new bool[7];
            string[] Factors = { "acousticness", "danceability", "energy", "instrumentalness", "liveness", "loudness", "valence" };

            string query = "SELECT state FROM Factors WHERE factor = @fvalue";

            conn.Open();

            for (int i = 0; i < Values.Length; i++) //because table indexing starts at one
            {

                using SqlCommand getValues = new(query, conn);
                getValues.Parameters.AddWithValue("@fvalue", Factors[i]);
                using SqlDataReader reader = getValues.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Values[i] = Convert.ToBoolean(reader[0]);
                    }
                }
            }
            conn.Close();
        }

        public void GetValues()
        {
            CalculateKey();
            CalculateDurationMs();
            CalculatePopularity();
            CalculateTempo();
            CalculateTimeSignature();

            if (Values[0]) CalculateAcousticness();
            if (Values[1]) CalculateDanceability();
            if (Values[2]) CalculateEnergy();
            if (Values[3]) CalculateInstrumentalness();
            if (Values[4]) CalculateLiveness();
            if (Values[5]) CalculateLoudness();
            if (Values[6]) CalculateValence();
        }


        void CalculateAcousticness()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Acousticness;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_acousticness = average;
        }
        void CalculateDanceability()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Danceability;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_danceability = average;
        }
        void CalculateDurationMs()
        {
            int totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += Convert.ToInt32(track.DurationMs);
                index++;
            }
            int average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_duration_ms = average;
        }
        void CalculateEnergy()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Energy;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_energy = average;
        }
        void CalculateInstrumentalness()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Instrumentalness;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_instrumentalness = average;
        }
        void CalculateKey()
        {
            int totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += Convert.ToInt32(track.Key);
                index++;
            }
            int average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_key = average;
        }
        void CalculateLiveness()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Liveness;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_liveness = average;
        }
        void CalculateLoudness()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Loudness;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_loudness = average;
        }
        void CalculatePopularity()
        {
            int totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += Convert.ToInt32(track.Popularity);
                index++;
            }
            int average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_popularity = average;
        }
        void CalculateTempo()
        {
            int totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += Convert.ToInt32(track.Tempo);
                index++;
            }
            int average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_tempo = average;
        }
        void CalculateTimeSignature()
        {
            int totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += Convert.ToInt32(track.TimeSignature);
                index++;
            }
            int average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_time_signature = average;
        }
        void CalculateValence()
        {
            double totalVal = 0;
            int index = 0;
            foreach (var track in GetPlaylistSongInfo.SongInformation)
            {
                totalVal += track.Valence;
                index++;
            }
            double average = totalVal / GetPlaylistSongInfo.Total;
            RecommendationFeature.Target_valence = average;
        }
    }

}
