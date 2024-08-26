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
            var createProducts = new List<Products>();
            foreach(var item in product)
            {
                var toadd = new Products {
                    productname = item.productName,
                    productCode = item.productoCode,
                    unitValue = item.productUnitValue
                };
                createProducts.Add(toadd);
            }
            await DBContext.Products.AddRangeAsync(createProducts);
            await DBContext.SaveChangesAsync();

           
            return new ServiceResponse<List<Products>>
            {
                statusCode = 400
            };
        }

    }
}
