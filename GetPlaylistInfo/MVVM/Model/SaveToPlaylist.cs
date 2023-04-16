namespace GetPlaylistInfo.MVVM.Model
{
    public class SaveToPlaylist
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Album_Release_Date { get; set; }
        public long DurationMs { get; set; }
        public string SongsId { get; set; }
        public int Popularity { get; set; }
    }
}
