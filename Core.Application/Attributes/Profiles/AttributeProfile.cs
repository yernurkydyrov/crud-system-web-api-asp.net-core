using System.Linq;
using AutoMapper;
using Core.Application.Attributes.Models;
using Core.Application.Categories.Models;
using Core.Domain.Entities;

namespace Core.Application.Attributes.Profiles
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<Attributive, AttributeDto>()
                .ReverseMap();

            /*
            .ForMember(q => q.CategoryDtos, w => w.MapFrom(q => q.AttributesCategory.Select(ca => ca.Attribute)));#1#
    */
        }
    }
}