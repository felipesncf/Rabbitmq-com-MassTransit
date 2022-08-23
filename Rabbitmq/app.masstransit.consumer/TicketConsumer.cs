using MassTransit;
using Newtonsoft.Json;
using Shared.Model;

namespace app.masstransit.consumer
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        private readonly ILogger<TicketConsumer> logger;

        public TicketConsumer(ILogger<TicketConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var result = JsonConvert.SerializeObject(context.Message.teste);
            //await Console.Out.WriteLineAsync(context.Message.UserName);
            //logger.LogInformation($"Nova mensagem recebida: " + $" {context.Message.Booked} {context.Message.UserName} {context.Message.Location} ");
            logger.LogInformation(result);
        }
    }
}
