namespace M5HW1.Dtos.Responses
{
    public class UpdateUserResponse
    {
        public string Name { get; set; }

        public string Job { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
