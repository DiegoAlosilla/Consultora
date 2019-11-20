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
    public class UsuarioService:IUsuarioService
    {
           private IUsuarioRepository usuarioRepository;

            public UsuarioService()
            {
                this.usuarioRepository = new UsuarioRepository();
            }

            public bool Delete(int? id)
            {
                return usuarioRepository.Delete(id);
            }

        public List<Usuario> FindAll()
            {
                return usuarioRepository.FindAll();
            }

            public Usuario FindById(int? id)
            {
                return usuarioRepository.FindById(id);
            }

            public bool Save(Usuario t)
            {
                return usuarioRepository.Save(t);
            }
            public bool Update(Usuario t)
            {
                return usuarioRepository.Update(t);
            }

    }
    }
