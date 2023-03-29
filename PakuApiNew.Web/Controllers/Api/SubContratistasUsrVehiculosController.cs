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
            string imageDNIFrenteUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
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
            string imageDNIDorsoUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
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
            string imageCarnetConducirUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
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
            

            //LinkVtv
            string imageLinkVtvUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream4 = new MemoryStream(request.LinkVtvImageArray);
                var guid4 = Guid.NewGuid().ToString();
                var file4 = $"{guid4}.jpg";
                var folder4 = "wwwroot\\images\\MisDatos";
                var fullPath4 = $"~/images/MisDatos/{file4}";
                var response4 = _filesHelper.UploadPhoto(stream4, folder4, file4);

                if (response4)
                {
                    imageLinkVtvUrl = fullPath4;
                }
            }

            //LinkObleaGas
            string imageLinkObleaGasUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream5 = new MemoryStream(request.LinkObleaGasImageArray);
                var guid5 = Guid.NewGuid().ToString();
                var file5 = $"{guid5}.jpg";
                var folder5 = "wwwroot\\images\\MisDatos";
                var fullPath5 = $"~/images/MisDatos/{file5}";
                var response5 = _filesHelper.UploadPhoto(stream5, folder5, file5);

                if (response5)
                {
                    imageLinkObleaGasUrl = fullPath5;
                }
            }


            //LinkPolizaSeguro
            string imageLinkPolizaSeguroUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream6 = new MemoryStream(request.LinkPolizaSeguroImageArray);
                var guid6 = Guid.NewGuid().ToString();
                var file6 = $"{guid6}.pdf";
                var folder6 = "wwwroot\\images\\MisDatos";
                var fullPath6 = $"~/images/MisDatos/{file6}";
                var response6 = _filesHelper.UploadPhoto(stream6, folder6, file6);

                if (response6)
                {
                    imageLinkPolizaSeguroUrl = fullPath6;
                }
            }

            //LinkCedulaSeguro
            string imageLinkCedulaSeguroUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream7 = new MemoryStream(request.LinkCedulaImageArray);
                var guid7 = Guid.NewGuid().ToString();
                var file7 = $"{guid7}.pdf";
                var folder7 = "wwwroot\\images\\MisDatos";
                var fullPath7 = $"~/images/MisDatos/{file7}";
                var response7 = _filesHelper.UploadPhoto(stream7, folder7, file7);

                if (response7)
                {
                    imageLinkCedulaSeguroUrl = fullPath7;
                }
            }

            //LinkAntecedentes
            string imageLinkAntecedentesSeguroUrl = "";
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream8 = new MemoryStream(request.LinkAntecedentesImageArray);
                var guid8 = Guid.NewGuid().ToString();
                var file8 = $"{guid8}.pdf";
                var folder8 = "wwwroot\\images\\MisDatos";
                var fullPath8 = $"~/images/MisDatos/{file8}";
                var response8 = _filesHelper.UploadPhoto(stream8, folder8, file8);

                if (response8)
                {
                    imageLinkAntecedentesSeguroUrl = fullPath8;
                }
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
                ID = 0,
                NroPolizaSeguro=request.NroPolizaSeguro,
                FechaVencPoliza=request.FechaVencPoliza,
                Compania=request.Compania,
                LinkVtv= imageLinkVtvUrl,
                LinkObleaGas=imageLinkObleaGasUrl,
                LinkPolizaSeguro=imageLinkPolizaSeguroUrl,
                LinkCedula=imageLinkCedulaSeguroUrl,
                LinkAntecedentes=imageLinkAntecedentesSeguroUrl
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


            //LinkVtv
            string imageLinkVtvUrl = oldSubContratistasUsrVehiculo.LinkVtv;
            if (request.LinkVtvImageArray != null && request.LinkVtvImageArray.Length > 0)
            {
                var stream4 = new MemoryStream(request.LinkVtvImageArray);
                var guid4 = Guid.NewGuid().ToString();
                var file4 = $"{guid4}.jpg";
                var folder4 = "wwwroot\\images\\MisDatos";
                var fullPath4 = $"~/images/MisDatos/{file4}";
                var response4 = _filesHelper.UploadPhoto(stream4, folder4, file4);

                if (response4)
                {
                    imageLinkVtvUrl = fullPath4;
                }
            }

            //LinkObleaGas
            string imageLinkObleaGasUrl = oldSubContratistasUsrVehiculo.LinkObleaGas;
            if (request.LinkObleaGasImageArray != null && request.LinkObleaGasImageArray.Length > 0)
            {
                var stream5 = new MemoryStream(request.LinkObleaGasImageArray);
                var guid5 = Guid.NewGuid().ToString();
                var file5 = $"{guid5}.jpg";
                var folder5 = "wwwroot\\images\\MisDatos";
                var fullPath5 = $"~/images/MisDatos/{file5}";
                var response5 = _filesHelper.UploadPhoto(stream5, folder5, file5);

                if (response5)
                {
                    imageLinkObleaGasUrl = fullPath5;
                }
            }

            //LinkPolizaSeguro
            string imageLinkPolizaSeguroUrl = oldSubContratistasUsrVehiculo.LinkPolizaSeguro;
            if (request.LinkPolizaSeguroImageArray != null && request.LinkPolizaSeguroImageArray.Length > 0)
            {
                var stream6 = new MemoryStream(request.LinkPolizaSeguroImageArray);
                var guid6 = Guid.NewGuid().ToString();
                var file6 = $"{guid6}.pdf";
                var folder6 = "wwwroot\\images\\MisDatos";
                var fullPath6 = $"~/images/MisDatos/{file6}";
                var response6 = _filesHelper.UploadPhoto(stream6, folder6, file6);

                if (response6)
                {
                    imageLinkPolizaSeguroUrl = fullPath6;
                }
            }

            //LinkCedulaSeguro
            string imageLinkCedulaSeguroUrl = oldSubContratistasUsrVehiculo.LinkCedula;
            if (request.LinkCedulaImageArray != null && request.LinkCedulaImageArray.Length > 0)
            {
                var stream7 = new MemoryStream(request.LinkCedulaImageArray);
                var guid7 = Guid.NewGuid().ToString();
                var file7 = $"{guid7}.pdf";
                var folder7 = "wwwroot\\images\\MisDatos";
                var fullPath7 = $"~/images/MisDatos/{file7}";
                var response7 = _filesHelper.UploadPhoto(stream7, folder7, file7);

                if (response7)
                {
                    imageLinkCedulaSeguroUrl = fullPath7;
                }
            }

            //LinkAntecedentes
            string imageLinkAntecedentesSeguroUrl = oldSubContratistasUsrVehiculo.LinkAntecedentes;
            if (request.LinkAntecedentesImageArray != null && request.LinkAntecedentesImageArray.Length > 0)
            {
                var stream8 = new MemoryStream(request.LinkAntecedentesImageArray);
                var guid8 = Guid.NewGuid().ToString();
                var file8 = $"{guid8}.pdf";
                var folder8 = "wwwroot\\images\\MisDatos";
                var fullPath8 = $"~/images/MisDatos/{file8}";
                var response8 = _filesHelper.UploadPhoto(stream8, folder8, file8);

                if (response8)
                {
                    imageLinkAntecedentesSeguroUrl = fullPath8;
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
            oldSubContratistasUsrVehiculo.NroPolizaSeguro = request.NroPolizaSeguro;
            oldSubContratistasUsrVehiculo.FechaVencPoliza = request.FechaVencPoliza;
            oldSubContratistasUsrVehiculo.Compania = request.Compania;
            oldSubContratistasUsrVehiculo.LinkVtv = imageLinkVtvUrl;
            oldSubContratistasUsrVehiculo.LinkObleaGas = imageLinkObleaGasUrl;
            oldSubContratistasUsrVehiculo.LinkPolizaSeguro = imageLinkPolizaSeguroUrl;
            oldSubContratistasUsrVehiculo.LinkCedula = imageLinkCedulaSeguroUrl;
            oldSubContratistasUsrVehiculo.LinkAntecedentes = imageLinkAntecedentesSeguroUrl;



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
                return Ok();
            }
        }
    }
}