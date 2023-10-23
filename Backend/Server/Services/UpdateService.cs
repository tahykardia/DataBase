using System;
using System.IO;
using System.Text;

namespace ITRR.Services
{
	public class UpdateService
	{
		~UpdateService() { }

		string path = Directory.GetCurrentDirectory();

		public void writeTofile(string note, int computerId)
		{
			path += @"\\AgentsUpdateInfo\\Agent#" + computerId + ".json";
			using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
			{
				sw.WriteLine($"{DateTime.Now}: {note}");
			}
		}
	}
}
