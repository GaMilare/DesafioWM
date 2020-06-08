using DesafioWM.Domain.AppServices.Anuncio;
using DesafioWM.Domain.Entities;
using DesafioWM.Domain.Models.Anuncio;
using DesafioWM.Domain.Repository.Anuncio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWM.ApplicationService
{
    public class AnuncioApplicationService : IAnuncioApplicationService
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public AnuncioApplicationService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public async Task<List<AnuncioModel>> BuscarTodos()
        {
            var result = new List<AnuncioModel>();

            //busca na service de banco
            var response = await _anuncioRepository.BuscarTodos();

            result = FillResultModel(response);

            return result;
        }

        public async Task<AnuncioModel> BuscarPorId(int id)
        {
            var response = await _anuncioRepository.BuscarPorId(id);

            var result = FillResultModel(response);

            return result.FirstOrDefault();
        }

        public async Task<bool> InserirAnuncio(AnuncioModel model)
        {

            var newAnuncio = FillRequestModel(model);

            await _anuncioRepository.Inserir(newAnuncio);
            return true;
        }

        public async Task<bool> AtualizarAnuncio(AnuncioModel model)
        {
            var newAnuncio = FillRequestModel(model);
            return true;
        }
        public async Task<bool> DeletarAnuncio(int id)
        {

            return true;
        }
        private List<AnuncioModel> FillResultModel(List<AnuncioEntity> response)
        {
            var result = new List<AnuncioModel>();

            foreach (var anuncio in response)
            {
                var newAnuncio = new AnuncioModel()
                {
                    Ano = anuncio.Ano,
                    Id = anuncio.Id,
                    Marca = anuncio.Marca,
                    Modelo = anuncio.Modelo,
                    Observacao = anuncio.Observacao,
                    Quilometragem = anuncio.Quilometragem,
                    Versao = anuncio.Versao
                };

                result.Add(newAnuncio);
            }

            return result;
        }

        private List<AnuncioModel> FillResultModel(AnuncioEntity anuncio)
        {
            var result = new List<AnuncioModel>();

            var newAnuncio = new AnuncioModel()
            {
                Ano = anuncio.Ano,
                Id = anuncio.Id,
                Marca = anuncio.Marca,
                Modelo = anuncio.Modelo,
                Observacao = anuncio.Observacao,
                Quilometragem = anuncio.Quilometragem,
                Versao = anuncio.Versao
            };

            result.Add(newAnuncio);

            return result;
        }
        private AnuncioEntity FillRequestModel(AnuncioModel model)
        {
            return new AnuncioEntity()
            {
                Ano = model.Ano,
                Id = model.Id,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Observacao = model.Observacao,
                Quilometragem = model.Quilometragem,
                Versao = model.Versao
            };
        }
    }
}
