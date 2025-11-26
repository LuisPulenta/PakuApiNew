using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace PakuApiNew.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        [HttpGet("disk-space")]
        public IActionResult GetDiskSpace()
        {
            var drive = new DriveInfo("E"); // Aquí se puede cambiar la letra del disco
            var availableSpace = drive.AvailableFreeSpace;
            var totalSpace = drive.TotalSize;

            var spaceInfo = new
            {
                availableSpace,
                totalSpace
            };

            return Ok(spaceInfo);
        }
    }
}