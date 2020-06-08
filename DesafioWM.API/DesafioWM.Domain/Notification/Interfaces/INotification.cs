using DesafioWM.Domain.Notification.Notes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWM.Domain.Notification.Interfaces
{
    public interface INotification
    {
        bool TemNotificacao();
        List<Note> ObterNotificacoes();
        void Handle(Note notificacao);
    }
}
