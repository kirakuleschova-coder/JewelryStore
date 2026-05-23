using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Tests.UnitTest.Hubs
{
    public class JewelryStoreHubTest
    {
        [Fact]
        public async Task SendBookUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new JewelryStoreHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var product = new TheProduct
            {
                Title = "Test Product",
                Price = 1000,
                Product = "Ring",
                Test = 585,
                ProductionDate = 2024
            };

            // Act
            await hub.SendProductUpdate(product);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "ProductUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == product),
                    default
                ),
                Times.Once
            );
        }
    }
}

