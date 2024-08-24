using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SYACTest.Services.PurchesOrderService
{
    public class PurchesOrderService : IPurchesOrderService
    {
        public AppDBContext AppDBContext { get; }

        public PurchesOrderService(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public async Task<ServiceResponse<List<PurchesOrderDTO>>> GetPurchesOrdersList()
        {
            return new ServiceResponse<List<PurchesOrderDTO>>
            {
                statusCode = 200,
            };
        }

        public async Task<ServiceResponse<PurchesOrder>> CreatePurchesOrder(CreatePurchesOrderDTO createPurchesOrder)
        {

            var clientoAttach = await AppDBContext.clients.FindAsync(createPurchesOrder.documentClient);
            
            
            var createOrder = new PurchesOrder
            {
                clientId = clientoAttach.clientId,
                priority = createPurchesOrder.priority,
                recordDate = DateTime.Now,
                RequestAddress = createPurchesOrder.requestAddress,
                products = new List<OrderProduct>(),
                state = "pending",
                TtotalToPurch = createPurchesOrder.quantity,
                totalPurchValue = createPurchesOrder.totalPurchesvalue,          
            };

            decimal totalValue = 0;
            foreach (var productDto in createPurchesOrder.products)
            {
                var product = await AppDBContext.Products.FindAsync(productDto.productId);
                if (product == null)
                {
                    return new ServiceResponse<PurchesOrder>
                    {
                        statusCode = 404,
                        
                    };
                }

                var partialValue = product.productUnitValue * createPurchesOrder.quantity;
                totalValue += partialValue;

                createOrder.products.Add(new OrderProduct
                {
                    ProductId = product.productId,
                    Quantity = createPurchesOrder.quantity,
                    PartialValue = partialValue
                });
            }
            AppDBContext.purchesOrders.Add(createOrder);
            var result = await AppDBContext.SaveChangesAsync();
            if(result != 0)
            {
               
                var updateState =await AppDBContext.purchesOrders.FirstOrDefaultAsync(po => po.clientId == clientoAttach.clientId);
                if(updateState != null)
                {
                    updateState.state = "Regitrado";
                    AppDBContext.Entry(updateState).State = EntityState.Modified;   
                    var secondResult = await AppDBContext.SaveChangesAsync();
                    if (secondResult != 0 )
                    {
                        return new ServiceResponse<PurchesOrder>
                        {
                            statusCode = 200,
                            data = createOrder
                        };
                    }
                };
                return new ServiceResponse<PurchesOrder>
                {
                    statusCode = 400
                };

            }
            return new ServiceResponse<PurchesOrder>
            {
                statusCode = 400
            };

        }


        private static int defineTotalPurchValue(int unitvalue,int quantity)
        {
            return unitvalue * quantity;
        }

    }
}
