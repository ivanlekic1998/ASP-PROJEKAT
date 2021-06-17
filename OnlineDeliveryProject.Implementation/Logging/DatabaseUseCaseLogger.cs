using Newtonsoft.Json;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaselogger
    {
        private readonly OnlineDeliveryContext _context;
        public DatabaseUseCaseLogger(OnlineDeliveryContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
