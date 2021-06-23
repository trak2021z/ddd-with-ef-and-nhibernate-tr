using Library.Data.EF;
using Library.Data.EF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EFTestController : ControllerBase
    {
        [HttpPost("AddBook")]
        public IActionResult AddBook(
            )
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(Book.Create("test", null).Value);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                var bookFromDb = context.Books.Find(id);
            }

            return Ok();
        }

        [HttpGet("member/{id}")]
        public IActionResult GetMember(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                var member = context.Members.Find(id);
            }

            return Ok();
        }

        [HttpGet("member/updateFavoriteBook")]
        public IActionResult UpdateFavoriteBook()
        {
            Book storedBook;
            using (var context = new ApplicationDbContext())
            {
                storedBook = context.Books.Find(3L);
            }

            using (var context = new ApplicationDbContext())
            {
                var member = context.Members.Find(1L);
                member.UpdateFavoriteBook(storedBook);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("BorrowBook/{bookId}")]
        public IActionResult BorrowBook(long bookId)
        {
            using (var context = new ApplicationDbContext())
            {
                var book = context.Books.Find(bookId);
                var member = context.Members.Find(1L);
                member.BorrowBook(book);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpPost("AddCategory/{bookId}")]
        public IActionResult AddCategory(long bookId)
        {
            using (var context = new ApplicationDbContext())
            {
                var book = context.Books.Find(bookId);
                var category = context.Categories.Find(1L);
                book.AddCategory(category);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
