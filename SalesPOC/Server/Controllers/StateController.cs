using Microsoft.AspNetCore.Mvc;
using SalesPOC.Shared;

namespace SalesPOC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;

        public StateController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return States.Abbreviations(); ;
        }
    }
}