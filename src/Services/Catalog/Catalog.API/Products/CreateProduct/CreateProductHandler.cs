namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    //Application logic layer
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create product entity from command object.
            
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
