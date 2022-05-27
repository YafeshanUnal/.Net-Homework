using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBooks;
using WebApi.BookOperations.UpdateBooks;
using Webapi.BookOperations.GetBookDetail;
using WebApi.BookOperations.DeleteBooks;
using AutoMapper;
using WebApi.BookOperations;
using FluentValidation;

namespace WebApi.AddControllers

{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        // Yalnızca Constructor tarafından değiştirilsin uygulama içinden değişemezsin diye yapılan bişey
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public BookController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; ;
        }


        // private static List<Book> BookList = new List<Book>(){

        //     new Book{
        //         id = 1,
        //         Title = "Beyaz Diş",
        //         GenreId = 1,
        //         PageCount = 200,
        //         PublishDate = new DateTime(2022,05,22)
        //     },
        //     new Book{
        //         id = 2,
        //         Title = "Güvercin Kanat",
        //         GenreId = 2,
        //         PageCount = 150,
        //         PublishDate = new DateTime(2015,02,21)
        //     },
        //     new Book{
        //         id = 3,
        //         Title = "Semerkant",
        // GenreId = 3,
        //         PageCount = 200,
        //         PublishDate = new DateTime(2002,12,5)
        //     }

        // };


        // READ
        [HttpGet] //Hepsini okuma işlemi Read all of    
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // READ ONE
        [HttpGet("{id}")] // Url ye parametre yollayarak bir id çekme işlemi Read
        public IActionResult GetByBooks(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
                query.BookId = id;
            try
            {
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);                      //FirstOrDefault ise Sadece bir tane getir demek ne olursa olsun
        }

        // CREATE
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                // ValidationResult result = validator.Validate(command);
                // if (!result.IsValid)
                //     foreach (var error in result.Errors)
                //     {
                //         Console.WriteLine("Hata Adı" + error.PropertyName + " Hata Mesajı" + error.ErrorMessage);
                //     }
                // else
                //     command.Handle();

            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
            
            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                UpdateBooksCommand command = new UpdateBooksCommand(_context);
            try
            {
                command.Bookid = id;
                command.Model = updateBook;
                validator.ValidateAndThrow(command);
                command.Handle();
            }   
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }

            return Ok();

        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBooksCommand command = new DeleteBooksCommand(_context);
            DeleteBooksCommandValidator validator = new DeleteBooksCommandValidator();
            try
            {
                command.BookId = id;
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }

            return Ok();
        }
    }
}