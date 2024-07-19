namespace Vertr.Orders.Domain;
public record class ExecuteOrderResult(
    string RequestOrderId,
    string ExternalOrderId,
    string InstrumentUid,
    OrderExecutionStatus Status,
    long LotsRequested,
    long LotsExecuted,
    decimal CommissionValue,
    string CommissionCurrency,
    string Message
    )
{
}
