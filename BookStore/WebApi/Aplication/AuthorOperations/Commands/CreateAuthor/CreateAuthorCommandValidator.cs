using FluentValidation;


namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{

    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {

      public CreateAuthorCommandValidator()
      {

        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.Surname).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        
      }
      
    }
}