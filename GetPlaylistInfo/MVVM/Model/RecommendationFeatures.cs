namespace GetPlaylistInfo.MVVM.Model
{
    public partial class RecommendationFeatures
    {
        public string Seed_tracks { get; set; }
        public int Limit { get; set; }

        public double Target_acousticness { get; set; }
        public double Target_danceability { get; set; }
        public int Target_duration_ms { get; set; }
        public double Target_energy { get; set; }
        public double Target_instrumentalness { get; set; }
        public int Target_key { get; set; }
        public double Target_liveness { get; set; }
        public double Target_loudness { get; set; }
        public int Target_popularity { get; set; }
        public int Target_tempo { get; set; }
        public int Target_time_signature { get; set; }
        public double Target_valence { get; set; }
    }
}
