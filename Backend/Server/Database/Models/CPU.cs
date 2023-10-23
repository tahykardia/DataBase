namespace Database.Models
{
	public class CPU
	{

		public int CPUId { get; set; }

		public string Name { get; set; }
		public string Frequency { get; set; }
		public string Bitness { get; set; }
		public string CacheMemory { get; set; }
		public string NumberOfCores { get; set; }

		public virtual ComputerInfo ComputerInfo { get; set; }
	}
}
