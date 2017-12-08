using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace personalNotesApp
{
    public class personalNotesAppApiConnector
    {
        private static readonly HttpClient client = new HttpClient();
        private string apiUrl = "https://personalnotesapi.alexparedes.ovh/";
        private string token = "";
        private Boolean isLogged = false;
        public personalNotesAppApiConnector()
        {
            client.Timeout = TimeSpan.FromSeconds(2);
        }
        public void deleteNote(string noteId, Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "deleteNote",
                    token = this.token,
                    noteId = noteId
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void getStatus(Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "status",
                    token = this.token,
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void attemptLogin(string username, string password, Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new {
                    query = "login",
                    username = username,
                    password = password
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void createUser(string username, string password, string email, Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "createUser",
                    username = username,
                    email = email,
                    password = password
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void getNotes(Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "notes",
                    token = this.token
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void editNote(string noteId, string newTitle, string newText, Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "editNote",
                    token = this.token,
                    noteId = noteId,
                    text = newText,
                    title = newTitle
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        public void newNote(string newTitle, string newText, Action<bool, string> callback)
        {
            JObject jsonValues = JObject.FromObject(
                new
                {
                    query = "newNote",
                    token = this.token,
                    text = newText,
                    title = newTitle
                }
            );
            this.genericRequestMethod(jsonValues, callback);
        }
        private async void genericRequestMethod(JObject jsonValues, Action<bool, string> callback)
        {
            var content = new StringContent(jsonValues.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(this.apiUrl, content);

                string responseString = await response.Content.ReadAsStringAsync();
                callback(true, responseString);

            }
            catch (Exception e)
            {
                callback(false, "Connection error.");
            }
        }
        public void setToken(string token)
        {
            this.token = token;
        }
        public string getToken()
        {
            return this.token;
        }
        public string getApiURL()
        {
            return this.apiUrl;
        }
    }
}
