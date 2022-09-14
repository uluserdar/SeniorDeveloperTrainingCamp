using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;

namespace Kodlama.io.Devs.Application.Features.Authentications.Models
{
    public class UserListModel:BasePageableModel
    {
        public IList<UserListDto> Items { get; set; }
    }
}
