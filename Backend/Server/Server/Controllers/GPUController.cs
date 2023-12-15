using Database.Repositories.GPURepository;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GPUController : Controller
	{
		private readonly IGPURepository _gpuRepository;

		public GPUController(IGPURepository gpuRepository)
		{
			_gpuRepository = gpuRepository;
		}

		[HttpGet("{GPUId}")]
		public async Task<IActionResult> GetGPU(int GPUId)
		{
			IActionResult response;
			try
			{
				var gpu = await _gpuRepository.GetGPUAsync(GPUId);
				response = Ok(gpu);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost]
		public async Task<IActionResult> CreateGPU([FromBody] GPUDto gpu)
		{
			IActionResult response;

			try
			{
				response = Ok(await _gpuRepository.CreateGPUAsync(gpu));
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost("{GPUId}/{ComputerInfoId}")]
		public async Task<IActionResult> CreateGPU(int GPUId, int ComputerInfoId)
		{
			IActionResult response;

			try
			{
				await _gpuRepository.ComputersToGpu(GPUId, ComputerInfoId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPut("{GPUId}")]
		public async Task<IActionResult> UpdateGPU(int GPUId, [FromBody] GPUDto gpu)
		{
			IActionResult response;

			try
			{
				await _gpuRepository.UpdateGPUAsync(GPUId, gpu);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpDelete("{GPUId}")]
		public async Task<IActionResult> DeleteGPU(int GPUId)
		{
			IActionResult response;

			try
			{
				await _gpuRepository.DeleteGPUAsync(GPUId);
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
