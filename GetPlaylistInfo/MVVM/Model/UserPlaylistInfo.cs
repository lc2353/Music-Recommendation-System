namespace GetPlaylistInfo.MVVM.Model
{
    public class TrackInfo
    {
        public int Index { get; set; }

        public string TrackId { get; set; }
        public string SongName { get; set; } //tracks.name
        public string AlbumName { get; set; } //tracks.albums.name
        public string ArtistName { get; set; } //tracks.artists.name
        public long DurationMs { get; set; } //tracks.duration_ms
        public int Popularity { get; set; } //tracks.popularity

        //from audio features
        public double Acousticness { get; set; }
        public double Danceability { get; set; }
        public double Energy { get; set; }
        public double Instrumentalness { get; set; }
        //(integers mapped to pitch class notation)
        public long Key { get; set; }
        public double Liveness { get; set; }
        //(in dB)
        public double Loudness { get; set; }
        //(major is 1 minor is 0)
        public long Mode { get; set; }
        public double Speechiness { get; set; }
        public double Tempo { get; set; }
        public long TimeSignature { get; set; }
        public double Valence { get; set; }
    }


}