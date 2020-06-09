using DesafioWM.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWM.Domain.AppServices.Authentication
{
    public interface IAuthenticationApplicationService
    {
        List<AuthUser> GetAllUsers();
        AuthUser GetUser(string userName, string userPsw);
    }
}
