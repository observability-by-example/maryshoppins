﻿using Ardalis.Specification;
using MaryShoppins.ApplicationCore.Entities.BasketAggregate;

namespace MaryShoppins.ApplicationCore.Specifications
{
    public sealed class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(int basketId) 
        {
            Query
                .Where(b => b.Id == basketId)
                .Include(b => b.Items);
        }

        public BasketWithItemsSpecification(string buyerId)
        {
            Query
                .Where(b => b.BuyerId == buyerId)
                .Include(b => b.Items);
        }
    }
}
