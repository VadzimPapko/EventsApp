using System;
using System.IO;
using System.Threading.Tasks;
using PortableData;
namespace Events.IO
{
	public class FileHandler:IFileHandler
	{
		public FileHandler()
		{
		}
		#region IFileHandler implementation

		public bool FileExists(string fileName)
		{
			var ifExist = File.Exists(fileName);

			return ifExist;
		}

		public async Task<string> ReadAllText(string fileName)
		{
			using (StreamReader reader = File.OpenText(fileName)) 
			{
				return await reader.ReadToEndAsync();
			}
		}

		#endregion
	}
}
