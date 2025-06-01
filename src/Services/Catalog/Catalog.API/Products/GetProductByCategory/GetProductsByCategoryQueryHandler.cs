namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductsByCategoryQueryHandler(
        IDocumentSession session,
        ILogger<GetProductsByCategoryQueryHandler> logger) 
        : IQueryhandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryQueryHandler.Handle Called with {@query}", query);

            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();

            return new GetProductsByCategoryResult(products);
        }
    }
}
