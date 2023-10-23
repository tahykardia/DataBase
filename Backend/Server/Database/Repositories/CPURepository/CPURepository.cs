using Dto;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Repositories.CPURepository
{
	public class CPURepository : BaseRepository, ICPURepository
	{
		public CPURepository(LabDbContext context) : base(context) { }

		public async Task<int> CreateCPUAsync(CPUDto Cpu, int ComputerInfoId)
		{
			try
			{
				var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

				var cpu = new CPU()
				{
					Frequency = Cpu.Frequency,
					Bitness = Cpu.Bitness,
					CacheMemory = Cpu.CacheMemory,
					Name = Cpu.Name,
					NumberOfCores = Cpu.NumberOfCores,
					ComputerInfo = computerInfo
				};

				await _context.CPU.AddAsync(cpu);
				await _context.SaveChangesAsync();

				return cpu.CPUId;
			}

			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<CPU> GetCPUAsync(int CPUId)
		{
			try
			{
				var cpu = await _context.CPU
				.FirstOrDefaultAsync(c => c.CPUId == CPUId);

				if (cpu == null)
					throw new Exception($"No CPU with such id: {CPUId}");

				return cpu;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task UpdateCPUAsync(int CPUId, CPUDto Cpu)
		{

			try
			{
				var cpu = await _context.CPU.FirstOrDefaultAsync(c => c.CPUId == CPUId);

				if (cpu == null)
					throw new Exception($"No CPU with such id = {CPUId}.");

				if (cpu.Frequency != Cpu.Frequency)
					cpu.Frequency = Cpu.Frequency;
				
				if (cpu.Bitness != Cpu.Bitness)
					cpu.Bitness = Cpu.Bitness;
				
				if (cpu.CacheMemory != Cpu.CacheMemory)
					cpu.CacheMemory = Cpu.CacheMemory;
				
				if (cpu.Name != Cpu.Name)				
					cpu.Name = Cpu.Name;
				
				if (cpu.NumberOfCores != Cpu.NumberOfCores)			
					cpu.NumberOfCores = Cpu.NumberOfCores;
				

				_context.CPU.Update(cpu);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
			
		}

		public async Task DeleteCPUAsync(int CPUId)
		{
			try
			{
				var cpu = await _context.CPU.FirstOrDefaultAsync(c => c.CPUId == CPUId);

				if (cpu == null)
					throw new Exception($"No CPU with such id = {CPUId}.");

				_context.CPU.Remove(cpu);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
