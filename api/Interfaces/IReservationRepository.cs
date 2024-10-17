using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation reservationModel);
        Task<Reservation?> UpdateAsync(int id, Reservation reservationModel);
        Task<Reservation?> DeleteAsync(int id);
    }
}