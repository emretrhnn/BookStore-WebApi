using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateCommand;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;
using WebApi.Validator.AuthorValidator;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public ActionResult GetAuthor()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_mapper,_context);
            var author = query.Handle();
            return Ok(author);
        }
        [HttpGet("id")]
        public ActionResult GetByIdAuthor(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_mapper,_context);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var author = query.Handle();
            return Ok(author);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_mapper,_context);
            command.Model = model;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = model;

            UpdateAuthorCommandValidator validator  = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        
    }
}