using Microsoft.AspNetCore.Mvc;
using SYACTest.DTOs;
using SYACTest.Services.PurchesOrderService;

namespace SYACTest.Controllers.PurchesOrderController
{
    [ApiController]
    [Route("Api/PurchesOrders")]
    public class PurchesOrderController : ControllerBase
    {
        public IPurchesOrderService PurchesOrderService { get; }
        public PurchesOrderController(IPurchesOrderService purchesOrderService)
        {
            PurchesOrderService = purchesOrderService;
        }

        
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreatePurchesOrder([FromBody] CreatePurchesOrderDTO createPurchesOrder)
        {
            var ServiceResponse = await PurchesOrderService.CreatePurchesOrder(createPurchesOrder);
            switch (ServiceResponse.statusCode)
            {
                case 200:
                    return Ok(ServiceResponse);
                case 400:
                    return BadRequest(ServiceResponse);
                default:
                    return BadRequest(ServiceResponse);
            }
        }
    }
}
