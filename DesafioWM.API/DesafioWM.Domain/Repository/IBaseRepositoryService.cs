using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWM.Domain.Repository
{
    public interface IBaseRepositoryService<TEntity> : IDisposable where TEntity : class
    {
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(int id);
        Task<TEntity> BuscarPorId(int id);
        Task<List<TEntity>> BuscarTodos();
    }
}
