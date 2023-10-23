using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using System.Threading.Tasks;

namespace Database.Repositories.ComputerInfoRepository
{
	public class ComputerInfoRepository : BaseRepository, IComputerInfoRepository
	{
		public ComputerInfoRepository(LabDbContext context) : base(context) { }
		

		public async Task<int> CreateComputerInfoAsync(ComputerInfoDto ComputerInfo)
		{
			try
			{
				var computerInfo = new ComputerInfo()
				{
					OSVersion = ComputerInfo.OSVersion,
					ComputerName = ComputerInfo.ComputerName,
					SystemFolder = ComputerInfo.SystemFolder,
					CreationTime = ComputerInfo.CreationTime,
					UpdateTime = ComputerInfo.UpdateTime,
					OSName = ComputerInfo.OSName
				};

				await _context.ComputerInfo.AddAsync(computerInfo);
				await _context.SaveChangesAsync();

				return computerInfo.ComputerId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}


		public async Task<ComputerInfo> GetComputerInfoAsync(int computerInfoId)
		{
			try
			{
				var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computerInfo == null)
					throw new Exception($"No computer with such id: {computerInfoId}");

				return computerInfo;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<ComputerInfo>> GetAllComputerAsync()
		{
			try
			{
				var collectionComputer = await _context.ComputerInfo
				.ToListAsync();

				if (collectionComputer.Count == 0)
					throw new Exception($"No computer");

				return collectionComputer;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateComputerInfoAsync(int computerInfoId, ComputerInfoDto ComputerInfo)
		{
			try
			{
				var computer = await _context.ComputerInfo.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computer == null)
					throw new Exception($"No computer with such id = {computerInfoId}.");


				if (computer.OSVersion != ComputerInfo.OSVersion)
					computer.OSVersion = ComputerInfo.OSVersion;

				if (computer.ComputerName != ComputerInfo.ComputerName)
					computer.ComputerName = ComputerInfo.ComputerName;

				if (computer.SystemFolder != ComputerInfo.SystemFolder)
					computer.SystemFolder = ComputerInfo.SystemFolder;

				if (computer.CreationTime != ComputerInfo.CreationTime)
					computer.CreationTime = ComputerInfo.CreationTime;

				if (computer.UpdateTime != ComputerInfo.UpdateTime)
					computer.UpdateTime = ComputerInfo.UpdateTime;

				if (computer.OSName != ComputerInfo.OSName)
					computer.OSName = ComputerInfo.OSName;

				 _context.ComputerInfo.Update(computer);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteComputerInfoAsync(int computerInfoId)
		{
			try
			{
				var computer = await _context.ComputerInfo.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computer == null)
					throw new Exception($"No computer with such id = {computerInfoId}.");

				_context.ComputerInfo.Remove(computer);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<GPU>> GetGPUs(int computerInfoId)
		{
			try
			{
				var computerToGpu = await _context.ComputersToGPU
				.Include(q => q.Gpu)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<GPU> gpus = new List<GPU>();

				foreach (var gpu in computerToGpu)
				{
					gpus.Add(gpu.Gpu);
				}

				return gpus;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<SSD>> GetSSDs(int computerInfoId)
		{
			try
			{
				var computerToSsd = await _context.ComputersToSSD
				.Include(q => q.Ssd)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<SSD> ssds = new List<SSD>();

				foreach (var ssd in computerToSsd)
				{
					ssds.Add(ssd.Ssd);
				}

				return ssds;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<RAM>> GetRAMs(int computerInfoId)
		{
			try
			{
				var computerToRam = await _context.ComputersToRAM
				.Include(q => q.Ram)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<RAM> rams = new List<RAM>();

				foreach (var gpu in computerToRam)
				{
					rams.Add(gpu.Ram);
				}

				return rams;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<CPU> GetCPU(int computerInfoId)
		{
			try
			{
				var cpu = await _context.CPU
					.FirstOrDefaultAsync(c => c.ComputerInfo.ComputerId == computerInfoId);
					
				return cpu;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
