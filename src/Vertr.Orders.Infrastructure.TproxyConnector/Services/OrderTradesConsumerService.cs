using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vertr.Infrastructure.Kafka;
using Vertr.Infrastructure.Kafka.Abstractions;
using Vertr.Orders.Application.Orders;
using Vertr.Orders.Infrastructure.TproxyConnector.Converters;

namespace Vertr.Orders.Infrastructure.TproxyConnector.Services;
internal sealed class OrderTradesConsumerService : BackgroundService
{
    public static readonly string OorderTradesTopicKey = "OrderTrades";

    private readonly IServiceProvider _services;
    private readonly ILogger<OrderTradesConsumerService> _logger;

    private readonly string _orderTradesTopic;

    public OrderTradesConsumerService(
        IServiceProvider serviceProvider,
        IOptions<KafkaSettings> kafkaSettings,
        ILogger<OrderTradesConsumerService> logger
        )
    {
        _services = serviceProvider;
        _logger = logger;
        var topics = kafkaSettings.Value.Topics;

        topics.TryGetValue(OorderTradesTopicKey, out var orderTradesTopic);
        _orderTradesTopic = orderTradesTopic ?? throw new ArgumentException("Order trades topic is not defined.");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var consumer = _services.GetRequiredService<IConsumerWrapper<string, Tproxy.Client.Orders.OrderTrade>>();

            try
            {
                await consumer.Consume([_orderTradesTopic], Handle, false, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error consuming order trades. Message={ex.Message}");
            }
        }
    }

    private async Task Handle(ConsumeResult<string, Tproxy.Client.Orders.OrderTrade> result, CancellationToken cancellationToken)
    {
        var mediator = _services.GetRequiredService<IMediator>();

        var trade = result.Message.Value.Convert();

        // TODO: Filter dublicates here.
        var request = new ConsumeTradeRequest
        {
            OrderTrade = trade
        };

        var res = await mediator.Send(request);
        // TODO: Handle result
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogWarning("Order trades consumer is stopping...");
        await base.StopAsync(stoppingToken);
    }
}
