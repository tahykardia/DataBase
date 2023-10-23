using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Dto;
using System.Threading.Tasks;

namespace Database.Repositories.GPURepository
{
	public class GPURepository : BaseRepository, IGPURepository
	{
		public GPURepository(LabDbContext context) : base(context) { }

		public async Task<int> CreateGPUAsync(GPUDto Gpu)
		{
			try
			{
				var gpu = new GPU()
				{
					Frequency = Gpu.Frequency,
					VolumeMemory = Gpu.VolumeMemory,
					Name = Gpu.Name
				};

				await _context.Gpu.AddAsync(gpu);
				await _context.SaveChangesAsync();

				return gpu.GPUId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<GPU> GetGPUAsync(int GPUId)
		{
			try
			{
				var gpu = await _context.Gpu
				.FirstOrDefaultAsync(c => c.GPUId == GPUId);

				if (gpu == null)
					throw new Exception($"No GPU with such id: {GPUId}");

				return gpu;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateGPUAsync(int GPUId, GPUDto Gpu)
		{
			try
			{
				var gpu = await _context.Gpu.FirstOrDefaultAsync(c => c.GPUId == GPUId);

				if (gpu == null)
					throw new Exception($"No GPU with such id = {GPUId}.");

				if(gpu.Frequency != Gpu.Frequency)
					gpu.Frequency = Gpu.Frequency;

				if (gpu.VolumeMemory != Gpu.VolumeMemory)
					gpu.VolumeMemory = Gpu.VolumeMemory;

				if (gpu.Name != Gpu.Name)
					gpu.Name = Gpu.Name;


				_context.Gpu.Update(gpu);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteGPUAsync(int GPUId)
		{
			try
			{
				var gpu = await _context.Gpu.FirstOrDefaultAsync(c => c.GPUId == GPUId);


				if (gpu == null)
					throw new Exception($"No GPU with such id = {GPUId}.");


				_context.Gpu.Remove(gpu);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<int> ComputersToGpu(int GPUId, int ComputerInfoId)
		{
			var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

			var gpu = await _context.Gpu
				.FirstOrDefaultAsync(c => c.GPUId == GPUId);

			var ComputerToGpu = new ComputersToGPU()
			{
				Gpu = gpu,
				Computer = computerInfo
			};

			await _context.ComputersToGPU.AddAsync(ComputerToGpu);
			await _context.SaveChangesAsync();

			return ComputerToGpu.Id;
		}
	}
}
