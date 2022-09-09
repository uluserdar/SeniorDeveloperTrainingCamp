using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models
{
    public class FrameworkTechnologyListModel:BasePageableModel
    {
        public IList<FrameworkTechnologyListDto> Items { get; set; }
    }
}
