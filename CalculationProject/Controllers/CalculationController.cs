using AutoMapper;
using CalculationProject.Api.DTOs;
using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculationProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IMapper _mapper;   

        public CalculationController(ICalculationService calculationService, IMapper mapper)
        {
            _calculationService = calculationService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Calculate([FromBody] CalculationDTO request)
        {
            var calculationResult = _calculationService.Calculate(_mapper.Map<CalculationRequest>(request));
            return Ok(calculationResult);
        }
    }
}
