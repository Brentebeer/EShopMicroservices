using MediatR;

namespace BuildingBlocks.CQRS;

//IQuery that does return a respone --> IRequest<TResponse>
//IQuery<out TResponse> = Wilt zeggen dat alle children van TRespone hier aan kunnen worden mee gegeven.
//Where TResponse : notnull = Wilt zeggen dat je geen null waarde kan toewijzen als de response niet null kan zijn.
public interface IQuery<out TResponse> : IRequest<TResponse> 
    where TResponse : notnull
{
}
