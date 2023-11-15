
using libreria_AGGP.Data.Models;
using libreria_AGGP.Data.ViewModels;
using System;
using System.Linq;

namespace libreria_AGGP.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Fullname = author.FullName

            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooksVM(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.Fullname,
                BookTitiles =n.Book_Authors.Select(n=> n.book.Titulo).ToList()
            }).FirstOrDefault();
            return _author;
        }


    }
}
