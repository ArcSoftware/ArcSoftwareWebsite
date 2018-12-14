using ArcSoftware.Common.Enums;

namespace ArcSoftware.Data.Models
{
    public class StaticFileModel
    {
        public StaticFileModel(string fileName, string fileDirectory, StaticFileType fileType)
        {
            FileName = fileName;
            FileDirectory = fileDirectory;
            FileType = fileType;          
        }

        public string FileName { get; }
        public string FileDirectory { get; set; }
        public StaticFileType FileType { get; }
    }
}