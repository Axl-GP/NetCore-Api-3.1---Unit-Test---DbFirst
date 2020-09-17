using BahiaRealEstate.Models;
using BahiaRealEstate.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BahiaRealEstate_Test
{
    [TestClass]
    public class PropiedadTesting
    {
        
        private readonly PropiedadCrud propiedad;
       

        
        public PropiedadTesting()
        {
            
           propiedad = new PropiedadCrud();
            

        }


        [TestMethod]
        public async Task getPropiedades()
        {
            var resultado = await propiedad.getPropiedades();
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedad()
        {
            var resultado = await propiedad.getPropiedad(1);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadCuartos()
        {
            var resultado = await propiedad.getPropiedadesCuartos(3);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadesDuchas()
        {
            var resultado = await propiedad.getPropiedadesDuchas(2);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadesPorDuchaCuarto()
        {
            var resultado = await propiedad.getPropiedadesDuchaCuarto(2, 3);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadesPorDuchaDestacada()
        {
            var resultado = await propiedad.getPropiedadesDuchaDestacado(2, true);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadesPorCuartosDestacado()
        {
            var resultado = await propiedad.getPropiedadesCuartoDestacado(3, true);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task getPropiedadesPorCuartoDuchaDestacado()
        {
            var resultado = await propiedad.getPropiedadesCuartoDuchaDestacado(3, 2, true);
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public async Task addPropiedad()
        {

            Propiedad casa = new Propiedad();
            casa.Id = 3;
            casa.Titulo = "Vendo casa en Alabama";
            casa.Descripcion = "4 cuartos, 3 duchas y de 2 niveles, financiamiento disponible";
            casa.Cuartos = 5;
            casa.Ducha = 4;
            casa.Area = (decimal)188.53;
            casa.TipoInmuebleId = 1;


            PropiedadDireccion direccion = new PropiedadDireccion();
            direccion.Id = 3;
            direccion.Direccion = "Alabama";
            direccion.IdPropiedad = 3;

            PropiedadPrecio precio = new PropiedadPrecio();
            precio.Id =3;
            precio.Monedaid = 2;
            precio.Precio = 500000;
            precio.NotaPrecio = "Financiamiento a 10 años";

            PropiedadFoto foto = new PropiedadFoto();
            foto.Id = 4;

            foto.Propiedadid = 3;
            foto.Foto = "C:\\Users\\wmlgu\\Downloads\\F.jpg";
            foto.Propiedadid = foto.Propiedad.Id;
            

            

            List<PropiedadFoto> fotoCollection = new List<PropiedadFoto>();



            fotoCollection.Add(foto);


            var resultado = await propiedad.AddPropiedad(casa, precio, direccion, fotoCollection);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task editPropiedad()
        {
            var resultado = await propiedad.getPropiedad(1);
            resultado.Titulo = "Vendo apartamento en naco";
            resultado.Descripcion = "Perfectamente ubicado, 4 habitaciones, 3 duchas, cuarto de servicio, 2 parqueos.";
            resultado.Caliente = true;
            resultado.Ducha = 3;
            resultado.Cuartos = 4;
            resultado.Area = 190;
            resultado.Destacado = true;
            resultado.CuartoServicio = true;
            resultado.TipoInmuebleId = 1;

            resultado.PropiedadDireccion.Direccion = "Ensanche Naco";

            resultado.PropiedadPrecio.Precio = 4500000;
            resultado.PropiedadPrecio.NotaPrecio = "No hay financiamiento";

        }

        [TestMethod]
        public async Task deletePropiedad()
        {
            var resultado = await propiedad.DeletePropiedad(2);
            Assert.IsTrue(resultado);
        }

    }
}
