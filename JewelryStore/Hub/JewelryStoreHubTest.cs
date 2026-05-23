using Microsoft.AspNetCore.SignalR;
using JewelryStore.Model;

namespace JewelryStore.Hubs
{
    public class JewelryStoreHub : Hub
    {
        // Отправка обновления продукта всем клиентам
        public async Task SendProductUpdate(TheProduct product)
        {
            await Clients.All.SendAsync("ProductUpdated", product);
        }
    }
}