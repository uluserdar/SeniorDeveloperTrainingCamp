using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.FrameworkTechnologies.Models
{
    public class FrameworkTechnologyListModel:BasePageableModel
    {
        public IList<FrameworkTechnologyListDto> Items { get; set; }
    }
}
