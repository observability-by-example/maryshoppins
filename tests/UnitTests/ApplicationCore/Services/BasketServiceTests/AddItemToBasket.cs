﻿using Moq;
using System.Threading.Tasks;
using MaryShoppins.ApplicationCore.Entities.BasketAggregate;
using MaryShoppins.ApplicationCore.Interfaces;
using MaryShoppins.ApplicationCore.Services;
using MaryShoppins.ApplicationCore.Specifications;
using Xunit;

namespace MaryShoppins.UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class AddItemToBasket
    {
        private readonly string _buyerId = "Test buyerId";
        private readonly Mock<IAsyncRepository<Basket>> _mockBasketRepo;

        public AddItemToBasket()
        {
            _mockBasketRepo = new Mock<IAsyncRepository<Basket>>();
        }

        [Fact]
        public async Task InvokesBasketRepositoryGetByIdAsyncOnce()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>())).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.Id, 1, 1.50m);

            _mockBasketRepo.Verify(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>()), Times.Once);
        }

        [Fact]
        public async Task InvokesBasketRepositoryUpdateAsyncOnce()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>())).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.Id, 1, 1.50m);

            _mockBasketRepo.Verify(x => x.UpdateAsync(basket), Times.Once);
        }
    }
}
