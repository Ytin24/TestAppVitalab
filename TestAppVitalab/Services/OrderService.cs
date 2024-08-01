using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Services
{
    /// <summary>
    /// Сервис для работы с заказами
    /// </summary>
    public class OrderService : BaseService, IOrderService
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Создает экземпляр сервиса для работы с заказами
        /// </summary>
        /// <param name="authService">Сервис аутентификации</param>
        public OrderService(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Попытаться получить список заказов
        /// </summary>
        /// <returns>Список заказов в виде коллекции <see cref="OrderDTO"/></returns>
        /// <exception cref="InvalidOperationException">Если необходимо авторизоваться</exception>
        public async Task<ICollection<OrderDTO>> TryGetOrders()
        {
            using (HttpClient client = new HttpClient())
            {
                var answer = await client.PostAsync($"{BASE_URL}Order/GetUserOrders", JsonContent.Create(_authService.CurrentUser));
                if (!answer.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException("Необходимо авторизироваться");
                }
                return (await answer.Content.ReadFromJsonAsync<ICollection<OrderDTO>>())!;
            }
        }

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        /// <param name="order">Данные нового заказа</param>
        /// <returns>True, если заказ успешно создан, иначе false</returns>
        /// <exception cref="NotImplementedException">Метод еще не реализован</exception>
        public async Task<bool> CreateOrder(Order order)
        {
            using (HttpClient client = new HttpClient())
            {
                var answer = await client.PostAsync($"{BASE_URL}Order/CreateUserOrder", JsonContent.Create(_authService.CurrentUser));
                return answer.IsSuccessStatusCode;
            }
        }
    }

    /// <summary>
    /// Интерфейс для работы с заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Попытаться получить список заказов
        /// </summary>
        /// <returns>Список заказов в виде коллекции <see cref="OrderDTO"/></returns>
        Task<ICollection<OrderDTO>> TryGetOrders();

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        /// <param name="order">Данные нового заказа</param>
        /// <returns>True, если заказ успешно создан, иначе false</returns>
        Task<bool> CreateOrder(Order order);
    }
}