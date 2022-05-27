using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;

namespace WebApi.BookOperations.GetBooks
{


    public class GetBooksQuery
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BooksViewModel Model { get; set; }

        public GetBooksQuery(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       


        public List<BooksViewModel> Handle()
        {
            var booklist = _context.Books.OrderBy(x => x.id).ToList<Book>();  //OrderBy Linq ile sql sorgularından gelmektedir
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booklist);  // AutoMapper ile
            // foreach (var book in booklist){
            //     vm.Add(new BooksViewModel{
            //         id = book.id,
            //         Title = book.Title,
            //         Genre = ((GenreEnum)book.GenreId).ToString(),
            //         PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //         PageCount = book.PageCount
            //     });
            // }
            
            return vm;
        }
    }




    public class BooksViewModel
    {

        public int id {get; set;}
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }

    }
}
