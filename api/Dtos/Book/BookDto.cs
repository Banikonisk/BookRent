using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Reservation;

namespace api.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}