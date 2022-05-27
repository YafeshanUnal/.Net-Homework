using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBooks
{

    public class DeleteBooksQuery
    {

        private readonly DatabaseContext _context;

        public DeleteBookModel Model { get; set; }
        public DeleteBooksQuery(DatabaseContext context)
        {
            _context = context;
        }

        public int BookId { get; set; }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.id == BookId);

            if (book is null)
            {
                throw new Exception("Bu ID ye sahip kitap bulunamadı");
            }

            _context.Remove(book);
            _context.SaveChanges();
        }

        public class DeleteBookModel
        {

            public int BookId { get; set; }
        }
    }
}