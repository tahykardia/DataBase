using Dto;
using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Database.Repositories.ComputerInfoRepository
{
	public interface IComputerInfoRepository
	{
		Task<ComputerInfo> GetComputerInfoAsync(int computerInfoId);
		Task<int> CreateComputerInfoAsync(ComputerInfoDto ComputerInfo);
		Task UpdateComputerInfoAsync(int computerInfoId, ComputerInfoDto ComputerInfo);
		Task DeleteComputerInfoAsync(int computerInfoId);
		Task<List<ComputerInfo>> GetAllComputerAsync();

		Task<List<GPU>> GetGPUs(int computerInfoId);
		Task<List<RAM>> GetRAMs(int computerInfoId);
		Task<List<SSD>> GetSSDs(int computerInfoId);
		Task<CPU> GetCPU(int computerInfoId);
	}
}
