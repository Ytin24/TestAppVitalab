using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppVitalab.Api.DAL.Context;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController(ILogger<ProductController> logger, VitalabTestDbContext vitalabTestDbContext) : Controller
{
    /// <summary>
    /// Получить список товаров
    /// </summary>
    /// <returns>Список товаров в виде коллекции <see cref="ProductDTO"/></returns>
    /// <response code="200">Список товаров</response>
    /// <example>
    /// <code>
    /// {
    ///     "id": "1",
    ///     "name": "Товар 1",
    ///     "price": 100.0,
    ///     "count": 10
    /// }
    /// </code>
    /// </example>
    [HttpGet("[Action]")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await vitalabTestDbContext.Products.AsNoTracking().ToListAsync();
        return Ok(products.Adapt<ICollection<ProductDTO>>());
    }
}