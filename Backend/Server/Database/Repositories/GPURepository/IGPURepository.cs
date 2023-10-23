using Dto;
using Database.Models;
using System.Threading.Tasks;

namespace Database.Repositories.GPURepository
{
	public interface IGPURepository
	{
		Task<GPU> GetGPUAsync(int GPUId);
		Task<int> CreateGPUAsync(GPUDto Gpu);
		Task UpdateGPUAsync(int GPUId, GPUDto Gpu);
		Task DeleteGPUAsync(int GPUId);
		Task<int> ComputersToGpu(int GPUId, int ComputerId);
	}
}
