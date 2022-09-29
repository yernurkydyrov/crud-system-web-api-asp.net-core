using System.Threading.Tasks;
using Core.Application.Attributes.Models;
using Core.Application.Products.Commands;
using Core.Application.Products.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Dictionary
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromServices] CreateProductCommand createProductCommand,[FromBody] CreateProductDto dto)
        {
            await createProductCommand.CreateProductAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] UpdateProductCommand updateProductCommand,[FromBody] ProductDto dto)
        {

            await updateProductCommand.UpdateProductAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductCommand([FromServices] DeleteProductCommand deleteProductCommand,[FromBody] int id)
        {
            await deleteProductCommand.DeleteProductAsync(id);
            return Ok();
        }
    }
}