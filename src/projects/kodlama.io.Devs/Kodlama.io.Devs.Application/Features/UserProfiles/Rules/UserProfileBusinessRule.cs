using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserProfiles.Constants;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Rules
{
    public class UserProfileBusinessRule
    {
        public void CheckIfExistsUser(User user)
        {
            if (user == null) throw new BusinessException(UserProfileMessages.UserNotFoundMessage);
        }

        public void CheckIfExistsUserProfile(UserProfile userProfile)
        {
            if (userProfile == null) throw new BusinessException(UserProfileMessages.UserProfileNotFoundMessage);
        }

        public void CheckIfAlreadyExistsUserProfile(UserProfile userProfile)
        {
            if (userProfile?.User != null) throw new BusinessException(UserProfileMessages.UserProfileAlreadyExistsMessage);
        }
    }
}
