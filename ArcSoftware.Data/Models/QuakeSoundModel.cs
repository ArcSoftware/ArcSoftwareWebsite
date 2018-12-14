using ArcSoftware.Common.Enums;

namespace ArcSoftware.Data.Models
{
    public class QuakeSoundModel : StaticFileModel
    {
        public QuakeSoundModel(string fileName, string fileDirectory, StaticFileType fileType, SoundVariation variation) : base(fileName, fileDirectory, fileType)
        {
            Variation = variation;
        }

        public SoundVariation Variation { get; }
    }
}
