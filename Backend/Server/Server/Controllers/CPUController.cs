using Database.Repositories.CPURepository;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CPUController : Controller
    {
        private readonly ICPURepository _cpuRepository;

        public CPUController(ICPURepository cpuRepository)
        {
            _cpuRepository = cpuRepository;
        }

        [HttpGet("{CPUId}")]
        public async Task<IActionResult> GetCPU(int CPUId)
        {
            IActionResult response;
            try
            {
                var cpuDto = await _cpuRepository.GetCPUAsync(CPUId);
                response = Ok(cpuDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost("{ComputerInfoId}")]
        public async Task<IActionResult> CreateCPU([FromBody] CPUDto cpu, int ComputerInfoId)
        {
            IActionResult response;

            try
            {
                await _cpuRepository.CreateCPUAsync(cpu, ComputerInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{CPUId}")]
        public async Task<IActionResult> UpdateCPU(int CPUId, [FromBody] CPUDto cpu)
        {
            IActionResult response;

            try
            {
                await _cpuRepository.UpdateCPUAsync(CPUId, cpu);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{CPUId}")]
        public async Task<IActionResult> DeleteCPU(int CPUId)
        {
            IActionResult response;

            try
            {
                await _cpuRepository.DeleteCPUAsync(CPUId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}