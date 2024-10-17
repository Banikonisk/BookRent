using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Models;

namespace api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Name = bookModel.Name,
                Year = bookModel.Year,
                Reservations = bookModel.Reservations.Select(r => r.ToReservationDto()).ToList(),
                ImageUrl = bookModel.ImageUrl
            };
        }

        public static Book ToBookFromCreateDto(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Name = bookDto.Name,
                Year = bookDto.Year
            };
        }
    }
}