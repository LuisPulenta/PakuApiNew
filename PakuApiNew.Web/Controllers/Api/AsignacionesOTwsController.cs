using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using PakuApiNew.Web.Data;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PakuApiNew.Web.Data.Entities;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesOTwsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public AsignacionesOTwsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        
        }

        [HttpPost]
        [Route("PostAsig")]
        public async Task<IActionResult> PostAsig([FromBody] AsignacionesOTw request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataContext.AsignacionesOTws.Add(request);
            await _dataContext.SaveChangesAsync();
            return Ok(request);
        }
    }
}