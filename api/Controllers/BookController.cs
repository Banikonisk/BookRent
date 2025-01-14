using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var books = await _bookRepo.GetAllAsync(query); //Deffered execution
            var stockDto = books.Select(b => b.ToBookDto());
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) //  Model binding {id}
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book.ToBookDto());
        }

        //Not used
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateDto();
            await _bookRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById), new { id = bookModel.Id}, bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto)
        {
            var bookModel = await _bookRepo.UpdateAsync(id, bookDto);
            if(bookModel == null)
            {
                return NotFound();
            }
            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel = await _bookRepo.DeleteAsync(id);
            if(bookModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}