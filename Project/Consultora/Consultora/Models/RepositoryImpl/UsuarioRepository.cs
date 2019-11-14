using ConsultoraAPI.Data;
using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Models.RepositoryImpl
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuariosDAO dao;

        public UsuarioRepository()
        {
            this.dao = new UsuariosDAO();
        }

        public bool Delete(int? id)
        {
            try
            {
                dao.DeleteUsuario(id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public List<Usuario> FindAll()
        {
            return dao.GetAll().ToList();
        }

        public Usuario FindById(int? id)
        {
            return dao.GetById(id);
        }

        public bool Save(Usuario t)
        {
            try
            {
                dao.AddUsuario(t);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Usuario t)
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
