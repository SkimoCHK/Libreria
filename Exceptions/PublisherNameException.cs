using System;

namespace libreria_AGGP.Exceptions
{
    public class PublisherNameException:Exception
    {

        public string PublisherName { get; set; }

        public PublisherNameException() 
        {
        
        }

        public PublisherNameException(string message) : base(message)
        {

        }
        PublisherNameException(string messae, Exception inner) : base(messae, inner)
        {

        }
        public PublisherNameException(string message, string Publishername) : this(message)
        {
            PublisherName = Publishername;
        }


    }
}
