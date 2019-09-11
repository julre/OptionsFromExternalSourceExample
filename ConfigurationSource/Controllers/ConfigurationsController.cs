using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationSource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly MyConfiguration _configuration;
        public ConfigurationsController(IOptionsMonitor<MyConfiguration> options)
        {
            _configuration = options.CurrentValue;
        }
        // GET api/values/5
        [HttpGet]
        public ActionResult<MyConfiguration> Get()
        {
            return _configuration;
        }
    }
}
