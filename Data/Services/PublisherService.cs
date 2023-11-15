using System;
using System.Linq;
using libreria_AGGP.Data.Models;
using libreria_AGGP.Data.ViewModels;
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
        }
    }
}
