using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Maps
{
    public class PhoneMap 
    { 
        public PhoneMap(EntityTypeBuilder<Phone> entityBuilder) 
        { 
            entityBuilder.HasKey(t => t.Id); 
            entityBuilder.Property(t => t.Name).IsRequired(); 
            entityBuilder.Property(t => t.Price).IsRequired(); 
        } 
    } 
}