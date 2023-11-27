
using libreria_AGGP.Data.Models;
using libreria_AGGP.Data.ViewModels;
using libreria_AGGP.Exceptions;
using System;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;

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
            if (StringStartsWithNumber(author.FullName)) throw new PublisherNameException("El nombre del autor no puede empezar con un número",
              author.FullName);
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
        private bool StringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");


    }
}
