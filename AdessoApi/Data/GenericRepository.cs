using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdessoApi.Data
{
    public class GenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _dbSet.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the entity by Id", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ServiceResponse<T?>> AddAsync(T entity)
        {
            ServiceResponse<T?> responseDto = new();

            try
            {

                await _dbSet.AddAsync(entity);

                await _context.SaveChangesAsync();

                responseDto.SetSuccessAdd(entity.GetType().Name, entity, null);

            }
            catch (Exception ex)
            {
                responseDto.SetErrorAdd(entity.GetType().Name, ex.Message);
            }

            return responseDto;
        }

        public async Task<ServiceResponse<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities)
        {
            ServiceResponse<IEnumerable<T>> responseDto = new();

            try
            {
                await _dbSet.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                responseDto.SetSuccessAdd(entities.FirstOrDefault()?.GetType().Name ?? "Entity", entities, null);
            }
            catch (Exception ex)
            {
                responseDto.SetErrorAdd("Entities", ex.Message);
            }

            return responseDto;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving changes to the database", ex);
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(x => !x.IsDeleted).Where(predicate);
        }
    }
}
