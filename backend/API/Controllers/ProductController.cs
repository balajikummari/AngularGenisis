using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Data;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _StoreContext;

        public ProductsController(StoreContext  context)
        {
            _StoreContext = context;            
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Getproducts()
        {
            return Ok( await _StoreContext.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){

             return Ok( await _StoreContext.Products.FindAsync(id));
        }
    }
}