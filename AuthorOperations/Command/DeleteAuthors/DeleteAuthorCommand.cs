using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Command.DeleteAuthors
{

    public class DeleteAuthorCommand
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public Book book { get; set; }

        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public DeleteAuthorCommand(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var book = _context.Authors.Include(x => x.Book).SingleOrDefault(x=>x.Id == BookId);

            if (author is null)
            {
                throw new Exception("Bu yazar yok");
            }
            if (book is null)
            {
                throw new Exception("Bu yazarın kitabını silmeden bu yazarı silemezsiniz");
            }
            Console.WriteLine("Book: " + book);
            _context.Authors.Remove(author);
            _context.SaveChanges();

        }




    }
}