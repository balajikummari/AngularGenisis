using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Specification;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        public ProductsController(IGenericRepository<Product> productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesandBrandsSpec();
            var products = await _productsRepo.GetEntitiesWithSpecAsync(spec);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesandBrandsSpec(id);

            var product = await _productsRepo.GetEntityWithSpecAsync(spec);

            return Ok(product);
        }  

        //[HttpGet("brands")]
        //public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        //{
        //    return Ok(await _repo.GetProductBrandsAsync());
        //}

        //[HttpGet("types")]
        //public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        //{
        //    return Ok(await _repo.GetProductTypesAsync());
        //}
    }
}