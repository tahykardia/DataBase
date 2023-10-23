using Dto;
using Database.Models;
using System.Threading.Tasks;

namespace Database.Repositories.RAMRepository
{
	public interface IRAMRepository
	{
		Task<RAM> GetRAMAsync(int RAMId);
		Task<int> CreateRAMAsync(RAMDto Ram);
		Task UpdateRAMAsync(int RAMId, RAMDto Ram);
		Task DeleteRAMAsync(int RAMId);
		Task<int> ComputersToRam(int RAMId, int ComputerId);
	}
}
