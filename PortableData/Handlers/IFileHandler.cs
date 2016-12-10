using System.Threading.Tasks;
namespace PortableData
{
	public interface IFileHandler
	{
		bool FileExists(string fileName);
		Task<string> ReadAllText(string fileName);
	}
}
