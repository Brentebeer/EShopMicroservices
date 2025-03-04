using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);

    //Application logic layer
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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


            //return createProdcutResult result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
