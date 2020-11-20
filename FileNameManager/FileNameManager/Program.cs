using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNameManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderpath = @"D:\Listening\薛兆l丰-北大l经济l学课";
            var filetype = "mp3";
            var token = "xzf";
            var additionalToken = "薛兆丰的北大经济学课";
            var fmanager = new FileManager(folderpath, filetype, token,additionalToken);
            fmanager.StartMassiveRenames();
        }
    }
}
