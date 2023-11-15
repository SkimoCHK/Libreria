using System.Collections.Generic;

namespace libreria_AGGP.Data.Models
{
    public class Author
    {

        public int Id { get; set; }

        public string Fullname { get; set; }
        

        //Propiedades de navegación

        public List<Book_Author> Book_Authors { get; set; }


    }
}
