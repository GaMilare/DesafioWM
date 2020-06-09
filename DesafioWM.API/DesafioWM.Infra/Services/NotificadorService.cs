using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Domain.Notification.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWM.Infra.Services
{
    public class NotificadorService : INotification
    {
        private readonly List<Note> _notificacoes;

        public NotificadorService()
        {
            this._notificacoes = new List<Note>();
        }

        public void Handle(Note notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Note> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
