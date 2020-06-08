using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWM.Domain.Notification.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWM.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notificador;

        protected MainController(INotification notificador)
        {
            _notificador = notificador;
        }

        protected bool OPeracaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OPeracaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = _notificador.ObterNotificacoes().Select(x => x.Mensagem)
            });

        }
    }
}