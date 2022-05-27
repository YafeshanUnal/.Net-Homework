using System;
using System.Linq;
using WebApi;
using WebApi.DBOperations;

namespace Webapi.BookOperations.GetByBooks{

    public class GetByBooksQuery {

        private readonly DatabaseContext _context;

        public GetByBooksQuery(DatabaseContext  context){
            _context = context;
        }

        public int BookId { get; set;}

        public Book Handle(){

            var book = _context.Books.Where(x => x.id == BookId).FirstOrDefault();
            
            if (book is null)
            {
                throw new Exception("Bu ID ye sahip kitap bulunamadı");
            }

            return book;

        }
    }


    public class GetByBookViewModel{
            
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
    }
}