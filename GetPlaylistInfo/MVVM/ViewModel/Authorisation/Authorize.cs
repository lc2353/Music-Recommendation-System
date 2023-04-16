using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace GetPlaylistInfo.MVVM.Model
{
    public class Authorize
    {
        public static AccessToken Token { get; set; }
        public const string tokenn = "BQCPsDMMXUHCPFguLXdGeh7XKY7lqNYL6lq3bjP41KU_cebsD0cJjP6DyzwHtxYlmJxKpaDmmVz4lXwEq65gV5J4o7v3yrDYTI5adcb1NScRSt2cPCYMwqt4kmf5Rhl7LNHKoUHR5AFdnbmbwyzXg7iplqVYKAWNRiKIfcZpyoCDGT4UTkBzJCQ_upQU2Ur76uGiPxV7Os9mQF_4c7CTPoX5xN9TQI9ZY2R4p384Mkjrug";
        //    public static async Task<AccessToken> GetToken()
        //{
        //    #region credentials
        //    string clientId = "d2734de58b6047219c75ccba18a7fab7";
        //    string clientSecret = "4b6aacec430a4828900e7cf6d784d417";
        //    string clientCredentials = clientId + ":" + clientSecret;
        //    #endregion


        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(clientCredentials)));

        //    List<KeyValuePair<string, string>> requestData = new();
        //    requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

        //    FormUrlEncodedContent requestBody = new(requestData);

        //    var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
        //    var response = await request.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<AccessToken>(response)!;


        //}
    }
}
