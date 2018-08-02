using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TinifyAPI;

namespace ResizerCFW
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Tinify.Key = "A5lM3cfqk5BhU0nGFa0JEjKEQd550JAO";

            const string outPath = "C://Users//rkvillegas//output";

            var directories =
                Directory.GetDirectories(
                    "C://Users//rkvillegas//Downloads//Pictures-20180802T153825Z-001//Pictures");

            foreach (var dir in directories)
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    var fileInfo = new FileInfo(file);
                    var src = await Tinify.FromFile(file);
                    src = src
                        .Resize(new
                        {
                            method = "fit",
                            width = 2408,
                            height = 1365,
                        });

                        await src.ToFile($"{outPath}//{fileInfo.Name}");
                }
            }

            Console.ReadLine();

            return 0;
        }
    }
}
