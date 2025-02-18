using MediatR;

namespace BuildingBlocks.CQRS;

//Empty ICommand that doesn't return any response
public interface ICommand : ICommand<Unit>
{

}

//In wilt echt zeggen dat specifiek type en out wil zeggen eender welk type als het maar afgeleid is van bijvoorbeeld TResponse
//ICommand that does return a respone --> IRequest<TResponse>
//ICommand<out TResponse> = Wilt zeggen dat alle children van TRespone hier aan kunnen worden mee gegeven. (bijvoorbeeld als TResponse een basisklasse is, kun je een afgeleide klasse als type gebruiken).
public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
