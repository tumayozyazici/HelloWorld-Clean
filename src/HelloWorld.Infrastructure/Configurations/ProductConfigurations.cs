using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne (c => c.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(c => c.CategoryId);

            builder.HasData(
                new Product
                {
                    Id = "1",
                    ProductName = "Bilgisayar",
                    Price = 19.99m,
                    InStock = 100,
                    CategoryId = "1",
                    Description = "Güçlü bir bilgisayar"
                },
                new Product
                {
                    Id = "2",
                    ProductName = "Elektrik Süpürgesi",
                    Price = 29.99m,
                    InStock = 150,
                    CategoryId = "1",
                    Description = "Etkili temizlik için"
                },
                new Product
                {
                    Id = "3",
                    ProductName = "Körlük",
                    Price = 9.99m,
                    InStock = 200,
                    CategoryId = "2",
                    Description = "Görmeyi engelleyen bir ürün"
                },
                new Product
                {
                    Id = "4",
                    ProductName = "Dijital Kale",
                    Price = 14.99m,
                    InStock = 250,
                    CategoryId = "2",
                    Description = "Güvenlik için dijital çözüm"
                },
                new Product
                {
                    Id = "5",
                    ProductName = "Memelik",
                    Price = 49.99m,
                    InStock = 300,
                    CategoryId = "3",
                    Description = "Konforlu ve şık"
                },
                new Product
                {
                    Id = "6",
                    ProductName = "Boxer",
                    Price = 99.99m,
                    InStock = 350,
                    CategoryId = "3",
                    Description = "Rahat ve dayanıklı"
                }
            );
        }
    }
}
