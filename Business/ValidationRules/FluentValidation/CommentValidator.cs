using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{

    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Content).MinimumLength(1).MaximumLength(500);
        }
    }
}
