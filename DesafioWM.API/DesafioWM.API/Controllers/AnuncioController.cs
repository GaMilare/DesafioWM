using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWM.Domain.AppServices.Anuncio;
using DesafioWM.Domain.Models.Anuncio;
using DesafioWM.Domain.Notification.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWM.API.Controllers
{
    [Route("api/Anuncios")]
    [ApiController]
    public class AnuncioController : MainController
    {
        private readonly IAnuncioApplicationService _anuncioApplicationService;
        public AnuncioController(INotification notificador, 
            IAnuncioApplicationService anuncioApplicationService) : base(notificador)
        {
            _anuncioApplicationService = anuncioApplicationService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AnuncioModel>>> GetAnuncios() => CustomResponse(await _anuncioApplicationService.BuscarTodos());

        [HttpGet("GetById")]
        public async Task<ActionResult<AnuncioModel>> GetAnuncioById(int id) => CustomResponse(await _anuncioApplicationService.BuscarPorId(id));

        [HttpPost]
        public async Task<ActionResult<bool>> InsertAnuncio(AnuncioModel model) => CustomResponse(await _anuncioApplicationService.InserirAnuncio(model));
        
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAnuncio(AnuncioModel model) => CustomResponse(await _anuncioApplicationService.AtualizarAnuncio(model));

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAnuncio(int id) => CustomResponse(await _anuncioApplicationService.DeletarAnuncio(id));
        
        [HttpGet("GetAllWithToken")]
        [Authorize]
        public async Task<ActionResult<List<AnuncioModel>>> GetAnunciosComToken() => CustomResponse(await _anuncioApplicationService.BuscarTodos());

    }

}