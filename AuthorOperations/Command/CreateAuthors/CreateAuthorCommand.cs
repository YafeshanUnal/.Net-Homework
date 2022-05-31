using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entity;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthors
{
    public class CreateAuthorCommand{

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(DatabaseContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);

            if (author is not null){
                throw new Exception("Bu yazar zaten var");
            }

            author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);
            _context.SaveChanges(); 

        }

    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

    
    }
    




}