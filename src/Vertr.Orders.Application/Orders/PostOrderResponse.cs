using Vertr.Orders.Domain;

namespace Vertr.Orders.Application.Orders;

public record class PostOrderResponse(ExecuteOrderResult? Result);
