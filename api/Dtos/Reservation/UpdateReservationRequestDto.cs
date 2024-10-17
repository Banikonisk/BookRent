using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Reservation
{
    public class UpdateReservationRequestDto
    {
        public bool TypeAudio { get; set; }
        public bool QuickPickUp { get; set; }
        public int Days { get; set; }
    }
}