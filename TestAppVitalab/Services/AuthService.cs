using ReactiveUI;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Services {
    /// <summary>
    /// Сервис аутентификации пользователя.
    /// </summary>
    public class AuthService : BaseService, IAuthService {
        private bool _isAuth;

        /// <summary>
        /// Флаг, указывающий, авторизован ли пользователь.
        /// </summary>
        public bool IsAuth {
            get { return _isAuth; }
            set { this.RaiseAndSetIfChanged(ref _isAuth, value); }
        }
        private UserDTO _currentUser;

        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        public UserDTO CurrentUser {
            get { return _currentUser; }
            set { this.RaiseAndSetIfChanged(ref _currentUser, value); }
        }

        /// <summary>
        /// Попытка авторизации пользователя.
        /// </summary>
        /// <param name="userAuth">Данные для аутентификации пользователя.</param>
        /// <returns>Задача, представляющая попытку авторизации. Возвращает true, если авторизация успешна, иначе false.</returns>
        public async Task<bool> TryLoginUser(UserDTO userAuth) {
            try
            {
                using (HttpClient client = new()) {
                    var answer = await client.PostAsync($"{BASE_URL}Login/GetUser", JsonContent.Create(userAuth));
                    if (answer.IsSuccessStatusCode)
                    {
                        CurrentUser = await answer.Content.ReadFromJsonAsync<UserDTO>();
                        IsAuth = true;
                    }
                    else
                    {
                        IsAuth = false;
                    }
                }
            }
            catch
            {
                IsAuth = false;
            }
            
            return IsAuth;

        }
    }

    /// <summary>
    /// Интерфейс сервиса аутентификации пользователя.
    /// </summary>
    public interface IAuthService {
        /// <summary>
        /// Флаг, указывающий, авторизован ли пользователь.
        /// </summary>
        public bool IsAuth { get; set; }
        /// <summary>
        /// Текущий авторизованный пользователь.
        /// </summary>
        public UserDTO CurrentUser { get; set; }
        /// <summary>
        /// Попытка авторизации пользователя.
        /// </summary>
        /// <param name="userAuth">Данные для аутентификации пользователя.</param>
        /// <returns>Задача, представляющая попытку авторизации. Возвращает true, если авторизация успешна, иначе false.</returns>
        public Task<bool> TryLoginUser(UserDTO userAuth);
    }
}