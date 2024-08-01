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
        /// ���������� �������� ������ ������������ �� ���� ������ �� ������ � ������.
        /// </summary>
        /// <param name="user">������ UserAuthDTO, ���������� ����� � ������ ������������.</param>
        /// <returns>������ IActionResult, ������� �������� ������ ������������ � ������ ��������� ���������, ���� ��������� �� ������ � ������ ���������� ���������.</returns>
        /// <response code="200">������ ������������ ������� ��������.</response>
        /// <response code="404">������������ � ��������� ������� � ������� �� ������ � ���� ������.</response>
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
