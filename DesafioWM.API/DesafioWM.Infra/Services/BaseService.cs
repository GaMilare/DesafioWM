using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Domain.Notification.Notes;
using System.ComponentModel.DataAnnotations;

namespace DesafioWM.Infra.Services
{
    public abstract class BaseService
    {
        INotification _notification;

        public BaseService(INotification notification)
        {
            _notification = notification;
        }

        protected void Notificar(string mensagem)
        {
            _notification.Handle(new Note(mensagem));
        }

    }
}
