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
            var folderpath = @"C:\Users\gyzdm\Documents\Podcasts\New\熊逸书院";
            var filetype = "m*";
            var token = "xy";
            var additionalToken = new List<string>() { "卓老板聊科技", "xs ", "ZLB" };
            var fmanager = new FileManager(folderpath, filetype, token,additionalToken);
            fmanager.StartMassiveRenames();
        }
    }
}
