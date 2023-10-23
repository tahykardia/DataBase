using Newtonsoft.Json;

namespace Dto
{
	[JsonObject]
	public class SSDDto
	{
		[JsonProperty("SSDId")]
		public int SSDId { get; set; }

		[JsonProperty("Amount")]
		public string Amount { get; set; }

		[JsonProperty("MaxSpeedWrite")]
		public string MaxSpeedWrite { get; set; }

		[JsonProperty("MaxSpeedRead")]
		public string MaxSpeedRead { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
