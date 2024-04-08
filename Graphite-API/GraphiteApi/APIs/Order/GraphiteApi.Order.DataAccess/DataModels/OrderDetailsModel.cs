using GraphiteApi.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Order.DataAccess.DataModels
{
    public class OrderDetailsModel : IEntity<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public OrderModel Order { get; set; } = null!;
        public int AmountOfProducts { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
