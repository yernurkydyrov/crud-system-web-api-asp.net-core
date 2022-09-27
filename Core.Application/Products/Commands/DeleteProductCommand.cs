using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Application.Products.Models;

namespace Core.Application.Products.Commands
{
    public class DeleteProductCommand
    {
        public int  ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }

        private readonly IAppDbContext DbContext;

        public DeleteProductCommand(IAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await DbContext.Products.FindAsync(new object[]{id});
            if (product is null)
            {
                throw new InvalidOperationException("Product not found");
            }

            DbContext.Products.Remove(product);
            await DbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}