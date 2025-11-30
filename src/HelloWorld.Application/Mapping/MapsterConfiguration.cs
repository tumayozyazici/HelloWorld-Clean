using HelloWorld.Application.Features.Commands.CategoryCommands;
using HelloWorld.Application.Features.Commands.ProductCommands;
using HelloWorld.Application.Features.Commands.UserCommands;
using HelloWorld.Application.Features.Queries.UserQueries;
using HelloWorld.Application.Features.Results.CategoryResults;
using HelloWorld.Application.Features.Results.ProductResults;
using HelloWorld.Application.Features.Results.UserResults;
using HelloWorld.Domain.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Mapping
{
    public static class MapsterConfiguration
    {
        public static void Configure()
        {
            //UserMappings
            TypeAdapterConfig<CreateUserCommand, User>.NewConfig()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.BirthDate, src => src.BirthDate);

            TypeAdapterConfig<UpdateUserCommand, User>.NewConfig()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.BirthDate, src => src.BirthDate)
                .Map(dest => dest.ShippingAdress, src => src.ShippingAdress)
                .Map(dest => dest.BillingAdress, src => src.BillingAdress)
                .IgnoreNullValues(true);

            TypeAdapterConfig<User,GetUserByIdQueryResult>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.BirthDate, src => src.BirthDate)
                .Map(dest => dest.BillingAdress, src => src.BillingAdress)
                .Map(dest => dest.ShippingAdress, src => src.ShippingAdress)
                .Map(dest => dest.Status, src => src.Status.ToString())
                .IgnoreNullValues(true);

            TypeAdapterConfig<IEnumerable<User>,IEnumerable<GetUsersQueryResult>>.NewConfig()
                .Map(dest => dest, src => src.Select(user => new GetUsersQueryResult
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                    BillingAdress = user.BillingAdress,
                    ShippingAdress = user.ShippingAdress,
                    Status = user.Status.ToString()
                }))
                .IgnoreNullValues(true);


            //ProductMappings
            TypeAdapterConfig<CreateProductCommand, Product>.NewConfig()
                .Map(dest => dest.ProductName, src => src.ProductName)
                .Map(dest => dest.InStock, src => src.InStock)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.CategoryId, src => src.CategoryId);

            TypeAdapterConfig<UpdateProductCommand, Product>.NewConfig()
                .Map(dest => dest.ProductName, src => src.ProductName)
                .Map(dest => dest.InStock, src => src.InStock)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.CategoryId, src => src.CategoryId);

            TypeAdapterConfig<Product, GetProductByIdQueryResult>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.ProductName, src => src.ProductName)
                .Map(dest => dest.InStock, src => src.InStock)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.CategoryId, src => src.CategoryId);
            TypeAdapterConfig<IEnumerable<Product>, IEnumerable<GetProductsQueryResult>>.NewConfig()
                .Map(dest => dest, src => src.Select(product => new GetProductsQueryResult
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    InStock = product.InStock,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                }));


            //CategoryMappings
            TypeAdapterConfig<CreateCategoryCommand, Category>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.CategoryName);

            TypeAdapterConfig<UpdateCategoryCommand, Category>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.CategoryName);

            TypeAdapterConfig<Category,GetCategoryByIdQueryResult>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.CategoryName);

            TypeAdapterConfig<IEnumerable<Category>, IEnumerable<GetCategoriesQueryResult>>.NewConfig()
                .Map(dest => dest, src => src.Select(category => new GetCategoriesQueryResult
                {
                    CategoryName =  category.CategoryName
                }));
        }
    }
}
