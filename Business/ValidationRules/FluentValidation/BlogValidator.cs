using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Title).MinimumLength(1).MaximumLength(100);
            RuleFor(b => b.Content).MinimumLength(1).MaximumLength(4000);
        }
    }
}
