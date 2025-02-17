using MediatR;

namespace BuildingBlocks.CQRS;

//Empty ICommand that doesn't return any response
public interface ICommand : ICommand<Unit>
{

}

//ICommand that does return a respone --> IRequest<TResponse>
//ICommand<out TResponse> = Wilt zeggen dat alle children van TRespone hier aan kunnen worden mee gegeven.
public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
