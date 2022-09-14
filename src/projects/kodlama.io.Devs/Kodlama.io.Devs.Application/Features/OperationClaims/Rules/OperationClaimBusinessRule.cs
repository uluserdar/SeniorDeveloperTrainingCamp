﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRule
    {
        public void CheckIfExistsOperationClaim(OperationClaim operationClaim)
        {
            if (operationClaim != null) throw new BusinessException(OperationClaimMessages.CheckIfAlreadyExistsOperationClaimMessage);
        }
    }
}
