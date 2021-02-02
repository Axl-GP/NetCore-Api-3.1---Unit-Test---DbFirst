using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Services
{
    public class CargarFotos
    {
        private readonly IHostEnvironment _host;

        public CargarFotos(IHostEnvironment host)
        {
            this._host = host;
        }
        public async Task<string> GuardarImagen(IFormFile imagen)
        {
            string imagenNombre = new string(Path.GetFileNameWithoutExtension(imagen.FileName).Take(10).ToArray()).Replace(' ', '-');
            imagenNombre = imagenNombre + DateTime.Now.ToString("yymmssffff") + Path.GetExtension(imagenNombre);
            var imagenRuta = Path.Combine(_host.ContentRootPath, "Imagenes", imagenNombre);
            using(var archivo= new FileStream(imagenRuta, FileMode.Create))
            {
                await imagen.CopyToAsync(archivo);
            }

            return imagenNombre;
        }
    }
}
