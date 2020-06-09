using DesafioWM.Domain.Entities;
using DesafioWM.Domain.Repository.Anuncio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWM.Tests.Mock
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private new List<AnuncioEntity> dbSet;
        public AnuncioRepository()
        {
        }

        public async Task Atualizar(AnuncioEntity entity)
        {
            var entityToUpdate = dbSet.FirstOrDefault(_ => _.Id == entity.Id);
            if(entityToUpdate != null)
            {
                //Atualiza o valor da entidade achada com a entidade passada
            }
        }

        public async Task<AnuncioEntity> BuscarPorId(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<AnuncioEntity>> BuscarTodos()
        {
            return dbSet.ToList();
        }

        public void Dispose()
        {
            //_db?.Dispose();
        }

        public async Task Inserir(AnuncioEntity entity)
        {
            dbSet.Add(entity);
        }

        public async Task Remover(int id)
        {
            dbSet.Remove(new AnuncioEntity { Id = id });
        }

        public async Task<int> SaveChanges()
        {
            return 1;
        }
    }
}
