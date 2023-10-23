using Dto;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Repositories.RAMRepository
{
    public class RAMRepository : BaseRepository, IRAMRepository
    {
        public RAMRepository(LabDbContext context) : base(context) { }

        public async Task<int> CreateRAMAsync(RAMDto Ram)
        {
            try
            {
                var ram = new RAM()
                {
                    Frequency = Ram.Frequency,
                    Volume = Ram.Volume,
                    Name = Ram.Name
                };

                await _context.Ram.AddAsync(ram);
                await _context.SaveChangesAsync();

                return ram.RAMId;
            }
            catch
            {
                throw new Exception($"Error");
            }     
        }

        public async Task<RAM> GetRAMAsync(int RAMId)
        {
			try
			{
                var ram = await _context.Ram
                .FirstOrDefaultAsync(c => c.RAMId == RAMId);

                if (ram == null)
                    throw new Exception($"No RAM with such id: {RAMId}");

                return ram;
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

        public async Task UpdateRAMAsync(int RAMId, RAMDto Ram)
        {
			try
			{
                var ram = await _context.Ram.FirstOrDefaultAsync(c => c.RAMId == RAMId);

                if (ram == null)
                    throw new Exception($"No RAM with such id = {RAMId}.");

                if (ram.Frequency != Ram.Frequency)
                    ram.Frequency = Ram.Frequency;

                if (ram.Name != Ram.Name)
                    ram.Name = Ram.Name;

                if (ram.Volume != Ram.Volume)
                    ram.Volume = Ram.Volume;

                _context.Ram.Update(ram);
                await _context.SaveChangesAsync();
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

        public async Task DeleteRAMAsync(int RAMId)
        {
			try
			{
                var ram = await _context.Ram.FirstOrDefaultAsync(c => c.RAMId == RAMId);

                if (ram == null)
                    throw new Exception($"No RAM with such id = {RAMId}.");

                _context.Ram.Remove(ram);
                await _context.SaveChangesAsync();
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

		public async Task<int> ComputersToRam(int RAMId, int ComputerInfoId)
		{
            var computerInfo = await _context.ComputerInfo
                .FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

            var ram = await _context.Ram
                .FirstOrDefaultAsync(c => c.RAMId == RAMId);

            var ComputerToRam = new ComputersToRAM()
            {
                Ram = ram,
                Computer = computerInfo
            };

            await _context.ComputersToRAM.AddAsync(ComputerToRam);
            await _context.SaveChangesAsync();

            return ComputerToRam.Id;
        }
	}
}
