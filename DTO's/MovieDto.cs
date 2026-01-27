namespace Dorimuth_Backend.DTO_s
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }
}
