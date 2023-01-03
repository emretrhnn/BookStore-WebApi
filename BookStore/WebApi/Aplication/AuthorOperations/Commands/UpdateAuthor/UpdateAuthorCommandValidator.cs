using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.UpdateCommand;

namespace WebApi.Validator.AuthorValidator
{

    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

      public UpdateAuthorCommandValidator()
      {
        RuleFor(x => x.Model.Name).MinimumLength(2)
        .When(x => x.Model.Name != string.Empty);

        RuleFor(x => x.Model.Surname).MinimumLength(2)
        .When(x => x.Model.Surname != string.Empty);

        RuleFor(x=> x.Model.BookId).NotEmpty().GreaterThan(0);
      }
      
    }
}