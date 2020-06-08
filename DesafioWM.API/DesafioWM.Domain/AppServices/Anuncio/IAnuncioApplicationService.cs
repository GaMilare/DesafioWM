using DesafioWM.Domain.Models.Anuncio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWM.Domain.AppServices.Anuncio
{
    public interface IAnuncioApplicationService
    {
        Task<List<AnuncioModel>> BuscarTodos();
        Task<AnuncioModel> BuscarPorId(int id);
        Task<bool> InserirAnuncio(AnuncioModel model);
        Task<bool> AtualizarAnuncio(AnuncioModel model);
        Task<bool> DeletarAnuncio(int id);
    }
}
