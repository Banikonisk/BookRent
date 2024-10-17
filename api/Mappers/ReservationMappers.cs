using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Reservation;
using api.Models;

namespace api.Mappers
{
    public static class ReservationMappers
    {
        public static ReservationDto ToReservationDto(this Reservation reservationModel)
        {
            return new ReservationDto
            {
                Id = reservationModel.Id,
                TypeAudio = reservationModel.TypeAudio,
                QuickPickUp = reservationModel.QuickPickUp,
                Days = reservationModel.Days,
                Cost = reservationModel.Cost,
                BookId = reservationModel.BookId
            };
        }

        public static Reservation ToReservationFromCreate(this CreateReservationRequestDto reservationDto, int bookId)
        {
            return new Reservation
            {
                TypeAudio = reservationDto.TypeAudio,
                QuickPickUp = reservationDto.QuickPickUp,
                Days = reservationDto.Days,
                BookId = bookId
            };
        }

        public static Reservation ToReservationFromUpdate(this UpdateReservationRequestDto reservationDto)
        {
            return new Reservation
            {
                TypeAudio = reservationDto.TypeAudio,
                QuickPickUp = reservationDto.QuickPickUp,
                Days = reservationDto.Days
            };
        }
    }
}