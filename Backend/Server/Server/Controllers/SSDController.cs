using Database.Repositories.SSDRepository;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SSDController : Controller
	{
		private readonly ISSDRepository _ssdRepository;

		public SSDController(ISSDRepository hddRepository)
		{
			_ssdRepository = hddRepository;
		}

		[HttpGet("{SSDId}")]
		public async Task<IActionResult> GetSSD(int SSDId)
		{
			IActionResult response;
			try
			{
				var ssd = await _ssdRepository.GetSSDAsync(SSDId);
				response = Ok(ssd);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost("{SSDId}/{ComputerInfoId}")]
		public async Task<IActionResult> CreateGPU(int SSDId, int ComputerInfoId)
		{
			IActionResult response;

			try
			{
				await _ssdRepository.ComputersToSsd(SSDId, ComputerInfoId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost]
		public async Task<IActionResult> CreateSSD([FromBody] SSDDto ssd)
		{
			IActionResult response;

			try
			{
				response = Ok(await _ssdRepository.CreateSSDAsync(ssd));
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPut("{HDDId}")]
		public async Task<IActionResult> UpdateSSD(int SSDId, [FromBody] SSDDto ssd)
		{
			IActionResult response;

			try
			{
				await _ssdRepository.UpdateSSDAsync(SSDId, ssd);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpDelete("{SSDId}")]
		public async Task<IActionResult> DeleteSSD(int SSDId)
		{
			IActionResult response;

			try
			{
				await _ssdRepository.DeleteSSDAsync(SSDId);
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
