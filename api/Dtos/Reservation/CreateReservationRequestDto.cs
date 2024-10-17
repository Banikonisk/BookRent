using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Reservation
{
    public class CreateReservationRequestDto
    {
        public bool TypeAudio { get; set; }
        public bool QuickPickUp { get; set; }
        public int Days { get; set; }
    }
}