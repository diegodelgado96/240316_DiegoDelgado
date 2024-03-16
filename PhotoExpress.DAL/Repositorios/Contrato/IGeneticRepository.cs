using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace PhotoExpress.DAL.Repositorios.Contrato
{
    public interface IGeneticRepository<TModel> where TModel : class
    {
        Task<TModel> Get(Expression<Func<TModel, bool>> predicate);
        Task<TModel> Create(TModel model);
        Task<TModel> Update(TModel model);
        Task<TModel> Delete(TModel model);
        Task<IQueryable<TModel>> Search(Expression<Func<TModel, bool>> predicate = null);

    }
}
