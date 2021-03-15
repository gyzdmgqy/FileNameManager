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
            var folderpath = @"C:\Users\gyzdm\Documents\Podcasts\New\41 万维钢精英日课第三季";
            var filetype = "m*";
            var token = "jy";
            var additionalToken = new List<string>() { "卓老板聊科技", "ZLB ", "ZLB" };
            var fmanager = new FileManager(folderpath, filetype, token,additionalToken);
            fmanager.StartMassiveRenames();
        }
    }
}
