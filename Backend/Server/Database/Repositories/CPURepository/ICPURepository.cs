using Database.Models;
using Dto;
using System.Threading.Tasks;

namespace Database.Repositories.CPURepository
{
	public interface ICPURepository
	{
		Task<CPU> GetCPUAsync(int CPUId);
		Task<int> CreateCPUAsync(CPUDto Cpu, int ComputerInfoId);
		Task UpdateCPUAsync(int CPUId, CPUDto Cpu);
		Task DeleteCPUAsync(int CPUId);
	}
}
