using dbWeb.Data;
using dbWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbWeb.Controllers
{
    public class Crud<T> : Controller, IDisposable where T : BaseModel
    {
        private readonly DbContext _context;

        public Crud(DatabaseAPIContext dbContext)
        {
            this._context = dbContext;
        }

        public Crud()
        {
            _context = new DbContext(new DbContextOptions<DbContext>());
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Set<T>().ToListAsync());
        }

        public virtual void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var dbEntity = _context.Set<T>().Find(entity.Id);
            if (dbEntity == null)
            {
                throw new NotImplementedException("Объект не найден.");
            }

            _context.Entry(entity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
