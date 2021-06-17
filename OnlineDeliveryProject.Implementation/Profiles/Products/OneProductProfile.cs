using AutoMapper;
using OnlineDeliveryProject.Application.DataTransfer.Products;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Products
{
    public class OneProductProfile : Profile
    {
        public OneProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
