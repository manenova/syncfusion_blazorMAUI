using LoginMAUIBlazor.Helpers;
using LoginMAUIBlazor.Interfaces;
using LoginMAUIBlazor.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace LoginMAUIBlazor.Services
{
    public class LoginService : ILogin
    {
        System.Net.Http.HttpClient client;
        string WebAPIUrl = string.Empty;

        public LoginService()
        {
            client = new System.Net.Http.HttpClient();
        }

        public async Task<Login> Authenticate(UserMin userMin)
        {

            await Task.Delay(1000);
            userMin.Password = Functions.GetSHA256(userMin.Password);
            WebAPIUrl = "https://localhost:44395/api/auth/login";


            var uri = new Uri (WebAPIUrl);

            try
            {
                HttpContent _content = new StringContent(JsonConvert.SerializeObject(userMin));
                _content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(uri, _content);

                if (response.IsSuccessStatusCode)
                {
                    Login login = new Login();
                    var content = await response.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<Login>(content);
                    return login;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }

            return null;

        }
    }
}
