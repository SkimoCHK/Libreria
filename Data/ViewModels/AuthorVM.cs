using System.Collections.Generic;

namespace libreria_AGGP.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set;}
        public List<string> BookTitiles { get; set;}

    }

}
