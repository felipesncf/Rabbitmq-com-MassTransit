using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Model;
using System.Dynamic;
using System.Text.Json.Nodes;

namespace app.masstransit.publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] JsonObject ticket)
        {
            //var tickect2 = JsonConvert.DeserializeObject(ticket.ToJsonString(), typeof (Ticket));
            if (ticket != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/orderTicketQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                //JsonConvert.DeserializeObject<ExpandoObject>(param.ToJsonString(), new ExpandoObjectConverter());
                await endPoint.Send(JsonConvert.DeserializeObject(ticket.ToJsonString(), typeof(Ticket)));
                return Ok();
            }
            return BadRequest();
        }
    }
}
