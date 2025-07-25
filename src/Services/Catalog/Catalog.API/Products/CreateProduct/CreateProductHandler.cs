namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image file is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    //Application logic layer
    internal class CreateProductCommandHandler(
        IDocumentSession session,
        IValidator<CreateProductCommand> validator
        ) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create product entity from command object.

            var result = await validator.ValidateAsync(command, cancellationToken);
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors.Any())
            {
                throw new ValidationException(errors.FirstOrDefault());
            }

            var product = new Product
            {
                Name = command.name,
                Category = command.category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //Save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return createProdcutResult result
            return new CreateProductResult(product.Id);
        }
    }
}
