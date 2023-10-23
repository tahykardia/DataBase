using Newtonsoft.Json;

namespace Dto
{
	[JsonObject]
	public class RAMDto
	{
		[JsonProperty("RAMId")]
		public int RAMId { get; set; }

		[JsonProperty("Frequency")]
		public string Frequency { get; set; }

		[JsonProperty("Volume")]
		public string Volume { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
