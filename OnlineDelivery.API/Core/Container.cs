
using OnlineDeliveryProject.Application.Commands.Categories;
using OnlineDeliveryProject.Application.Email;
using OnlineDeliveryProject.Application.Queries;
using OnlineDeliveryProject.Implementation.Email;
using OnlineDeliveryProject.Implementation.Logging;
using OnlineDeliveryProject.Implementation.Queries;
using OnlineDeliveryProject.Implementation.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineDeliveryProject.Api.Core;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Cities;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.Application.Commands.Orders;
using OnlineDeliveryProject.Application.Commands.Products;
using OnlineDeliveryProject.Application.Commands.Restaurants;
using OnlineDeliveryProject.Application.Commands.Reviews;
using OnlineDeliveryProject.Application.Queries.Customers;
using OnlineDeliveryProject.Implementation.Commands.Categories;
using OnlineDeliveryProject.Implementation.Commands.Cities;
using OnlineDeliveryProject.Implementation.Commands.Customers;
using OnlineDeliveryProject.Implementation.Commands.Orders;
using OnlineDeliveryProject.Implementation.Commands.Products;
using OnlineDeliveryProject.Implementation.Commands.Restaurants;
using OnlineDeliveryProject.Implementation.Commands.Reviews;
using OnlineDeliveryProject.Implementation.Queries.Customers;
using OnlineDeliveryProject.Implementation.Validators.Categories;
using OnlineDeliveryProject.Implementation.Validators.Cities;
using OnlineDeliveryProject.Implementation.Validators.Customers;
using OnlineDeliveryProject.Implementation.Validators.Orders;
using OnlineDeliveryProject.Implementation.Validators.Products;
using OnlineDeliveryProject.Implementation.Validators.Restaurants;
using OnlineDeliveryProject.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineDeliveryProject.Implementation.Queries.Restaurants;
using OnlineDeliveryProject.Application.Queries.Restaurants;

namespace OnlineDeliveryProject.Api.Core
{
    public static class Container
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //connecting interfaces
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.AddTransient<IGetLogsQuery, EfGetLogQuery>();
            services.AddTransient<IExceptionLogger, DatabaseExceptionLogger>();
            services.AddTransient<IExceptionLogger, DatabaseExceptionLogger>();
            services.AddTransient<IGetLogsExceptionQuery, EfGetLogExceptionQuery>();
            services.AddTransient<IUseCaselogger, DatabaseUseCaseLogger>();

            //customers

            services.AddTransient<IAddCustomerCommand, EfAddCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, EfDeleteCustomerCommand>();
            services.AddTransient<IGetOneCustomerFrontQuery, EfGetOneCustomerQuery>();
            services.AddTransient<IGetCustomersQuery, EfGetCustomersQuery>();
            services.AddTransient<IUpdateCustomerCommand, EfUpdateCustomerCommand>();
            services.AddTransient<IRegisterCustomerCommand, EfRegisterCustomerCommand>();

            //categories

            services.AddTransient<IAddCategoryCommand, EfAddCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();

            //cities

            services.AddTransient<IAddCityCommand, EfAddCityCommand>();
            services.AddTransient<IUpdateCityCommand, EfUpdateCityCommand>();
            //services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>();

            //products

            services.AddTransient<IAddProductCommand, EfAddProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();

            //orders

            services.AddTransient<IAddOrderCommand, EfAddOrderCommand>();
            services.AddTransient<IUpdateOrderCommand, EfUpdateOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, EfDeleteOrderCommand>();


            // Restaurants

            services.AddTransient<IAddRestaurantCommand, EfAddRestaurantCommand>();
            services.AddTransient<IUpdateRestaurantCommand, EfUpdateRestaurantCommand>();
            services.AddTransient<IGetRestaurantsQuery, EfGetRestaurantsQuery>();
            services.AddTransient<IGetRestaurantQuery, EfGetOneRestaurantQuery>();
            services.AddTransient<IDeleteRestaurantCommand, EfDeleteRestaurantCommand>();


            // Reviews

            services.AddTransient<IAddReviewCommand, EfAddReviewCommand>();
            services.AddTransient<IUpdateReviewCommand, EfUpdateReviewCommand>();
            services.AddTransient<IDeleteReviewCommand, EfDeleteReviewCommand>();

            //email

            services.AddTransient<IEmailSender, SmtpEmailSender>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            // Customers

            services.AddTransient<AddCustomerValidator>();
            services.AddTransient<DeleteCustomerValidator>();
            services.AddTransient<UpdateCustomerValidator>();
            services.AddTransient<LoginCustomerValidator>();
            services.AddTransient<RegisterCustomerValidator>();

            // Categories

            services.AddTransient<AddCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();

            // Reviews

            services.AddTransient<AddReviewValidator>();
            services.AddTransient<DeleteReviewValidator>();
            services.AddTransient<UpdateReviewValidator>();

            // Products

            services.AddTransient<AddProductValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddTransient<DeleteProductValidator>();

            // Orders

            services.AddTransient<AddOrderValidator>();
            services.AddTransient<UpdateOrderValidator>();
            services.AddTransient<DeleteOrderValidator>();

            // Cities

            services.AddTransient<AddCityValidator>();
            services.AddTransient<UpdateCityValidator>();
            //services.AddTransient<DeleteCityValidator>();

            // Restaurants

            services.AddTransient<AddRestaurantValidator>();
            services.AddTransient<UpdateRestaurantValidator>();
            services.AddTransient<DeleteRestaurantValidator>();

            //contact

            services.AddTransient<ContactValidator>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
             
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return (IApplicationActor)actor;

            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "blog_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey!")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
