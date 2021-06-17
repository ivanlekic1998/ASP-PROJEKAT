using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Application
{
    public interface ICommand<TReqeust> : IUseCase
    {
        void Execute(TReqeust reqeust);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
