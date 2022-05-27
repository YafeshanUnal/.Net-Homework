using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
namespace WebApi.BookOperations.CreateBooks{


    public class CreateBookCommand{

        public CreateBookModel Model { get; set; }
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(DatabaseContext context,IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if(book is not null){
                throw new Exception("Bu kitap zaten var");
            }

            book = _mapper.Map<Book>(Model);  // new Book();
            // book.Title = Model.Title;
            // book.PublishDate = Model.PublishDate;                // Auto map varken vs yokken      
            // book.PageCount = Model.PageCount;
            // book.GenreId = Model.GenreId;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

    }

    public class CreateBookModel{
            
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
    }
}