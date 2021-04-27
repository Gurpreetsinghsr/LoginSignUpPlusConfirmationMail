using ConformationEmail.Models;
using ConformationEmail.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConformationEmail.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository ;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetBook(int Id)
        {
            var data = await _bookRepository.GetBook(Id);
            return View(data);
        }

        public async Task<ViewResult> GetBooks()
        {
            var data =await _bookRepository.GetBooks();
            return View(data);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int BookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = BookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  AddNewBook(BookModel bookModel)
        {
            int Id= await _bookRepository.AddNewBook(bookModel);
            if(Id>0)
            {
                return RedirectToAction("AddNewBook", new { isSuccess = true, BookId = Id }); ;
            }
            return View();
        }

    }
}
