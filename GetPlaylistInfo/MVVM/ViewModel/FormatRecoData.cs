using GetPlaylistInfo.MVVM.Model;
using GetPlaylistInfo.MVVM.View;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;

namespace GetPlaylistInfo.MVVM.ViewModel
{

    public class FormatRecoData
    {
        public static SaveToPlaylist FormattedTrack { get; set; }
        public static Collection<SaveToPlaylist> ToPlaylist { get; set; }
        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");


        public static void FormatData()
        {

            ToPlaylist = new Collection<SaveToPlaylist>();
            Collection<RecoTrack> ToSave = ModifyRecommendations.UserRecommendations;
            for (int i = 0; i < ToSave.Count; i++)
            {
                FormattedTrack = new();

                FormattedTrack.Index = i;
                FormattedTrack.Name = ToSave[i].Name;
                FormattedTrack.Artist = ToSave[i].Artists[0].Name;
                FormattedTrack.Album = ToSave[i].Album.Name;
                FormattedTrack.Album_Release_Date = ToSave[i].Album.ReleaseDate;
                FormattedTrack.SongsId = ToSave[i].Id;
                FormattedTrack.DurationMs = ToSave[i].DurationMs;
                FormattedTrack.Popularity = Convert.ToInt32(ToSave[i].Popularity);
                ToPlaylist.Add(FormattedTrack);


            }
        }

        public static void InsertSongs(Collection<SaveToPlaylist> songList)
        {
            string query = "INSERT INTO songs (name, artist, album, album_release_date, songsid, duration_ms, popularity) VALUES (@name, @artist, @album, @album_release_date, @songsid, @duration_ms, @popularity)";

            try
            {

                foreach (var song in songList)
                {
                    bool present = CheckPresence(song.SongsId);
                    if (!present)
                    {
                        conn.Open();
                        using SqlCommand addSong = new(query, conn);
                        addSong.Parameters.AddWithValue("@name", song.Name);
                        addSong.Parameters.AddWithValue("@artist", song.Artist);
                        addSong.Parameters.AddWithValue("@album", song.Album);
                        addSong.Parameters.AddWithValue("@album_release_date", song.Album_Release_Date);
                        addSong.Parameters.AddWithValue("@songsid", song.SongsId);
                        addSong.Parameters.AddWithValue("@duration_ms", song.DurationMs);
                        addSong.Parameters.AddWithValue("@popularity", song.Popularity);


                        addSong.ExecuteNonQuery();
                        addSong.Parameters.Clear();
                        conn.Close();
                    }
                }
                MessageBox.Show("Successfully saved to account.", "Saved.", MessageBoxButton.OK, MessageBoxImage.None);

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                conn.Close();
            }


        }

        static bool CheckPresence(string id)
        {
            conn.Open();
            SqlCommand check = new("SELECT * FROM songs where songsid=@id", conn);
            check.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = check.ExecuteReader();

            if (reader.Read() == true)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public static int CreateUnqiuePlaylist()
        {
            string query1 = "INSERT INTO playlists (date_created, usersid) VALUES (@date_created, @usersId)";
            string query2 = "SELECT MAX(playlistsid) FROM playlists";

            int uniquePlaylistId = 0;
         

            try
            {
                conn.Open();
                using SqlCommand newPlaylist = new(query1, conn);
                newPlaylist.Parameters.AddWithValue("@date_created", DateTime.Now.ToShortDateString());
                newPlaylist.Parameters.AddWithValue("@usersId", Login.UserId);
                newPlaylist.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            try
            {
                conn.Open();
                using SqlCommand getPlaylistId = new(query2, conn);
                uniquePlaylistId = Convert.ToInt32(getPlaylistId.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            return uniquePlaylistId;
        }

        public static void AddPlaylistSongs(string[] uniqueIds, int uniquePlaylistId)
        {
            string query = "INSERT INTO playlistsongs (playlistsid, songsid) VALUES (@playlistsId, @songsId)";
            try
            {
                for (int i = 0; i < uniqueIds.Length; i++)
                {
                    conn.Open();
                    using SqlCommand insert = new(query, conn);
                    insert.Parameters.AddWithValue("@playlistsId", uniquePlaylistId);
                    insert.Parameters.AddWithValue("@songsId", uniqueIds[i]);

                    insert.ExecuteNonQuery();
                    insert.Parameters.Clear();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

    }
}
