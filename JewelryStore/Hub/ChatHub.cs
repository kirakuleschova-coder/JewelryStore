using Microsoft.AspNetCore.SignalR;
using JewelryStore.Model;

namespace JewelryStore.Hubs
{
    public class JewelryStoreHub : Hub
    {
        public async Task SendProductUpdate(TheProduct product)
        {
            await Clients.All.SendAsync("ReceiveProductUpdate", product);
        }

        public async Task SendBuyerUpdate(Buyer buyer)
        {
            await Clients.All.SendAsync("ReceiveBuyerUpdate", buyer);
        }

        public async Task SendManufacturerUpdate(Manufacturer manufacturer)
        {
            await Clients.All.SendAsync("ReceiveManufacturerUpdate", manufacturer);
        }
    }
}
