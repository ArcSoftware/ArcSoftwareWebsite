using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ArcSoftware.Data.Models;

namespace ArcSoftware.Data.Repository
{
    public class StaticFileRepo
    {
        public async Task<FileStream> GetStaticFile<T>(StaticFileModel model) where T : StaticFileModel
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                                        throw new InvalidOperationException(), @"StaticFiles\" +
                                                                               $"{model.FileDirectory}\\{model.FileName}.{model.FileType}");
            return new FileStream(filePath, FileMode.Open);
        }
    }
}