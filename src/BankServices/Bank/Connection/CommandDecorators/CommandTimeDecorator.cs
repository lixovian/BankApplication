using System.Diagnostics;
using BankServices.Bank.Connection.CommandMediators;
using BankServices.Bank.Connection.Commands;
using BankServices.Bank.Connection.Commands.CommandHandler;
using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.CommandDecorators;

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