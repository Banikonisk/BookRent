using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDBContext _context;
        public ReservationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateAsync(Reservation reservationModel)
        {
            await _context.Reservations.AddAsync(reservationModel);
            await _context.SaveChangesAsync();
            return reservationModel;
        }

        public async Task<Reservation?> DeleteAsync(int id)
        {
            var reservationModel = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if(reservationModel == null)
            {
                return null;
            }
            _context.Reservations.Remove(reservationModel);
            await _context.SaveChangesAsync();
            return reservationModel;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<Reservation?> UpdateAsync(int id, Reservation reservationModel)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if(reservation == null)
            {
                return null;
            }
            reservation.TypeAudio = reservationModel.TypeAudio;
            reservation.QuickPickUp = reservationModel.QuickPickUp;
            reservation.Days = reservationModel.Days;
            reservation.CalculateCost();
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}