namespace Database.Models
{
	public class ComputersToRAM
	{
		public int Id { get; set; }

		public virtual RAM Ram { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
