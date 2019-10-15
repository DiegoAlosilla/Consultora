using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Models.Repository;
using ConsultoraAPI.Models.RepositoryImpl;
using ConsultoraAPI.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Models.ServiceImpl
{
    public class ProyectoService : IProyectoService
    {
        private IProyectoRepository proyectoRepository;

        public ProyectoService()
        {
            this.proyectoRepository = new ProyectoRepository();
        }

        public bool Delete(int? id)
        {
            return proyectoRepository.Delete(id);
        }

        public List<Proyecto> FindAll()
        {
            return proyectoRepository.FindAll();
        }

        public Proyecto FindById(int? id)
        {
            return proyectoRepository.FindById(id);
        }

        public bool Save(Proyecto t)
        {
            return proyectoRepository.Save(t);
        }

        public bool Update(Proyecto t)
        {
            return proyectoRepository.Update(t);
        }
    }
}
