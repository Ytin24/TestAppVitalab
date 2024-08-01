using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppVitalab.Api.DAL.Context;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController(ILogger<OrderController> logger, VitalabTestDbContext vitalabTestDbContext) : Controller
{
    
    /// <summary>
    /// Получить список заказов пользователя
    /// </summary>
    /// <param name="user">Информация о пользователе</param>
    /// <returns>Список заказов пользователя в виде коллекции <see cref="Order"/></returns>
    /// <response code="200">Список заказов пользователя</response>
    /// <example>
    /// <code>
    /// {
    ///     "id": "1",
    ///     "date": "2023-01-01T00:00:00",
    ///     "status": "new",
    ///     "user": {
    ///         "userLogin": "testLogin",
    ///         "userPassword": "testPassword"
    ///     },
    ///     "items": [
    ///         {
    ///             "id": "1",
    ///             "name": "Товар 1",
    ///             "price": 100.0,
    ///             "count": 10
    ///         },
    ///         {
    ///             "id": "2",
    ///             "name": "Товар 2",
    ///             "price": 200.0,
    ///             "count": 5
    ///         }
    ///     ]
    /// }
    /// </code>
    /// </example>
    [HttpPost("[Action]")]
    public async Task<IActionResult> GetUserOrders(UserDTO user)
    {
        var orders = await vitalabTestDbContext.Orders.Include(x=>x.OrderItems).ThenInclude(x=>x.Product).AsNoTracking()
            .Where(x => x.UserId == user.UserId)
            .ToListAsync();

        return Ok(orders.Adapt<ICollection<OrderDTO>>());
    }

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    /// <param name="UserOrder">Информация о пользователе</param>
    /// <returns>Статус успешного создания заказа</returns>
    /// <response code="200">Заказ успешно создан</response>
    /// <response code="400">Не удалось создать новый заказ</response>
    [HttpPost("[Action]")]
    public async Task<IActionResult> CreateUserOrder(OrderDTO UserOrder)
    {
        var order = UserOrder.Adapt<Order>();
        vitalabTestDbContext.Orders.Add(order);
        try
        {
            await vitalabTestDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
          vitalabTestDbContext.Orders.Remove(order);
          logger.LogError(e.Message);
          return BadRequest("Не удалось создать новый заказ");
        }

        return Ok();
    }
}