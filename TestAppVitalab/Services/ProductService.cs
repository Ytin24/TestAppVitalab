using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Services;

/// <summary>
/// Сервис для работы с товарами
/// </summary>
public class ProductService : BaseService, IProductService
{
    /// <summary>
    /// Получить список товаров
    /// </summary>
    /// <returns>Список товаров в виде коллекции <see cref="ProductDTO"/></returns>
    /// <exception cref="InvalidOperationException">Если необходимо авторизоваться</exception>
    public async Task<ICollection<ProductDTO>> GetProducts()
    {
        using (HttpClient client = new HttpClient())
        {
            var answer = await client.GetAsync($"{BASE_URL}Products/GetProducts");
            if (!answer.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Необходимо авторизироваться");
            }
            return (await answer.Content.ReadFromJsonAsync<ICollection<ProductDTO>>())!;
        }
    }
}

/// <summary>
/// Интерфейс для работы с товарами
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Получить список товаров
    /// </summary>
    /// <returns>Список товаров в виде коллекции <see cref="ProductDTO"/></returns>
    Task<ICollection<ProductDTO>> GetProducts();
}