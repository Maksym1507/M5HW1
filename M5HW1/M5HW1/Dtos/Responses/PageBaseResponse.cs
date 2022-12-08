using Newtonsoft.Json;

namespace M5HW1.Dtos.Responses
{
    public class PageBaseResponse<T>
        where T : class
    {
        public int Page { get; set; }

        public int Total { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        public T[] Data { get; set; }

        public SupportDto Support { get; set; }
    }
}
