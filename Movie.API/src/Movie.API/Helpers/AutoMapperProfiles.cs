using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.API.DTOs;
using Movie.Domain.Models;

namespace Movie.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Movies, MovieWithTypeDto>()
                .ForMember(dest => dest.Type, option =>
                {
                    option.MapFrom(src => src.Type.Description);
                })
                .ForMember(destination => destination.TypeId,
                options => {
                    options.MapFrom(source => source.Type.Id);
                });
        }
    }
}
