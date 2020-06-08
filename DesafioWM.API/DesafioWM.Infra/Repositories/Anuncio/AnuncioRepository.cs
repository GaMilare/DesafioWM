using DesafioWM.Domain.Entities;
using DesafioWM.Domain.Repository.Anuncio;
using DesafioWM.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioWM.Infra.Repositories.Anuncio
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly DbSet<AnuncioEntity> dbSet;
        private readonly DataContext _db;

        public AnuncioRepository(DataContext db)
        {
            dbSet = db.Set<AnuncioEntity>();
            _db = db;
            
        }

        public async Task Atualizar(AnuncioEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<AnuncioEntity> BuscarPorId(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AnuncioEntity>> BuscarTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public async Task Inserir(AnuncioEntity entity)
        {
            dbSet.Add(entity);
           await SaveChanges();
        }

        public async Task Remover(int id)
        {
            dbSet.Remove(new AnuncioEntity { Id = id });
            await SaveChanges() ;
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
