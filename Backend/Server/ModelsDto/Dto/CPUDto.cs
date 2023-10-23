using Newtonsoft.Json;

namespace Dto
{
	[JsonObject]
	public class CPUDto
	{
		[JsonProperty("CPUId")]
		public int CPUId { get; set; }

		[JsonProperty("Frequency")]
		public string Frequency { get; set; }

		[JsonProperty("Bitness")]
		public string Bitness { get; set; }

		[JsonProperty("CacheMemory")]
		public string CacheMemory { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("NumberOfCores")]
		public string NumberOfCores { get; set; }

		[JsonProperty("ComputerId")]
		public int ComputerId { get; set; }

	}
}
