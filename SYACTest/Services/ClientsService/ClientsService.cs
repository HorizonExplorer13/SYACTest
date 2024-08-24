using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.Clients
{
    public class ClientsService : IClientsService
    {
        public ClientsService(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public AppDBContext DBContext { get; }

        public async Task<ServiceResponse<ClientsEntity>> createClients(CreateClientDTO createClient)
        {
            var createNewClient = new ClientsEntity
            {
                document = createClient.document,
                name = createClient.name,
                address = createClient.address
            };

            DBContext.clients.Add(createNewClient);
            var result = await DBContext.SaveChangesAsync();
            if(result != 0)
            {
                var createdClient = await DBContext.clients.FirstOrDefaultAsync(cl => cl.document == createNewClient.document);
                return new ServiceResponse<ClientsEntity>
                {
                    statusCode = 200,
                    data = createdClient
                };
            }
            return new ServiceResponse<ClientsEntity>
            {
                statusCode = 400
            };
        }
    }
}
