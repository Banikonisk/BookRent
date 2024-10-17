using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public bool TypeAudio { get; set; }
        public bool QuickPickUp { get; set; }
        public int Days { get; set; }
        public double Cost { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }

        public void CalculateCost()
        {
            double tempCost = 3;
            if(QuickPickUp)
            {
                tempCost += 5;
            }
            int typeMultiplier = TypeAudio ? 3 : 2;
            tempCost += Days * typeMultiplier;
            double discount = 0;
            if(Days > 10)
            {
                discount = 0.2;
            }
            else if(Days > 3)
            {
                discount = 0.1;
            }
            tempCost -= tempCost * discount;
            Cost = tempCost;
        }
    }
}