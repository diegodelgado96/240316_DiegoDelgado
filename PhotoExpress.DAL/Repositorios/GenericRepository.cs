using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoExpress.DAL.Repositorios.Contrato;
using PhotoExpress.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace PhotoExpress.DAL.Repositorios
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbphotoExpressContext _dbContext;

        public GenericRepository(DbphotoExpressContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;

            }catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TModel> Get(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                TModel modelo = await _dbContext.Set<TModel>().FirstOrDefaultAsync(predicate);
                return modelo;

            }catch 
            {
                throw ;
            }
        }

        public async Task<bool> Update(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Task<IQueryable<TModel>> Search(Expression<Func<TModel, bool>> predicate = null)
        {
            try
            {
                IQueryable<TModel> queryModel = predicate == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(predicate);
                return Task.FromResult(queryModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
