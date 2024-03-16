using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoExpress.Model;

namespace PhotoExpress.DAL.Repositorios.Contrato
{
    public interface IEventoRepository:IGeneticRepository<Evento>
    {
        Task<Evento> Register(Evento evento);
    }
}
