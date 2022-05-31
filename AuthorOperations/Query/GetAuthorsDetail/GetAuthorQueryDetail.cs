using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Query.GetAuthorsDetail{
    public class GetAuthorQueryDetail{
        public GetAuthorQueryDetail(DatabaseContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public AuthorDetailViewModel Model { get; set; }
        public AuthorDetailViewModel Handle(){

            var authors = _context.Authors.Include(x=>x.Book).Where(x => x.Id == AuthorId).SingleOrDefault();

            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(authors);

            if (authors == null)
            {
                throw new Exception("Author not found");
            }
            return vm;
        }
    public class AuthorDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }   
        public DateTime BirthDate { get; set; }
        public string Book { get; set; }

        
    }
    }

}