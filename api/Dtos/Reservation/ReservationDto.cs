using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public bool TypeAudio { get; set; }
        public bool QuickPickUp { get; set; }
        public int Days { get; set; }
        public double Cost { get; set; }
        public int? BookId { get; set; }
    }
}