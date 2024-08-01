using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppVitalab.Api.DAL.Context;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController(ILogger<LoginController> logger, VitalabTestDbContext vitalabTestDbContext) : ControllerBase {
        
        /// <summary>
        /// Асинхронно получает данные пользователя из базы данных по логину и паролю.
        /// </summary>
        /// <param name="user">Объект UserAuthDTO, содержащий логин и пароль пользователя.</param>
        /// <returns>Объект IActionResult, который содержит данные пользователя в случае успешного получения, либо сообщение об ошибке в случае неудачного получения.</returns>
        /// <response code="200">Данные пользователя успешно получены.</response>
        /// <response code="404">Пользователь с указанным логином и паролем не найден в базе данных.</response>
        /// <example>
        /// <code>
        /// {
        ///     "userLogin": "admin",
        ///     "userPassword": "admin123"
        /// }
        /// </code>
        /// </example>
        [HttpPost("[Action]")]
        public async Task<IActionResult> GetUser(UserDTO user) {
            var authUser = await vitalabTestDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserLogin == user.UserLogin && x.UserPassword == user.UserPassword);
            return authUser is null ? NotFound() : Ok(authUser.Adapt<UserDTO>());
        }
    }
}
