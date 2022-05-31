using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Command.UpdateAuthors{

    public class UpdateAuthorCommand{
            
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public UpdateAuthorModel Model { get; set; }
            public int AuthorId { get; set; }
    
            public UpdateAuthorCommand(DatabaseContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
    
            public void Handle(){
                var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
                
                if (author == null){
                    throw new Exception("Bu ID ye sahip bir yazar bulunamadı");
                }


                author.Name = Model.Name != default ? Model.Name : author.Name;
                author.SurName = Model.SurName != default ? Model.SurName : author.SurName;

                _context.SaveChanges();
                    
            }


            public class UpdateAuthorModel{
                public string Name { get; set; }
                public string SurName { get; set; }   
            }
    }
}