using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Repositories.GPURepository
{
	public class ComputersToGPURepository : BaseRepository, IComputersToGPURepository
	{
		public ComputersToGPURepository(LabDbContext context) : base(context) { }

		public async Task CreateComputersToGPUAsync(GPU Gpu, ComputerInfo computer)
		{
			await _context.ComputersToGPU.AddAsync(new ComputersToGPU()
			{
				Computer = computer,
				Gpu = Gpu
			});

			await _context.SaveChangesAsync();
		}

		public async Task<ComputersToGPU> GetComputersToGPUAsync(int GPUId, int ComputerId)
		{
			var GPU = await _context.Gpu
				.FirstOrDefaultAsync(c => c.GPUId == GPUId);

			var Computer = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerId);

			if (GPU == null || Computer == null)
				throw new Exception($"No GPU or computer with such id: {GPUId}, {ComputerId}");

			return new ComputersToGPU()
			{
				Computer = Computer,
				Gpu = GPU
			};
		}

		public async Task UpdateComputersToGPUAsync(int GPUId,  ComputersToGPU ComputerInfo)
		{

			var computerInfo = await _context.ComputersToGPU
				.Include(q => q.Gpu)
				.FirstOrDefaultAsync(c => c.Gpu.GPUId == GPUId);

			if (computerInfo == null)
				throw new Exception($"No  GPU with such id =  {GPUId}.");

			_context.ComputersToGPU.Update(computerInfo);
			await _context.SaveChangesAsync();

		}

		public async Task DeleteComputersToGPUAsync(int GPUId)
		{
			var gpu = await _context.ComputersToGPU.FirstOrDefaultAsync(c => c.Gpu.GPUId == GPUId);

			if (gpu == null)
				throw new Exception($"No GPU with such id = {GPUId}.");

			_context.ComputersToGPU.Remove(gpu);
			await _context.SaveChangesAsync();
		}
	}
}
