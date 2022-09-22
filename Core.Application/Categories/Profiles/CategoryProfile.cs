using System.Linq;
using AutoMapper;
using Core.Application.Categories.Models;
using Core.Domain.Entities;

namespace Core.Application.Categories.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(q => q.Attributes, w => w.MapFrom(q => q.CategoryAttributes.Select(ca => ca.Attribute)));

            CreateMap<CategoryDto, Category>()
                .ForMember(u => u.Name, p => p.AddTransform(u => "aasdsdsds"))
                .ForMember(q => q.CategoryAttributes, 
                    w => w.MapFrom(q => q.Attributes.Select(ca => new CategoryAttribute(q.Id, ca.Id))));
            
        }
    }
}