using System.Threading.Tasks;
using ArcSoftware.Common.Enums;
using ArcSoftware.Common.Processing;
using ArcSoftware.Data.Models;
using ArcSoftware.Data.Repository;

namespace ArcSoftware.Api.Processors
{
    public class QuakeSoundProcessor : ProcessorBase<QuakeSoundModel>
    {
        private readonly StaticFileRepo _repo;

        public override async Task<ProcessingRequest<QuakeSoundModel>> Process(QuakeSoundModel model, ActionType actionType)
        {
            model.FileDirectory += model.Variation;

            var request = new ProcessingRequest<QuakeSoundModel>
            {
                Item = model,
                File = await _repo.GetStaticFile<QuakeSoundModel>(model),
                ActionType = actionType
            };

            return request;
        }
    }
}