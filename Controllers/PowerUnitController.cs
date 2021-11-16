using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using InnovativeSoftware.Models;
using InnovativeSoftware.Services.Interfaces;
using InnovativeSoftware.Services.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovativeSoftware.Controllers
{
    public class PowerUnitController : BaseApiController
    {
        private readonly IPowerUnitService _powerUnitService;

        public PowerUnitController(IPowerUnitService powerUnitService)
        {
            _powerUnitService = powerUnitService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create(CreatePowerUnitParameters parameters)
        {
            var created = await _powerUnitService.Create(parameters);
            return Created(created.ToString(), created);
        }

        [HttpGet("{powerUnitId:guid}")]
        [ProducesResponseType(typeof(PowerUnit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PowerUnit>> Get(Guid powerUnitId)
        {
            var powerUnit = await _powerUnitService.Get(new GetPowerUnitParameters { PowerUnitId = powerUnitId });
            return Ok(powerUnit);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PowerUnit[]), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PowerUnit>>> List()
        {
            var list = await _powerUnitService.List();
            return Ok(list);
        }

        [HttpPut("{powerUnitId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> Create(Guid powerUnitId, UpdatePowerUnitParameters parameters)
        {
            var updated = await _powerUnitService.Update(powerUnitId, parameters);
            return Ok(updated);
        }
    }
}