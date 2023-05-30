using System.Globalization;

namespace DeleteFiles
{
    internal class Program
    {
        internal static void Main(string[] args)
        {

            DeleteFiles.DeleteFile(args[0].Split(',')[0], args[0].Split(',')[1]);
        }
    }
}
