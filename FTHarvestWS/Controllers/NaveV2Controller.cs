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
    public class NaveV2Controller : ControllerBase
    {
        private readonly NaveRepository _repository;
        public NaveV2Controller(NaveRepository repository) 
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Post([FromBody] IEnumerable<NaveV2> jsonNaves)
        {
            await _repository.InsertV2(jsonNaves);
        }
    }
}
