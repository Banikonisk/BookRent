using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public string ImageUrl { get; set; } = string.Empty;
    }
}