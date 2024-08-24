using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.PurchesOrderService
{
    public interface IPurchesOrderService
    {
        Task<ServiceResponse<PurchesOrder>> CreatePurchesOrder(CreatePurchesOrderDTO createPurchesOrder);
    }
}
