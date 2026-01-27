using Dorimuth_Backend.Data.Entities;

namespace Dorimuth_Backend.DTO_s
{
    public class ShowtimeDto
    {
        public int ShowtimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AvailableTickets { get; set; }
        public bool Active { get; set; }
        public int MovieId { get; set; }
        public RoomDto Room { get; set; }
    }
}
