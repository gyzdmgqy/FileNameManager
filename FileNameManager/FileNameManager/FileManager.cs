using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace FileNameManager
{
    class FileManager
    {
        private string folderpath;
        private string filetype;
        private string token;
        private List<string> additionalTokens;

        public FileManager(string folderpath, string filetype, string token, List<string> additionalTokens)
        {
            this.folderpath = folderpath;
            this.filetype = filetype;
            this.token = token;
            this.additionalTokens = additionalTokens;
        }

        private void MassiveRenames(bool Preview = true)
        {
            var filetypeToken = "*." + filetype;
            var paths = Directory.GetFiles(folderpath, filetypeToken, SearchOption.AllDirectories);
            var culture = new CultureInfo("es-ES", false);
            foreach (var filepath in paths)
            {
                int positionYear = filepath.IndexOf("\\201");
                var year = filepath.Substring(positionYear + 1, 4);
                var fileName = Path.GetFileName(filepath);
                var fileName0 = fileName;
                if (!fileName.StartsWith(token))
                {
                    bool tokenFound = false;
                    foreach (var additionalToken in additionalTokens)
                    {
                        if (fileName.StartsWith(additionalToken))
                        {
                            fileName = fileName.Replace(additionalToken, token);
                            tokenFound = true;
                            break;
                        }
                    }
                    if (!tokenFound)
                    {
                        fileName = token + fileName;
                    }
                }

                var revisedFileName = Regex.Replace(fileName, token, token + year);
                Console.WriteLine(String.Format("File {0} changed to File {1}", fileName0, revisedFileName));
                if (!Preview)
                {
                    var newFilePath = filepath.Replace(fileName0, revisedFileName);
                    File.Move(filepath, newFilePath);
                }
            }
        }

        public void StartMassiveRenames()
        {
            MassiveRenames();
            Console.WriteLine("Does file operation preview look right (y/n)?  ");
            bool previewFeedback = Console.ReadLine() == "y";
            if (previewFeedback) MassiveRenames(false);

        }

    }
}
