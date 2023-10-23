namespace Database.Repositories
{

	public class BaseRepository
	{
		protected readonly LabDbContext _context;

		public BaseRepository(LabDbContext context)
		{
			_context = context;
		}
	}
}
