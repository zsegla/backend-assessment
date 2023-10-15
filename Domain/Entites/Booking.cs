using System;
using CinemaApp.Domain.Common;

namespace CinemaApp.Domain.Entities
{
    public class Booking : BaseDomainEntity
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public int ShowtimeId { get; set; }
        public int UserId { get; set; }
        public string SeatNumber { get; set; }
        public string Status { get; set; }
    }
}
