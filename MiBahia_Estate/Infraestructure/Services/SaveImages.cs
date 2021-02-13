using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Services
{
    public class SaveImages
    {
        private readonly IHostEnvironment _host;

        public SaveImages(IHostEnvironment host)
        {
            this._host = host;
        }
        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssffff") + Path.GetExtension(imageName);
            var imagePath = Path.Combine(_host.ContentRootPath, "Imagenes", imageName);
            using(var archivo= new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(archivo);
            }

            return imageName;
        }

        public async Task<IEnumerable<string>> SaveImagesRangeAsync(IEnumerable<IFormFile> images)
        {
            List<string> fileNames= new List<string>();
            foreach (IFormFile image in images){

                string imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
                imageName = imageName + DateTime.Now.ToString("yymmssffff") + Path.GetExtension(imageName);
                var imagePath = Path.Combine(_host.ContentRootPath, "Imagenes", imageName);
                    using (var archivo = new FileStream(imagePath, FileMode.Create))
                    {
                        await image.CopyToAsync(archivo);
                    }

                fileNames.Add(imageName);
            }

            return fileNames;
        }
    }
}
