
using DesafioWM.ApplicationService;
using DesafioWM.Domain.AppServices.Anuncio;
using DesafioWM.Domain.Models.Anuncio;
using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Domain.Repository.Anuncio;
using DesafioWM.Infra.Services;
using DesafioWM.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioWM.Tests
{
    [TestClass]
    public class AnuncioTests
    {
        /// <summary>
        /// TODO - MOCKAR AS CLASSES ESPELHAS.
        /// </summary>

        //private IAnuncioApplicationService _anuncioApplicationService;
        //private IAnuncioRepository _db;
        //private INotification _notification;

        public AnuncioTests()
        {

        }

        [TestInitialize]
        public void Initialize()
        {
            //_db = new AnuncioRepository();
            //_notification = new NotificadorService();
            //_anuncioApplicationService = new AnuncioApplicationService(_db, _notification);
        }

        [TestMethod]
        public void Anuncio_post()
        {
            //    var json = new AnuncioModel()
            //    {
            //        Id = 0,
            //        Marca = "Honda",
            //        Modelo = "Civic",
            //        Versao = "2.0",
            //        Ano = 2019,
            //        Quilometragem = 100,
            //        Observacao = "Documento pago"
            //    };

            //    var result = _anuncioApplicationService.InserirAnuncio(json).Result;

            //    Assert.IsTrue(result);
        }

        [TestMethod]
        public void Anuncio_put()
        {
            //var result = _anuncioApplicationService.BuscarTodos().Result;

            //Assert.IsTrue(result.Count > 0 || result != null);
        }

        [TestMethod]
        public void Anuncio_getAll()
        {
            //var result = _anuncioApplicationService.BuscarTodos().Result;

            //Assert.IsTrue(result.Count > 0 || result != null);
        }
    }
}
