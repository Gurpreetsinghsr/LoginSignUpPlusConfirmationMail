using ConformationEmail.Data;
using ConformationEmail.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConformationEmail.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;

        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Auther = model.Auther,
                Details = model.Details,
                Price = model.Price
            };
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();

            if (allBooks ?.Any() == true)
            {
                foreach (Books book in allBooks)
                {
                    books.Add(new BookModel
                    {
                        Auther = book.Auther,
                        Title = book.Title,
                        Details = book.Details,
                        Id = book.Id

                    });
                }
            
            }

            return books;
           
        }

        public async Task<BookModel> GetBook(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
           if(book != null)
            {
                var data = new BookModel
                {
                    Auther = book.Auther,
                    Title = book.Title,
                    Details = book.Details,
                    Id = book.Id
                };
                return data;
            }
            return null;
            
        }
    }
}
