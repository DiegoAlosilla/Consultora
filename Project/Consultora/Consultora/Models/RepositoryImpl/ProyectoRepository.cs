using Consultora.Data;
using Consultora.Models.Entities;
using Consultora.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultora.Models.RepositoryImpl
{
    public class ProyectoRepository : IProyectoRepository
    {

        private readonly ProyectosDAO _dao;

        public ProyectoRepository(ProyectosDAO repository)
        {
            this._dao = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool Delete(Proyecto t)
        {
            throw new NotImplementedException();
        }

        public List<Proyecto> FindAll()
        {
            throw new NotImplementedException();
        }

        public Proyecto FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Proyecto t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proyecto t)
        {
            throw new NotImplementedException();
        }
    }
}
