using Microsoft.AspNetCore.Mvc;
using SalesPOC.Shared;

namespace SalesPOC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PCMController : ControllerBase
    {
        private readonly ILogger<PCMController> _logger;

        public PCMController(ILogger<PCMController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] PCM = new string[3];

            PCM[0] = "Email";
            PCM[1] = "Phone";
            PCM[2] = "SMS";

            return PCM;
        }
    }
}