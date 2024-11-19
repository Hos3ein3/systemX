

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category,
    string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);


//! Application logic layer
internal class CreateProductCommandHandler(IDocumentSession _session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Logic to create a product

        //create product entity from command
        Product product = new()
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);
        //save product in database
        //return result
        return new CreateProductResult(Guid.NewGuid());
    }
}

