using Dto;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Repositories.SSDRepository
{
	public class SSDRepository : BaseRepository, ISSDRepository
	{
		public SSDRepository(LabDbContext context) : base(context) { }

		public async Task<int> CreateSSDAsync(SSDDto Ssd)
		{
			try
			{
				var ssd = new SSD()
				{
					Amount = Ssd.Amount,
					MaxSpeedWrite = Ssd.MaxSpeedWrite,
					MaxSpeedRead = Ssd.MaxSpeedRead,
					Name = Ssd.Name
				};

				await _context.Ssd.AddAsync(ssd);
				await _context.SaveChangesAsync();

				return ssd.SSDId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<SSD> GetSSDAsync(int SSDId)
		{
			try
			{
				var ssd = await _context.Ssd
								.FirstOrDefaultAsync(c => c.SSDId == SSDId);

				if (ssd == null)
					throw new Exception($"No SSD with such id: {SSDId}");

				return ssd;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateSSDAsync(int SSDId, SSDDto Ssd)
		{
			try
			{
				var ssd = await _context.Ssd.FirstOrDefaultAsync(c => c.SSDId == SSDId);

				if (ssd == null)
					throw new Exception($"No SSD with such id = {SSDId}.");

				if (ssd.Amount != Ssd.Amount)
					ssd.Amount = Ssd.Amount;

				if (ssd.MaxSpeedWrite != Ssd.MaxSpeedWrite)
					ssd.MaxSpeedWrite = Ssd.MaxSpeedWrite;

				if (ssd.MaxSpeedRead != Ssd.MaxSpeedRead)
					ssd.MaxSpeedRead = Ssd.MaxSpeedRead;

				_context.Ssd.Update(ssd);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteSSDAsync(int SSDId)
		{
			try
			{
				var ssd = await _context.Ssd.FirstOrDefaultAsync(c => c.SSDId == SSDId);

				if (ssd == null)
					throw new Exception($"No SSD with such id = {SSDId}.");

				_context.Ssd.Remove(ssd);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<int> ComputersToSsd(int SSDId, int ComputerInfoId)
		{
			var computerInfo = await _context.ComputerInfo
			   .FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

			var ssd = await _context.Ssd
				.FirstOrDefaultAsync(c => c.SSDId == SSDId);

			var ComputerToSsd = new ComputersToSSD()
			{
				Ssd = ssd,
				Computer = computerInfo
			};

			await _context.ComputersToSSD.AddAsync(ComputerToSsd);
			await _context.SaveChangesAsync();

			return ComputerToSsd.Id;
		}
	}
}
