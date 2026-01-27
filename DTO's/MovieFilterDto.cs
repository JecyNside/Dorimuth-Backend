namespace Dorimuth_Backend.DTO_s
{
    public class MovieFilterDto
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? RoomId { get; set; }
        public TimeSpan? StartTime { get; set; }
    }
}
