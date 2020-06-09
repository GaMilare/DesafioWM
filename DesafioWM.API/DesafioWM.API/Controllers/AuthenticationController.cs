using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWM.API.Security;
using DesafioWM.Domain.AppServices.Authentication;
using DesafioWM.Domain.Notification.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWM.API.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : MainController
    {
        private readonly IAuthenticationApplicationService _authenticationApplicationService;

        public AuthenticationController(INotification notificador, IAuthenticationApplicationService authenticationApplicationService) : base(notificador)
        {
            _authenticationApplicationService = authenticationApplicationService;
        }

        [HttpGet("GetUsers")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //API para disponibilizar as opções de usuários de acesso.
            var allUsers = _authenticationApplicationService.GetAllUsers();

            return CustomResponse(allUsers);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromQuery]string userName, [FromQuery] string Password)
        {
            var user = _authenticationApplicationService.GetUser(userName, Password);

            if (user == null)

                return CustomResponse(false);

            var token = TokenService.GenerateToken(userName);
            return new
            {
                user = user.UserName,
                token
            };
        }
    }
}