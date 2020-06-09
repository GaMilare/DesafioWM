using DesafioWM.Domain.AppServices.Authentication;
using DesafioWM.Domain.Models.Authentication;
using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Domain.Repository.Authentication;
using DesafioWM.Infra.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWM.ApplicationService
{
    public class AuthenticationApplicationService : BaseService, IAuthenticationApplicationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationApplicationService(INotification notification, IUserRepository userRepository) : base(notification)
        {
            _userRepository = userRepository;
        }

        public List<AuthUser> GetAllUsers() => _userRepository.GetAll();

        public AuthUser GetUser(string userName, string userPsw)
        {
            var user = _userRepository.Get(userName, userPsw);

            if (user == null)
            {
                Notificar("Não foi possivel achar o usuário informado, por favor verifique os dados preenchidos.");
            }

            return user;
        }
    }
}
