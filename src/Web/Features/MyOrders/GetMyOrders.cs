using MediatR;
using System.Collections.Generic;
using MaryShoppins.Web.ViewModels;

namespace MaryShoppins.Web.Features.MyOrders
{
    public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
    {
        public string UserName { get; set; }

        public GetMyOrders(string userName)
        {
            UserName = userName;
        }
    }
}
