using DesafioWM.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWM.Domain.Repository.Authentication
{
    public interface IUserRepository
    {
        List<AuthUser> GetAll();
        AuthUser Get(string userName, string userPsw);
    }
}
