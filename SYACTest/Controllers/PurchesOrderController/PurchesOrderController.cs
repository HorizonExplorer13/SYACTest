using Microsoft.AspNetCore.Mvc;
using SYACTest.DTOs.PurchesOrders;
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

            return Ok(createPurchesOrder);
        }
    }
}
