using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Order.DataAccess.DataModels
{
    public class OrderModel : IEntity<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public ICollection<OrderDetailsModel> OrderDetails = new List<OrderDetailsModel>();
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
