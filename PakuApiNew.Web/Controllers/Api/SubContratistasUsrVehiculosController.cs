using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using PakuApiNew.Web.Models;
using System.IO;
using System;
using PakuApiNew.Helpers;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubContratistasUsrVehiculosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _filesHelper;

        public SubContratistasUsrVehiculosController(DataContext dataContext, IFilesHelper filesHelper)
        {
            _dataContext = dataContext;
            _filesHelper = filesHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostWebSubContratistasUsrVehiculo([FromBody] SubContratistasUsrVehiculoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //DNIFrente
            var imageDNIFrenteUrl = string.Empty;
            var stream1 = new MemoryStream(request.DNIFrenteImageArray);
            var guid1 = Guid.NewGuid().ToString();
            var file1 = $"{guid1}.jpg";
            var folder1 = "wwwroot\\images\\MisDatos";
            var fullPath1 = $"~/images/MisDatos/{file1}";
            var response1 = _filesHelper.UploadPhoto(stream1, folder1, file1);

            if (response1)
            {
                imageDNIFrenteUrl = fullPath1;
            }

            //DNIDorso
            var imageDNIDorsoUrl = string.Empty;
            var stream2 = new MemoryStream(request.DNIDorsoImageArray);
            var guid2 = Guid.NewGuid().ToString();
            var file2 = $"{guid2}.jpg";
            var folder2 = "wwwroot\\images\\MisDatos";
            var fullPath2 = $"~/images/MisDatos/{file2}";
            var response2 = _filesHelper.UploadPhoto(stream2, folder2, file2);

            if (response2)
            {
                imageDNIDorsoUrl = fullPath2;
            }

            //CarnetConducir
            var imageCarnetConducirUrl = string.Empty;
            var stream3 = new MemoryStream(request.CarnetConducirImageArray);
            var guid3 = Guid.NewGuid().ToString();
            var file3 = $"{guid3}.jpg";
            var folder3 = "wwwroot\\images\\MisDatos";
            var fullPath3 = $"~/images/MisDatos/{file3}";
            var response3 = _filesHelper.UploadPhoto(stream3, folder3, file3);

            if (response3)
            {
                imageCarnetConducirUrl = fullPath3;
            }



            var subContratistasUsrVehiculo = new SubContratistasUsrVehiculo
            {
                ModeloAnio = request.ModeloAnio,
                UltimaActualizacion = request.UltimaActualizacion,
                CarnetConducir = imageCarnetConducirUrl,
                DNIDorso = imageDNIDorsoUrl,
                DNIFrente = imageDNIFrenteUrl,
                Dominio = request.Dominio,
                FechaObleaGas = request.FechaObleaGas,
                FechaVencCarnet = request.FechaVencCarnet,
                FechaVencVTV = request.FechaVencVTV,
                Gas = request.Gas,
                IdUser = request.IdUser,
                Marca = request.Marca,
                ID = 0
            };


            _dataContext.SubContratistasUsrVehiculos.Add(subContratistasUsrVehiculo);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

              
        [HttpPut("{id}")]
        [Route("PutSubContratistasUsrVehiculo")]
        public async Task<IActionResult> PutSubContratistasUsrVehiculo([FromRoute] int id, [FromBody] SubContratistasUsrVehiculoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.ID)
            {
                return BadRequest();
            }

            SubContratistasUsrVehiculo oldSubContratistasUsrVehiculo = await _dataContext.SubContratistasUsrVehiculos
                .FirstOrDefaultAsync(t => t.ID == request.ID);

            if (oldSubContratistasUsrVehiculo == null)
            {
                return BadRequest("SubContratistasUsrVehiculo no existe.");
            }

            //DNIFrente
            string imageDNIFrenteUrl = oldSubContratistasUsrVehiculo.DNIFrente;
            if (request.DNIFrenteImageArray != null && request.DNIFrenteImageArray.Length > 0)
            {
                var stream1 = new MemoryStream(request.DNIFrenteImageArray);
                var guid1 = Guid.NewGuid().ToString();
                var file1 = $"{guid1}.jpg";
                var folder1 = "wwwroot\\images\\MisDatos";
                var fullPath1 = $"~/images/MisDatos/{file1}";
                var response1 = _filesHelper.UploadPhoto(stream1, folder1, file1);
                if (response1)
                {
                    imageDNIFrenteUrl = fullPath1;
                }
            }

            //DNIDorso
            string imageDNIDorsoUrl = oldSubContratistasUsrVehiculo.DNIDorso;
            if (request.DNIDorsoImageArray != null && request.DNIDorsoImageArray.Length > 0)
            {
                var stream2 = new MemoryStream(request.DNIDorsoImageArray);
                var guid2 = Guid.NewGuid().ToString();
                var file2 = $"{guid2}.jpg";
                var folder2 = "wwwroot\\images\\MisDatos";
                var fullPath2 = $"~/images/MisDatos/{file2}";
                var response2 = _filesHelper.UploadPhoto(stream2, folder2, file2);

                if (response2)
                {
                    imageDNIDorsoUrl = fullPath2;
                }
            }

            //CarnetConducir
            string imageCarnetConducirUrl = oldSubContratistasUsrVehiculo.CarnetConducir;
            if (request.CarnetConducirImageArray != null && request.CarnetConducirImageArray.Length > 0)
            {
                var stream3 = new MemoryStream(request.CarnetConducirImageArray);
                var guid3 = Guid.NewGuid().ToString();
                var file3 = $"{guid3}.jpg";
                var folder3 = "wwwroot\\images\\MisDatos";
                var fullPath3 = $"~/images/MisDatos/{file3}";
                var response3 = _filesHelper.UploadPhoto(stream3, folder3, file3);

                if (response3)
                {
                    imageCarnetConducirUrl = fullPath3;
                }
            }

            oldSubContratistasUsrVehiculo.ModeloAnio = request.ModeloAnio;
            oldSubContratistasUsrVehiculo.UltimaActualizacion = request.UltimaActualizacion;
            oldSubContratistasUsrVehiculo.CarnetConducir = imageCarnetConducirUrl;
            oldSubContratistasUsrVehiculo.DNIDorso = imageDNIDorsoUrl;
            oldSubContratistasUsrVehiculo.DNIFrente = imageDNIFrenteUrl;
            oldSubContratistasUsrVehiculo.Dominio = request.Dominio;
            oldSubContratistasUsrVehiculo.FechaObleaGas = request.FechaObleaGas;
            oldSubContratistasUsrVehiculo.FechaVencCarnet = request.FechaVencCarnet;
            oldSubContratistasUsrVehiculo.FechaVencVTV = request.FechaVencVTV;
            oldSubContratistasUsrVehiculo.Gas = request.Gas;
            oldSubContratistasUsrVehiculo.IdUser = request.IdUser;
            oldSubContratistasUsrVehiculo.Marca = request.Marca;
            


            _dataContext.SubContratistasUsrVehiculos.Update(oldSubContratistasUsrVehiculo);
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpGet("GetSubContratistasUsrVehiculo/{iduser}")]
        public async Task<IActionResult> GetSubContratistasUsrVehiculo(int iduser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            System.Collections.Generic.List<SubContratistasUsrVehiculo> subContratistasUsrVehiculos = await _dataContext.SubContratistasUsrVehiculos
                .Where(o => o.IdUser == iduser)
           .ToListAsync();

            if (subContratistasUsrVehiculos.Count>0)
            {
                return Ok(subContratistasUsrVehiculos[0]);
            }
            else
            {
                return Ok("No hay datos");
            }
        }
    }
}