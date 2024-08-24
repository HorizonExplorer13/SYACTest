using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.ProductsServices
{
    public class Productservices : IProductService
    {
        public Productservices(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public AppDBContext DBContext { get; }

        public async Task<ServiceResponse<object>> getlist(){
            var list = await DBContext.Products.ToListAsync();
            if(list.Any() || list.Count > 0)
            {
                return new ServiceResponse<object>
                {
                    statusCode = 200,
                    data = list
                };
            }
            return new ServiceResponse<object>
            {
                statusCode = 400,
                
            };
        }

        public async Task<ServiceResponse<List<Products>>> createproducto(List<ProductsDTO> product)
        {
            var productsToCreate = new List<Products>();
            foreach (var Tocreate in product)
            {
                var createProduct = new Products
                {
                    productName = Tocreate.productName,
                    productoCode = Tocreate.productoCode,
                    productUnitValue = Tocreate.productUnitValue,
                };
                productsToCreate.Add(createProduct);
            }
            

            await DBContext.AddRangeAsync(productsToCreate);
            
            var result = await DBContext.SaveChangesAsync();
            if (result != 0)
            {
                var productcraeted = await DBContext.Products.ToListAsync();
                return new ServiceResponse<List<Products>>
                {
                    statusCode = 200,
                    data = productcraeted
                };
            }
            return new ServiceResponse<List<Products>>
            {
                statusCode = 400
            };
        }

    }
}
