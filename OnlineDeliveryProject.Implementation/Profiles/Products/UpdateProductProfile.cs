using AutoMapper;
using OnlineDeliveryProject.Application.Requests.Products;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Profiles.Products
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, UpdateProductRequest>();
        }
    }
}
