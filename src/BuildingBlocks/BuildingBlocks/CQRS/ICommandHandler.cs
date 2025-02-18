using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> 
    where TCommand : ICommand<Unit>;

//In wilt echt zeggen dat specifiek type en out wil zeggen eender welk type als het maar afgeleid is van bijvoorbeeld TResponse
//in: wilt zeggen dat het een object dat ICommand<TResponse> moet bevatten
//where TResponse: notnull: Dit plaatst een beperking op de generieke typeparameter TResponse.Het betekent dat TResponse niet null mag zijn.
//where TCommand: ICommand<TResponse>: Dit plaatst een beperking op de generieke typeparameter TCommand. Het betekent dat TCommand een type moet zijn dat ICommand<TResponse> implementeert.
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : ICommand<TResponse> 
    where TResponse : notnull
{
}
