using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AuthorOperations.Commands.DeleteAuthor;
using Application.AuthorOperations.Commands.UpdateAuthor;
using Application.AuthorOperations.Queries.GetAuthorById;
using Application.AuthorOperations.Queries.GetAuthors;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.DBOperations;

namespace Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors(){
            GetAuthorsQuery query = new GetAuthorsQuery(_bookStoreDbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id){
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_bookStoreDbContext,_mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle(); 
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor(CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_bookStoreDbContext, _mapper);
            command.authorModel = newAuthor;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, UpdateAuthorModel updateModel){
            UpdateAuthorCommand command = new UpdateAuthorCommand(_bookStoreDbContext);
            command.AuthorId = id;
            command.AuthorModel = updateModel;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            DeleteAuthorCommand command = new DeleteAuthorCommand(_bookStoreDbContext);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();            
        }
    }
}