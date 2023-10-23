using Newtonsoft.Json;

namespace Dto
{
	[JsonObject]
	public class ComputerInfoDto
	{
		[JsonProperty("ComputerId")]
		public int ComputerId { get; set; }

		[JsonProperty("OSVersion")]
		public string OSVersion { get; set; }

		[JsonProperty("ComputerName")]
		public string ComputerName { get; set; }

		[JsonProperty("SystemFolder")]
		public string SystemFolder { get; set; }

		[JsonProperty("CreationTime")]
		public string CreationTime { get; set; }

		[JsonProperty("UpdateTime")]
		public string UpdateTime { get; set; }

		[JsonProperty("OSName")]
		public string OSName { get; set; }
	}
}
