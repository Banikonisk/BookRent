using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BookExists(int id)
        {
            return _context.Book.AnyAsync(x => x.Id == id);
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Book.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            if(bookModel == null)
            {
                return null;
            }
            _context.Book.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync(QueryObject query)
        {
            var books = _context.Book.Include(x => x.Reservations).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                books = books.Where(x => x.Name.Contains(query.Name));
            }
            if(!string.IsNullOrWhiteSpace(query.Year))
            {
                books = books.Where(x => x.Year.ToString().Contains(query.Year));
            }
            return await books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Book.Include(r => r.Reservations).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookDto)
        {
            var book = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            if(book == null)
            {
                return null;
            }
            book.Name = bookDto.Name;
            book.Year = bookDto.Year;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}