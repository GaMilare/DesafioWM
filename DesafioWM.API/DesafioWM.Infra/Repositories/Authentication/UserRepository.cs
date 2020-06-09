using DesafioWM.Domain.Models.Authentication;
using DesafioWM.Domain.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWM.Infra.Repositories.Authentication
{
    public class UserRepository : IUserRepository
    {
        public List<AuthUser> GetAll()
        {
            //Vou manter Mockada a informação para não criar outra tabela alem da proposta no desafio ([teste_webmotors].[dbo].[Anuncios])
            var users = new List<AuthUser>
            {
                new AuthUser(1, "WebMotors", "123456"),
                new AuthUser(2, "Gabriel", "123456")
            };
            return users.ToList();
        }

        public AuthUser Get(string userName, string userPsw)
        {
            var users = GetAll();

            return users.Where(x => x.UserName.ToLower() == userName.ToLower() && x.UserPsw == userPsw).FirstOrDefault();
        }
    }
}
