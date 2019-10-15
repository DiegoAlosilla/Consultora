using ConsultoraAPI.Data;
using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Models.RepositoryImpl
{
    public class ProyectoRepository : IProyectoRepository
    {

        private readonly ProyectosDAO dao;

        public ProyectoRepository()
        {
            this.dao = new ProyectosDAO();
        }

        public bool Delete(int? id)
        {
            try
            {
                dao.DeleteProyecto(id);
            }
            catch(Exception)
            {
                return false;
            }
            return true;

        }

        public List<Proyecto> FindAll()
        {
            return dao.GetAll().ToList();
        }

        public Proyecto FindById(int? id)
        {
            return dao.GetById(id);
        }

        public bool Save(Proyecto t)
        {
            try
            {
                dao.AddProyect(t);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Proyecto t)
        {

            try
            {
                dao.Update(t);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
