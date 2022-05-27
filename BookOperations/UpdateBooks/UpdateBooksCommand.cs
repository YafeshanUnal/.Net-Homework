using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using System.Linq;
namespace WebApi.BookOperations.UpdateBooks
{

    public class UpdateBooksCommand
    {

        public UpdateBookModel Model { get; set; }
        public int Bookid { get; set;}
        private readonly DatabaseContext _context;

        public UpdateBooksCommand(DatabaseContext context)
        {
            _context = context;
        }

        public void Handle(){

            var book = _context.Books.SingleOrDefault(b => b.id == Bookid);

            if (book is null)
            {
                throw new Exception("Bu ID ye sahip kitap bulunamadı");
            }

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _context.SaveChanges();
        }
        
    }

    public class UpdateBookModel
    {   
        public string Title { get; set; }
        public int GenreId { get; set; }


    }
}