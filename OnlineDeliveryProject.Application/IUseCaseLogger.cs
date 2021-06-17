using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application
{
    public interface IUseCaselogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
