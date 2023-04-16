using GetPlaylistInfo.MVVM.Model;
using GetPlaylistInfo.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GetPlaylistInfo.MVVM.ViewModel
{
    public class FetchFromTable
    {
        public static Collection<SaveToPlaylist> PlaylistSongs { get; set; }
        public static Collection<TblPlaylists> Playlists { get; set; }
        public static SaveToPlaylist[] TablePlaylistSongs { get; set; }
        public static TblPlaylists[] TableData { get; set; }
        public static string[] SongsIds { get; set; }

        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

        public static bool CheckRecos()
        {
            bool present = false;
            try
            {

                conn.Open();
                SqlCommand getRecos = new("SELECT * FROM playlists WHERE usersid =@usersid ", conn);
                getRecos.Parameters.AddWithValue("@usersid", Login.UserId);
                SqlDataReader reader = getRecos.ExecuteReader();
                if (reader.Read() == true) present = true;
                conn.Close();
                return present;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return present;
            }

        }
        public static bool GetSongsFromPlaylist(int playlistid)
        {
            SongsIds = new string[15];

            string query = "SELECT songsid from playlistsongs WHERE playlistsid= @playlistID";
            try
            {
                int index = 0;
                conn.Open();
                SqlCommand getSongs = new(query, conn);
                getSongs.Parameters.AddWithValue("@playlistID", playlistid);
                using SqlDataReader reader = getSongs.ExecuteReader();

                while (reader.Read())
                {
                    SongsIds[index] = reader["songsid"].ToString()!;
                    index++;

                }
                reader.NextResult();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }

        }
        public static void GetPlaylistsFromTable()
        {

            int size = 0;

            string query1 = "SELECT COUNT(playlistsid) FROM playlists WHERE usersID =@usersid"; //COUNT THE PLAYLISTSIDS
            string query2 = "SELECT * FROM playlists WHERE usersID =@usersid";
            try
            {
                conn.Open();
                SqlCommand countPlaylist = new(query1, conn);
                countPlaylist.Parameters.AddWithValue("@usersid", Login.UserId);
                size = Convert.ToInt32(countPlaylist.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            TableData = new TblPlaylists[size];
            Playlists = new Collection<TblPlaylists>();

            try
            {
                conn.Open();
                int index = 0;
                SqlCommand getPlaylists = new(query2, conn);
                getPlaylists.Parameters.AddWithValue("@usersid", Login.UserId);
                using (SqlDataReader reader = getPlaylists.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TableData[index] = new();
                        TableData[index].PlaylistId = Convert.ToInt32(reader["playlistsid"]);
                        TableData[index].PlaylistName = "NEEDS TO CREATE";
                        TableData[index].Date_Created = Convert.ToDateTime(reader["date_created"]).ToShortDateString();
                        index++;

                    }
                    reader.NextResult();
                }
                conn.Close();

                foreach (var song in TableData)
                {
                    Playlists.Add(song);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();

            }
        }

        public static void GetSongsInfo(string[] SongsIds)
        {
            TablePlaylistSongs = new SaveToPlaylist[15];
            PlaylistSongs = new Collection<SaveToPlaylist>();

            string query = "SELECT * FROM songs WHERE songsid= @songsid";
            try
            {
                int count = 0;
                foreach (var songid in SongsIds)
                {
                    conn.Open();
                    SqlCommand getSongInfo = new(query, conn);
                    getSongInfo.Parameters.AddWithValue("@songsid", songid);
                    using (SqlDataReader reader = getSongInfo.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TablePlaylistSongs[count] = new();
                            TablePlaylistSongs[count].Index = count;
                            TablePlaylistSongs[count].Name = reader["name"].ToString()!;
                            TablePlaylistSongs[count].Artist = reader["artist"].ToString()!;
                            TablePlaylistSongs[count].Album = reader["album"].ToString()!;
                            TablePlaylistSongs[count].Album_Release_Date = Convert.ToDateTime(reader["album_release_date"]).ToShortDateString();
                            TablePlaylistSongs[count].SongsId = songid;
                            TablePlaylistSongs[count].DurationMs = Convert.ToInt32(reader["duration_ms"]);
                            TablePlaylistSongs[count].Popularity = Convert.ToInt16(reader["popularity"]);
                        }
                        count++;
                        getSongInfo.Parameters.Clear();
                    }
                    conn.Close();
                }

                foreach (var song in TablePlaylistSongs)
                {
                    PlaylistSongs.Add(song);
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
