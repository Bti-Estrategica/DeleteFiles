using Files.Process;
using LogFramework.Logs;
using System.Globalization;

namespace DeleteFiles
{
    internal class DeleteFiles
    {
        /// <summary>
        /// Deleta arquivos gerados automaticamente pelo SAP.
        /// </summary>
        internal static void DeleteFile(string filePath, string fileExtesion)
        {
            StandardLog logger = new StandardLog();
            List<string> files = Directory.GetFiles(filePath, $"*{fileExtesion}").ToList();

            foreach (string file in files)
            {
                try
                {

                    string fileName = Path.GetFileName(file).Replace(fileExtesion, "");

                    DateTime fileDate = File.GetCreationTime(file);

                    if (fileDate < DateTime.Now.AddHours(-1))
                        Delete.DeleteFileThreadSafe(file);

                }
                catch (Exception e)
                {
                    logger.WriteError("Erro ao excluir arquivo " + file + " do SAP. Mensagem de erro: " + e.ToString());
                }
            }
        }

    }
}
