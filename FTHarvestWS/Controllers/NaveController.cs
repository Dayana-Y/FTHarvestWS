using FTHarvestWS.Repositories;
using Microsoft.AspNetCore.Mvc;
using RendimientoPlantaWS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaveController : ControllerBase
    {
        private readonly NaveRepository _repository;
        public NaveController(NaveRepository repository) 
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<Nave> jsonNaves)
        {
            await _repository.Insert(jsonNaves);
        }
    }
}
