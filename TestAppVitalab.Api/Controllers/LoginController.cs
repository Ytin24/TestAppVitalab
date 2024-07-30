using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppVitalab.Api.DAL.Context;
using TestAppVitalab.Core.DTO;

namespace TestAppVitalab.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController(ILogger<LoginController> logger, VitalabTestDbContext vitalabTestDbContext) : ControllerBase {

        private readonly ILogger<LoginController> _logger = logger;
        private readonly VitalabTestDbContext _vitalabTestDbContext = vitalabTestDbContext;

        [HttpPost("[Action]")]
        public async Task<IActionResult> GetUserAsync(UserAuthDTO user) {
            _logger.LogInformation("вызван {0} | ip: {1}", this.Request.Method, this.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4());
            var authUser = await _vitalabTestDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserLogin == user.UserLogin && x.UserPassword == user.UserPassword);
            return authUser is null ? NotFound(authUser.Adapt<UserDTO>()) : Ok(authUser.Adapt<UserDTO>());
        }
    }
}
