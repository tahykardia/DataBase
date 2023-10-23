using System.IO;
using System.Text;

namespace ITRR.Services
{
	
	public class MainService
	{
		~MainService() { }
		string path = Directory.GetCurrentDirectory();

		public void writeTofile(string note, int computerId)
		{
			path += @"/AgentsInfo/Agent#" +  computerId + ".json";
			using (StreamWriter sw = new StreamWriter(path,true,Encoding.Default))
			{
				sw.WriteLine(note);
			}
		}
	}
}
