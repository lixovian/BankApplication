using System.Diagnostics;
using BankServices.Bank.DataTransferObjects;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Connection.Mediators;

namespace BankServices.Patterns.Decorators;

public class CommandTimeDecorator : ICommandHandler 
{
    private readonly ICommandHandler _handler;
    private readonly ICommandTimeMediator _mediator;

    public CommandTimeDecorator(ICommandHandler handler, ICommandTimeMediator mediator)
    {
        _handler = handler;
        _mediator = mediator;
    }

    public void Handle<TData>(IObjectCommand<TData> command, TData data) where TData : IDataTransferObject
    {
        var sw = Stopwatch.StartNew();
        _handler.Handle(command, data); 
        sw.Stop();
        _mediator.Notify(new CommandTimeData(sw.Elapsed));
    }
}