using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Reservation;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IBookRepository _bookRepo;
        public ReservationController(IReservationRepository reservationRepo, IBookRepository bookRepo)
        {
            _reservationRepo = reservationRepo;
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _reservationRepo.GetAllAsync();
            var reservationDto = reservations.Select(s => s.ToReservationDto());
            return Ok(reservationDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var reservation = await _reservationRepo.GetByIdAsync(id);
            if(reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation.ToReservationDto());
        }

        [HttpPost("{bookId:int}")]
        public async Task<IActionResult> Create([FromRoute] int bookId, [FromBody] CreateReservationRequestDto reservationDto)
        {
            if(!await _bookRepo.BookExists(bookId))
            {
                return BadRequest("Book does not exist");
            }
            var reservationModel = reservationDto.ToReservationFromCreate(bookId);
            reservationModel.CalculateCost();
            await _reservationRepo.CreateAsync(reservationModel);
            return CreatedAtAction(nameof(GetById), new { id = reservationModel.Id }, reservationModel.ToReservationDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateReservationRequestDto reservationDto)
        {
            var reservation = await _reservationRepo.UpdateAsync(id, reservationDto.ToReservationFromUpdate());
            if(reservation == null)
            {
                return NotFound("Reservation not found");
            }
            return Ok(reservation.ToReservationDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var reservationModel = await _reservationRepo.DeleteAsync(id);
            if(reservationModel == null)
            {
                return NotFound("Reservation does not exist");
            }
            return NoContent();
        }
    }
}