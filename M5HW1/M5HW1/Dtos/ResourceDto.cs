using Newtonsoft.Json;

namespace M5HW1.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        [JsonProperty(PropertyName = "pantone_value")]
        public string PantoneValue { get; set; }
    }
}
