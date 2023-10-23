using Database.Models;
using Dto;
using System.Threading.Tasks;

namespace Database.Repositories.GPURepository
{
	public interface IComputersToGPURepository
	{
		Task<ComputersToGPU> GetComputersToGPUAsync(int GPUId, int ComputerId);
		Task CreateComputersToGPUAsync(GPU Gpu, ComputerInfo computer);
		Task UpdateComputersToGPUAsync(int GPUId,  ComputersToGPU ComputerInfo);
		Task DeleteComputersToGPUAsync(int GPUId);
	}
}
