using System;
using System.Linq;
using AutoMapper;
using WebApi;
using WebApi.DBOperations;

namespace Webapi.BookOperations.GetBookDetail
{

    public class GetBookDetailQuery
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQuery Model { get; set; }

        public GetBookDetailQuery(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int BookId { get; set; }

        public BookDetailViewModel Handle()
        {

            var book = _context.Books.Where(x => x.id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new Exception("Bu ID ye sahip kitap bulunamadı");
            }
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);           // new BookDetailViewModel();
            // vm.Title = book.Title;
            // vm.GenreId = book.GenreId;
            // vm.PageCount = book.PageCount;
            // vm.PublishDate = book.PublishDate;

            return vm;

        }
    }


    public class BookDetailViewModel
    {

        public int id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}