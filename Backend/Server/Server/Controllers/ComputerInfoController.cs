using Database.Repositories.ComputerInfoRepository;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ComputerInfoController : Controller
	{
		private readonly IComputerInfoRepository _computerInfoRepository;

		public ComputerInfoController(IComputerInfoRepository computerInfoRepository)
		{
			_computerInfoRepository = computerInfoRepository;
		}

		[HttpGet("{ComputerInfoId}")]
		public async Task<IActionResult> GetComputerInfo(int ComputerInfoId)
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetComputerInfoAsync(ComputerInfoId);
				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost]
		public async Task<IActionResult> CreateComputerInfo([FromBody] ComputerInfoDto computerInfo)
		{
			IActionResult response;
			try
			{
				response = Ok(await _computerInfoRepository.CreateComputerInfoAsync(computerInfo));
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPut("{ComputerInfoId}")]
		public async Task<IActionResult> UpdateComputerInfo(int ComputerInfoId, [FromBody] ComputerInfoDto computerInfo)
		{
			IActionResult response;

			try
			{
				await _computerInfoRepository.UpdateComputerInfoAsync(ComputerInfoId, computerInfo);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpDelete("{ComputerInfoId}")]
		public async Task<IActionResult> DeleteComputerInfo(int ComputerInfoId)
		{
			IActionResult response;

			try
			{
				await _computerInfoRepository.DeleteComputerInfoAsync(ComputerInfoId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("AllComputer")]
		public async Task<IActionResult> GetAllComputer()
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetAllComputerAsync();
				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("GPUs/{ComputerId}")]
		public async Task<IActionResult> GeGPUs(int ComputerId)
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetGPUs(ComputerId);

				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("SSDs/{ComputerId}")]
		public async Task<IActionResult> GetSSDs(int ComputerId)
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetSSDs(ComputerId);

				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("CPU/{ComputerId}")]
		public async Task<IActionResult> GetCpu(int ComputerId)
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetCPU(ComputerId);

				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("RAMs/{ComputerId}")]
		public async Task<IActionResult> GetRAMs(int ComputerId)
		{
			IActionResult response;
			try
			{
				var computerInfo = await _computerInfoRepository.GetRAMs(ComputerId);

				response = Ok(computerInfo);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}
	}
}
