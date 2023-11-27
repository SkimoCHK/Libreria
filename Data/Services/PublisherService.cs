using System;
using System.Linq;
using libreria_AGGP.Data.Models;
using System.Text.RegularExpressions;
using libreria_AGGP.Data.ViewModels;
using libreria_AGGP.Exceptions;
namespace libreria_AGGP.Data.Services
{  
    public class PublisherService
    {
        private AppDbContext _context;
        
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        //Método que nos permite agregar una nueva Editora en la BD

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un número",
                publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;


        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM() {

                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.Fullname).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null )
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges(); 
            }
            else
            {
                throw new Exception($"La editora con ese id {id} no existe!");
            }
        }
        //--AMBAS FORMAS SON LA MISMA COSA XD POR FIN LO ENTIENDO XDX
        //private bool StringStartsWithNumber(string name)
        //{
        //    if (Regex.IsMatch(name, @"^\d")) return true; 
        //    return false;
        //}
        
        private bool StringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");
        //Esto es lo mismo q lo de arriba!!
             
        

    }
}
