using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Products
{
    public class AddProductProfile : Profile
    {
        public AddProductProfile()
        {
            CreateMap<Product, AddProductRequest>();
            CreateMap<AddProductRequest, Product>();
        }
    }
}
