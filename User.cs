
using Newtonsoft.Json;

namespace UserList
{
    public class User
    {
        [JsonProperty("userName")]
        public string UserName 
        {
            get;
            set;
        }

        [JsonProperty("password")]
        public string Password
        {
            get;
            set;
        }

    }
}