using System;
using Xunit;
using Moq;
using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Data;
using System.Threading.Tasks;
using ConsultoraAPI.Models.Repository;
using System.Collections.Generic;

namespace XUnitTestConsultoraAPI
{
    public class UnitTestConsultoraAPI
    {
        [Fact]
        public void TestInsertProyecto()
        {
            Proyecto proyecto = new Proyecto()
            {
                Titulo = "Promela",
                Descripcion = "Lenguaje de programacion concurrente"
            };
            var mock = new Mock<IProyectoRepository>();
            mock.Setup(x => x.Save(proyecto)).Returns(true);
            var  result =  mock.Object.Save(proyecto);
            Assert.True(result);
        }

        [Fact]
        public void TestUpdateProyecto()
        {
            Proyecto proyecto = new Proyecto()
            {
                Titulo = "Promela",
                Descripcion = "Lenguaje de programacion concurrente"
            };
            var mock = new Mock<IProyectoRepository>();
            mock.Setup(x => x.Update(proyecto)).Returns(true);
            var result = mock.Object.Update(proyecto);
            Assert.True(result);
        }

        [Fact]
        public void TestDeleteProyecto()
        {
            Proyecto proyecto = new Proyecto()
            {
                Titulo = "Promela",
                Descripcion = "Lenguaje de programacion concurrente"
            };
            var mock = new Mock<IProyectoRepository>();
            mock.Setup(x => x.Delete(proyecto)).Returns(true);
            var result = mock.Object.Delete(proyecto);
            Assert.True(result);
        }


        [Fact]
        public void TestGetAllProyecto()
        {
            var listProyectos = new List<Proyecto>
            {
                new Proyecto()
                {
                    Titulo = "Promela",
                    Descripcion = "Lenguaje de programacion concurrente"
                }
            };

            var mock = new Mock<IProyectoRepository>();
            mock.Setup(x => x.FindAll()).Returns(listProyectos);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void TestGetProyectoById()
        {
            Proyecto proyecto = new Proyecto()
            {
                Id = 1,
                Titulo = "Promela",
                Descripcion = "Lenguaje de programacion concurrente"
            };

            var id = proyecto.Id;
            var mock = new Mock<IProyectoRepository>();
            mock.Setup(x => x.FindById(id)).Returns(proyecto);
            var result = mock.Object.FindById(id);
            Assert.NotNull(result);
        }
    }
}
