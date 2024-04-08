using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Order.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GraphiteApi.Order.BusinessLogic.Extensions
{
    public static class OrderRepositoryExtensions
    {
        public static OrderModel ConvertToModel(this OrderDto d)
        {
            return new OrderModel()
            {
                CreatedDate = d.CreatedDate,
                Id = d.Id,
                UpdatedDate = d.UpdatedDate,
                UserId = d.UserId.Id,
                OrderDetails = d.OrderDetails.Select(x => x.ConvertToModel()).ToList(),
            };
        }

        public static OrderDetailsModel ConvertToModel(this OrderDetailsDto d)
        {
            OrderDetailsModel model = new OrderDetailsModel()
            {
                Id = d.Id,
                CreatedDate = d.CreatedDate,
                UpdatedDate = d.UpdatedDate,
                AmountOfProducts = d.AmountOfProducts,
                Order = new OrderModel()
                {
                    Id = d.Order.Id,
                },
            };
            string objectIdString = d.Product.Id;
            Guid guid = Guid.NewGuid();
            if(Guid.TryParse(objectIdString, out guid))
            {
                model.ProductId = guid;
            }

            return model;
        }

        public static OrderDetailsDto ConvertToDto(this OrderDetailsModel m)
        {
            return new OrderDetailsDto()
            {
                AmountOfProducts = m.AmountOfProducts,
                CreatedDate = m.CreatedDate,
                Id = m.Id,
                Order = m.Order.ConvertToDto(),
                Product = new PencilDto()
                {
                    Id =  m.ProductId.ToString(),
                },
                UpdatedDate = m.UpdatedDate,

            };
        }

        public static OrderDto ConvertToDto(this OrderModel m)
        {
            return new OrderDto()
            {
                Id = m.Id,
                CreatedDate = m.CreatedDate,
                UpdatedDate = m.UpdatedDate,
                OrderDetails = m.OrderDetails.Select(x => x.ConvertToDto()).ToList(),
                UserId = new UserDto()
                {
                    Id = m.UserId
                },
            };
        }
    }
}
