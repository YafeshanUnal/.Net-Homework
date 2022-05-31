using System;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Entity;
using System.Linq;  
using System.Collections.Generic;

namespace WebApi.Application.AuthorOperations.Query.GetAuthors
{

    public class GetAuthorQuery
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AuthorViewModel Model { get; set; }

        public GetAuthorQuery(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var author = _context.Authors.Include(x=>x.Book).OrderBy(x => x.Id).ToList<Author>();
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(author);

            if (author is null)
            {
                throw new Exception("Bu yazar yok");
            }

            return vm;
        }

        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SurName { get; set; }
            public DateTime BirthDate { get; set; }


            public string Book { get; set; }

            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }




        }

    }

}
