using Newtonsoft.Json;

namespace M5HW1.Dtos.Requests
{
    public class AuthRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
