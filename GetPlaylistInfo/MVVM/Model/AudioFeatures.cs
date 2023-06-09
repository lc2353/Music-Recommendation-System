﻿using Newtonsoft.Json;
using System;

namespace GetPlaylistInfo.MVVM.Model
{
    public partial class AudioFeatures
    {
        [JsonProperty("audio_features")]
        public AudioFeature[] Features { get; set; }
    }

    public partial class AudioFeature
    {
        [JsonProperty("danceability")]
        public double Danceability { get; set; }

        [JsonProperty("energy")]
        public double Energy { get; set; }

        [JsonProperty("key")]
        public long Key { get; set; }

        [JsonProperty("loudness")]
        public double Loudness { get; set; }

        [JsonProperty("mode")]
        public long Mode { get; set; }

        [JsonProperty("speechiness")]
        public double Speechiness { get; set; }

        [JsonProperty("acousticness")]
        public double Acousticness { get; set; }

        [JsonProperty("instrumentalness")]
        public double Instrumentalness { get; set; }

        [JsonProperty("liveness")]
        public double Liveness { get; set; }

        [JsonProperty("valence")]
        public double Valence { get; set; }

        [JsonProperty("tempo")]
        public double Tempo { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("track_href")]
        public Uri TrackHref { get; set; }

        [JsonProperty("analysis_url")]
        public Uri AnalysisUrl { get; set; }

        [JsonProperty("duration_ms")]
        public long DurationMs { get; set; }

        [JsonProperty("time_signature")]
        public long TimeSignature { get; set; }
    }

}
